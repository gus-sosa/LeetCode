using System;
using System.Collections.Generic;
using System.Text;

namespace WordBreakII {
  class Program {
    static void Main(string[] args) {
      var s = new Solution();
      PrintArray(s.WordBreak("catsanddog", new string[] { "cat", "cats", "and", "sand", "dog" }));
    }

    private static void PrintArray(IList<string> lists) {
      Console.WriteLine(new string('=', 20));
      foreach (var item in lists) {
        Console.WriteLine(item);
      }
    }

    #region MyRegion


    #region MyRegion


    public class Solution {
      private TrieNode trie;
      private string s;
      private Dictionary<int, List<string>> dict;
      private List<int> breakPoints;

      public class TrieNode {
        public bool IsEndWord { get; internal set; }

        private Dictionary<char, TrieNode> children = new Dictionary<char, TrieNode>();

        internal TrieNode GetChild(char v) {
          TrieNode child = null;
          children.TryGetValue(v, out child);
          return child;
        }

        internal void AddWord(string word) {
          var current = this;
          for (int i = 0; i < word.Length; ++i) {
            var next = current.GetChild(word[i]);
            if (next == null) {
              next = new TrieNode();
              current.children.Add(word[i], next);
            }
            if (i == word.Length - 1) {
              next.IsEndWord = true;
            }
            current = next;
          }
        }
      }

      public IList<string> WordBreak(string s, IList<string> wordDict) {
        this.trie = BuildTrie(wordDict);
        dict = new Dictionary<int, List<string>>();
        breakPoints = new List<int>();
        this.s = s;
        WordBreak(0);
        return dict[0];
      }

      private void WordBreak(int pos) {
        if (dict.ContainsKey(pos)) {
          return;
        }

        dict[pos] = new List<string>();
        TrieNode current = trie;
        while (pos < s.Length && current != null) {
          current = current.GetChild(s[pos]);
          if (current != null && current.IsEndWord) {
            breakPoints.Add(pos);
            WordBreak(pos + 1);
            if (dict[pos + 1].Count > 0) {
              string prefix = buildPrefix();
              foreach (var suffix in dict[pos + 1]) {
                dict[pos].Add(string.Format("{0} {1}", prefix, suffix));
              }
            }
            breakPoints.RemoveAt(breakPoints.Count - 1);
          }
          ++pos;
        }
      }

      private string buildPrefix() {
        var sb = new StringBuilder();
        int currentPos = 0;
        foreach (var currentBreakPoint in breakPoints) {
          while (currentPos <= currentBreakPoint) {
            sb.Append(s[currentPos++]);
          }
          sb.Append(' ');
        }
        return sb.ToString();
      }

      public TrieNode BuildTrie(IEnumerable<string> words) {
        var trie = new TrieNode();
        foreach (var word in words) {
          trie.AddWord(word);
        }
        return trie;
      }
    }


    #endregion


    #endregion
  }
}
