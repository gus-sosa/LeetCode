using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace ImplementTrie {
  class Program {
    static void Main(string[] args) {
      Console.WriteLine("Hello World!");
    }
  }

  #region MyRegion


  public class Trie {

    private TrieNode root { get; set; }

    /** Initialize your data structure here. */
    public Trie() {
      root = new TrieNode();
    }

    class TrieNode {
      public Dictionary<char, TrieNode> children = new Dictionary<char, TrieNode>();
      public bool EndWord { get; set; } = false;
    }

    /** Inserts a word into the trie. */
    public void Insert(string word) {
      var current = root;
      int i = 0;
      while (i < word.Length && current.children.ContainsKey(word[i])) {
        current = current.children[word[i]];
        ++i;
      }
      while (i < word.Length) {
        current.children.Add(word[i], new TrieNode());
        current = current.children[word[i]];
        ++i;
      }
      current.EndWord = true;
    }

    /** Returns if the word is in the trie. */
    public bool Search(string word) {
      TrieNode node = getNode(word);
      return node != null && node.EndWord;
    }

    /** Returns if there is any word in the trie that starts with the given prefix. */
    public bool StartsWith(string prefix) {
      TrieNode node = getNode(prefix);
      return node != null;
    }

    private TrieNode getNode(string word) {
      int i = 0;
      TrieNode current = root;
      while (i < word.Length && current != null) {
        if (current.children.ContainsKey(word[i])) {
          current = current.children[word[i]];
        } else {
          current = null;
        }
        ++i;
      }
      return current;
    }
  }

  /**
   * Your Trie object will be instantiated and called as such:
   * Trie obj = new Trie();
   * obj.Insert(word);
   * bool param_2 = obj.Search(word);
   * bool param_3 = obj.StartsWith(prefix);
   */


  #endregion
}
