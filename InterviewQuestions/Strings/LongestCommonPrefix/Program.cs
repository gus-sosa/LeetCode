using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LongestCommonPrefix {
  class Program {
    public class Trie {
      private char nodeValue = '\0';
      private Dictionary<char, Trie> children = new Dictionary<char, Trie>();
      private Trie parent = null;
      private bool terminalNode = false;

      public Trie(char value = '\0', Trie parent = null) {
        nodeValue = value;
        this.parent = parent;
      }

      public Trie GetCommonAncestor() {
        if (children.Count == 1 && !this.terminalNode) {
          return children.First().Value.GetCommonAncestor();
        }
        return this;
      }

      public string BuildString() {
        var s = new StringBuilder();
        var currentNode = this;
        while (currentNode != null) {
          s.Insert(0, currentNode.nodeValue);
          currentNode = currentNode.parent;
        }
        return s.Remove(0, 1).ToString();
      }

      public void AddWord(string word) {
        AddWord(word.ToCharArray(), 0);
      }

      private void AddWord(char[] charArray, int index) {
        if (index >= charArray.Length) {
          terminalNode = true;
          return;
        }

        char currentValue = charArray[index];
        if (children.ContainsKey(currentValue)) {
          children[currentValue].AddWord(charArray, index + 1);
        } else {
          var trie = new Trie(currentValue, this);
          trie.AddWord(charArray, index + 1);
          children[currentValue] = trie;
        }
      }
    }

    public string LongestCommonPrefix(string[] strs) {
      var trie = new Trie();
      foreach (var s in strs) {
        if (string.IsNullOrEmpty(s)) {
          return string.Empty;
        }
        trie.AddWord(s);
      }
      return trie.GetCommonAncestor().BuildString();
    }

    static void Main(string[] args) {
      var p = new Program();
      Console.WriteLine(p.LongestCommonPrefix(new[] { "flower", "flow", "flight" }) == "fl");
      Console.WriteLine(p.LongestCommonPrefix(new[] { "dog", "racecar", "car" }) == "");
      Console.WriteLine(p.LongestCommonPrefix(new[] { "flower", "flow", "" }) == "");
      Console.WriteLine(p.LongestCommonPrefix(new[] { "aa", "a" }) == "a");
      Console.WriteLine(p.LongestCommonPrefix(new[] { "aaa", "aa", "aaa" }) == "aa");
    }
  }
}
