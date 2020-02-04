using System;
using System.Collections.Generic;
using System.Linq;

namespace NumberOfIslands {
  class Program {
    static void Main(string[] args) {
      var s = new Solution();
      var grid1 = new char[][] {
        new char[] {'1', '1', '0', '0', '0'},
        new char[] {'1', '1', '0', '0', '0'},
        new char[] {'0', '0', '1', '0', '0'},
        new char[] {'0', '0', '0', '1', '1'}
      };
      Console.WriteLine(s.NumIslands(grid1) == 3);
    }

    public class Solution {

      private static int[] _rowMovements = new int[] { -1, 0, 1, 0 };
      private static int[] _colMovements = new int[] { 0, 1, 0, -1 };
      public int NumIslands(char[][] grid) {
        if (grid == null || grid.Length == 0 || grid[0].Length == 0) {
          return 0;
        }
        var marked = new bool[grid.Length, grid[0].Length];
        int numIslands = 0;
        for (int i = 0; i < grid.Length; ++i) {
          for (int j = 0; j < grid[0].Length; j++) {
            if (!marked[i, j] && grid[i][j] == '1') {
              ++numIslands;
              NumIslands(grid, marked, i, j);
            }
          }
        }
        return numIslands;
      }

      private void NumIslands(char[][] grid, bool[,] marked, int i, int j) {
        var queue = new Queue<Tuple<int, int>>();
        marked[i, j] = true;
        queue.Enqueue(Tuple.Create(i, j));
        while (queue.Count > 0) {
          var current = queue.Dequeue();
          int row = current.Item1, col = current.Item2;
          foreach (Tuple<int, int> item in AdjacentPositions(row, col).Where(t => IsInGrid(grid, t) && !IsMarked(marked, t) && grid[t.Item1][t.Item2] == '1')) {
            marked[item.Item1, item.Item2] = true;
            queue.Enqueue(item);
          }
        }
      }

      private bool IsMarked(bool[,] marked, Tuple<int, int> t) => marked[t.Item1, t.Item2];

      private bool IsInGrid(char[][] grid, Tuple<int, int> t) => t.Item1 >= 0 && t.Item1 < grid.Length && t.Item2 >= 0 && t.Item2 < grid[0].Length;

      private IEnumerable<Tuple<int, int>> AdjacentPositions(int row, int col) {
        for (int i = 0; i < _rowMovements.Length; ++i) {
          yield return Tuple.Create(row + _rowMovements[i], col + _colMovements[i]);
        }
      }
    }
  }
}
