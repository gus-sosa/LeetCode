using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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


    public class Solution {
      private TrieNode trie;
      private string s;
      private Dictionary<int, List<string>> dict;

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

        public bool ContainsWord(string word) {
          var current = this;
          for (int i = 0; i < word.Length && current != null; ++i) {
            current = current.GetChild(word[i]);
          }
          return current != null && current.IsEndWord;
        }
      }

      public IList<string> WordBreak(string s, IList<string> wordDict) {
        this.trie = BuildTrie(wordDict);
        this.s = s;
        dict = new Dictionary<int, List<string>>();
        WordBreak(0);
        return dict.ContainsKey(0) ? dict[0] : new List<string>();
      }

      private void WordBreak(int pos) {
        if (dict.ContainsKey(pos)) {
          return;
        }

        var result = new List<string>();
        for (int i = pos; i < s.Length; ++i) {
          var cad = s.Substring(pos, i - pos + 1);
          if (trie.ContainsWord(cad)) {
            if (i == s.Length - 1) {
              result.Add(cad);
            } else {
              WordBreak(i + 1);
              if (dict.ContainsKey(i + 1) && dict[i + 1].Count > 0) {
                result.AddRange(dict[i + 1].Select(ii => string.Format("{0} {1}", cad, ii)));
              }
            }
          }
        }
        dict[pos] = result;
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

  }
}
