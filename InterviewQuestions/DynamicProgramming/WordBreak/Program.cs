using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;

namespace WordBreak {
  class Program {
    static void Main(string[] args) {
      var s = new Solution();
      Console.WriteLine(s.WordBreak("leetcode", new string[] { "leet", "code" }) == true);
      Console.WriteLine(s.WordBreak("applepenapple", new string[] { "apple", "pen" }) == true);
      Console.WriteLine(s.WordBreak("catsandog", new string[] { "cats", "dog", "sand", "and", "cat" }) == false);
      Console.WriteLine(s.WordBreak("cars", new string[] { "car", "ca", "rs" }));
      Console.WriteLine(s.WordBreak("a", new string[] { "a" }) == true);
    }

    #region MyRegion


    public class Solution {
      private TrieNode trie;
      private string s;
      private Dictionary<int, bool> dict = new Dictionary<int, bool>();

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

      public bool WordBreak(string s, IList<string> wordDict) {
        this.trie = BuildTrie(wordDict);
        this.s = s;
        return WordBreak(0);
      }

      private bool WordBreak(int pos) {
        if (dict.ContainsKey(pos)) {
          return dict[pos];
        }

        TrieNode current = trie;
        while (pos < s.Length && current != null) {
          current = current.GetChild(s[pos]);
          if (current != null && current.IsEndWord && WordBreak(pos + 1)) {
            return true;
          }
          ++pos;
        }
        return dict[pos] = current != null && current.IsEndWord;
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
