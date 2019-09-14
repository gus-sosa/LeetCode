using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Utility;


namespace WordSearch2 {
  class Program {

    static int[] dirRow = new int[] { -1, 0, 1, 0 };
    static int[] dirCol = new int[] { 0, 1, 0, -1 };

    private class TrieNode {

      private Dictionary<char, TrieNode> children = new Dictionary<char, TrieNode>();
      private TrieNode parent = null;

      public bool IsLeaf { get; internal set; } = false;

      public TrieNode(TrieNode parent = null) {
        this.parent = parent;
      }

      public TrieNode this[char c] {
        get {
          if (children.ContainsKey(c)) {
            return children[c];
          }
          return null;
        }
      }

      internal void Insert(char c) {
        if (!children.ContainsKey(c)) {
          children[c] = new TrieNode(this);
        }
      }

      internal string BuildWord() {
        var current = this;
        StringBuilder result = new StringBuilder();
        while (current != null) {
          result.Insert(0, current.GetValue());
          current = current.parent;
        }
        return result.ToString();
      }

      private string GetValue() {
        if (parent != null) {
          var parentKeys = parent.children.Keys;
          foreach (var key in parentKeys) {
            if (parent[key] == this) {
              return key.ToString();
            }
          }
        }
        return string.Empty;
      }
    }

    private class Trie {
      public Trie() {
        Root = new TrieNode();
      }

      public TrieNode Root { get; internal set; }

      public bool Contains(string word) {
        var current = Root;
        foreach (var currentLetter in word) {
          if (current[currentLetter] != null) {
            current = current[currentLetter];
          } else {
            return false;
          }
        }
        return true;
      }

      internal void Insert(string word) {
        var current = Root;
        foreach (var letter in word) {
          current.Insert(letter);
          current = current[letter];
        }
        current.IsLeaf = true;
      }
    }

    public class Marker {
      private Dictionary<int, HashSet<int>> dict = new Dictionary<int, HashSet<int>>();

      internal void Clear() {
        foreach (var item in dict.Values) {
          item.Clear();
        }
        dict.Clear();
      }

      internal void Mark(int i, int j) {
        if (!dict.ContainsKey(i)) {
          dict[i] = new HashSet<int>();
        }
        dict[i].Add(j);
      }

      internal bool IsMarked(int ni, int nj) {
        return dict.ContainsKey(ni) && dict[ni].Contains(nj);
      }

      internal void Unmark(int i, int j) {
        if (dict.ContainsKey(i)) {
          dict[i].Remove(j);
          if (dict[i].Count == 0) {
            dict.Remove(i);
          }
        }
      }
    }

    public IList<string> FindWords(char[][] board, string[] words) {
      //Debugger.Launch();
      Trie trie = BuildTrie(words);
      var marker = new Marker();
      var results = new HashSet<TrieNode>();
      for (int i = 0; i < board.Length; i++) {
        for (int j = 0; j < board[0].Length; j++) {
          if (trie.Root[board[i][j]] != null) {
            dfs(board, trie.Root[board[i][j]], i, j, marker, results);
          }
        }
      }
      return results.Select(i => i.BuildWord()).ToArray();
    }

    private void dfs(char[][] board, TrieNode trieNode, int i, int j, Marker marker, HashSet<TrieNode> results) {
      marker.Mark(i, j);
      if (trieNode.IsLeaf) {
        results.Add(trieNode);
      }
      foreach (var item in GiveNextAvailablePos(board, i, j, marker)) {
        if (trieNode[item.Item3] != null) {
          dfs(board, trieNode[item.Item3], item.Item1, item.Item2, marker, results);
        }
      }
      marker.Unmark(i, j);
    }

    private Trie BuildTrie(string[] words) {
      var trie = new Trie();
      foreach (var word in words) {
        trie.Insert(word);
      }
      return trie;
    }

    private IEnumerable<Tuple<int, int, char>> GiveNextAvailablePos(char[][] board, int i, int j, Marker marker) {
      for (int k = 0; k < dirRow.Length; ++k) {
        int ni = i + dirRow[k], nj = j + dirCol[k];
        if (ni >= 0 && nj >= 0 && ni < board.Length && nj < board[0].Length && !marker.IsMarked(ni, nj)) {
          yield return Tuple.Create(ni, nj, board[ni][nj]);
        }
      }
    }

    static void Main(string[] args) {
      char[][] board = GetBoard();
      string[] words = GetWords();
      string[] expectedResult = GetWords();
      var result = new Program().FindWords(board, words).ToArray();
      Array.Sort(result);
      Array.Sort(expectedResult);
      Console.WriteLine($"result => {result.GetStringToPrint()}");
      Console.WriteLine($"expected result => {expectedResult.GetStringToPrint()}");
      Console.WriteLine($"arrays are equal => {result.SameArrays(expectedResult)}");
    }

    private static char[][] GetBoard() {
      int rowCount = int.Parse(Console.ReadLine());
      var board = new char[rowCount][];
      for (int i = 0; i < rowCount; i++) {
        board[i] = Console.ReadLine().Split().Select(char.Parse).ToArray();
      }
      return board;
    }

    private static string[] GetWords() => Console.ReadLine().Split().ToArray();
  }
}
