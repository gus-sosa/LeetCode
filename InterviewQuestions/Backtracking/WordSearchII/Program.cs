using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WordSearchII {
  class Program {
    static void Main(string[] args) {
      var s = new Solution();
      var board = new char[][] {
        new char[]{ 'o','a','a','n'},
        new char[]{ 'e','t','a','e'},
        new char[]{ 'i','h','k','r'},
        new char[]{ 'i','f','l','v'}
      };
      var words = new string[] { "oath", "pea", "eat", "rain" };
      Print(s.FindWords(board, words));
    }

    private static void Print(IList<string> list) {
      Console.WriteLine("======sol=========");
      foreach (var item in list) {
        Console.WriteLine(item);
      }
    }
  }

  #region MyRegion


  public class Solution {
    bool[,] marked;
    char[][] board;
    int n, m;
    int[] dirRow = new int[] { -1, 0, 1, 0 };
    int[] dirCol = new int[] { 0, 1, 0, -1 };

    public IList<string> FindWords(char[][] board, string[] words) {
      Trie t = buildTrie(words);
      n = board.Length;
      m = board[0].Length;
      marked = new bool[board.Length, board[0].Length];
      this.board = board;
      var retval = new HashSet<string>();
      var currentString = new StringBuilder();
      for (int i = 0; i < board.Length; ++i) {
        for (int j = 0; j < board[0].Length; ++j) {
          dfs(i, j, t, currentString, retval);
        }
      }
      return retval.ToList();
    }

    private void dfs(int row, int col, Trie root, StringBuilder sb, HashSet<string> retval) {
      if (row < 0 || col < 0 || row >= n || col >= m || !root.Contains(board[row][col]) || marked[row, col]) {
        return;
      }

      marked[row, col] = true;
      root = root.Get(board[row][col]);
      sb.Append(root.Value);

      if (root.EndWord) {
        retval.Add(sb.ToString());
      }

      for (int i = 0, rowNext, colNext; i < dirRow.Length; ++i) {
        rowNext = row + dirRow[i];
        colNext = col + dirCol[i];
        dfs(rowNext, colNext, root, sb, retval);
      }
      sb.Remove(sb.Length - 1, 1);
      marked[row, col] = false;
    }

    private Trie buildTrie(string[] words) {
      var t = new Trie();
      foreach (var word in words) {
        t.Add(word);
      }
      return t;
    }

    public class Trie {
      public char Value { get; set; }
      public bool EndWord { get; set; }

      public Dictionary<char, Trie> Children { get; set; } = new Dictionary<char, Trie>();

      public bool Contains(char c) {
        return Children.ContainsKey(c);
      }

      internal void Add(string word) {
        var current = this;
        foreach (var w in word) {
          if (!current.Contains(w)) {
            current.Children[w] = new Trie() { Value = w };
          }
          current = current.Get(w);
        }
        current.EndWord = true;
      }

      internal Trie Get(char v) {
        return Children[v];
      }
    }
  }


  #endregion
}
