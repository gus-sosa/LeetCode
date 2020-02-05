using System;
using System.Collections.Generic;
using System.Linq;

namespace WordSearch {
  class Program {
    static void Main(string[] args) {
      Console.WriteLine("Hello World!");
    }

    #region MyRegion


    public class Solution {
      public bool Exist(char[][] board, string word) {
        var marked = new bool[board.Length, board[0].Length];
        for (int i = 0; i < board.Length; ++i) {
          for (int j = 0; j < board[0].Length; ++j) {
            marked[i, j] = true;
            if (board[i][j] == word[0] && Exist(board, marked, word, 1, i, j)) {
              return true;
            }
            marked[i, j] = false;
          }
        }
        return false;
      }

      private bool Exist(char[][] board, bool[,] marked, string word, int currentWordPos, int i, int j) {
        if (word.Length == currentWordPos) {
          return true;
        }
        foreach (var item in AdjacentPositions(i, j).Where(t => t.Item1 >= 0 && t.Item2 >= 0 && t.Item1 < board.Length && t.Item2 < board[0].Length && !marked[t.Item1, t.Item2] && word[currentWordPos] == board[t.Item1][t.Item2])) {
          marked[item.Item1, item.Item2] = true;
          if (Exist(board, marked, word, currentWordPos + 1, item.Item1, item.Item2)) {
            return true;
          }
          marked[item.Item1, item.Item2] = false;
        }
        return false;
      }

      private static int[] rowMovs = new int[] { -1, 0, 1, 0 };
      private static int[] colMovs = new int[] { 0, 1, 0, -1 };
      private IEnumerable<Tuple<int, int>> AdjacentPositions(int i, int j) {
        for (int k = 0; k < rowMovs.Length; ++k) {
          yield return Tuple.Create(i + rowMovs[k], j + colMovs[k]);
        }
      }
    }


    #endregion
  }
}
