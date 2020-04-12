using System;
using System.Collections.Generic;

namespace SurroundedRegions {
  class Program {
    static void Main(string[] args) {
      Console.WriteLine("Hello World!");
    }

    #region MyRegion


    public class Solution {
      const char O_LETTER = 'O';
      const char X_LETTER = 'X';
      static int[] rowDir = new int[] { -1, 0, 1, 0 };
      static int[] colDir = new int[] { 0, 1, 0, -1 };

      public void Solve(char[][] board) {
        if (board == null || board.Length == 0) {
          return;
        }
        var regionMarker = new int[board.Length, board[0].Length];
        var goodRegions = new HashSet<int>();
        int region = 0;
        for (int i = 0; i < board.Length; ++i) {
          for (int j = 0; j < board[0].Length; ++j) {
            if (board[i][j] == O_LETTER && regionMarker[i, j] == 0) {
              goodRegions.Add(++region);
              bfs(i, j, region, board, regionMarker, goodRegions);
            }
          }
        }
        for (int i = 0; i < board.Length; ++i) {
          for (int j = 0; j < board[0].Length; ++j) {
            if (board[i][j] == O_LETTER && goodRegions.Contains(regionMarker[i, j])) {
              board[i][j] = X_LETTER;
            }
          }
        }
      }

      private void bfs(int i, int j, int region, char[][] board, int[,] regionMarker, HashSet<int> goodRegions) {
        var queue = new Queue<Tuple<int, int>>();
        queue.Enqueue(Tuple.Create(i, j));
        regionMarker[i, j] = region;
        int x, y;
        while (queue.Count > 0) {
          var current = queue.Dequeue();
          x = current.Item1;
          y = current.Item2;
          if (isInBorder(x, y, board.Length, board[0].Length)) {
            goodRegions.Remove(region);
          }
          foreach (Tuple<int, int> item in GetNeighbors(x, y, regionMarker, board)) {
            queue.Enqueue(item);
            regionMarker[item.Item1, item.Item2] = region;
          }
        }
      }

      private IEnumerable<Tuple<int, int>> GetNeighbors(int x, int y, int[,] regionMarker, char[][] board) {
        var l = new List<Tuple<int, int>>();
        for (int i = 0, xN, yN; i < rowDir.Length; ++i) {
          xN = x + rowDir[i];
          yN = y + colDir[i];
          if (xN >= 0 && yN >= 0 && xN < regionMarker.GetLength(0) && yN < regionMarker.GetLength(1) && regionMarker[xN, yN] == 0 && board[xN][yN] == O_LETTER) {
            l.Add(Tuple.Create(xN, yN));
          }
        }
        return l;
      }

      private bool isInBorder(int x, int y, int lRow, int lCol) {
        return x == 0 || y == 0 || x == lRow - 1 || y == lCol - 1;
      }
    }


    #endregion
  }
}
