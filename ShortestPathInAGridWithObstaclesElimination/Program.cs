using System;
using System.Collections.Generic;

namespace ShortestPathInAGridWithObstaclesElimination {
  class Program {
    static void Main(string[] args) {
      var s = new Solution();
      var arr = new int[][] {
        new int[]{ 0,0,0},
        new int[]{ 1,1,0},
        new int[]{ 0,0,0},
        new int[]{ 0,1,1},
        new int[]{ 0,0,0}
      };
      Console.WriteLine(s.ShortestPath(arr, 1) == 6);
      arr = new int[][] {
        new int[]{ 0,1,1},
        new int[]{ 1,1,1},
        new int[]{ 1,0,0}
      };
      Console.WriteLine(s.ShortestPath(arr, 1) == -1);
      arr = new int[][] {
        new int[]{ 0}
      };
      Console.WriteLine(s.ShortestPath(arr, 1) == 0);


      arr = new int[][] {
        new int[] { 0, 1, 0, 0, 0, 1, 0, 0 },
        new int[] { 0, 1, 0, 1, 0, 1, 0, 1 },
        new int[] { 0, 0, 0, 1, 0, 0, 1, 0 }
      };
      Console.WriteLine(s.ShortestPath(arr, 1) == 13);

    }
  }

  #region MyRegion


  public class Solution {
    private static int[] rowDir = new int[] { 0, 1, 0, -1 };
    private static int[] colDir = new int[] { 1, 0, -1, 0 };

    public int ShortestPath(int[][] grid, int k) {
      int numRows = grid.Length, numCols = grid[0].Length, l = 0;
      var marked = new bool[numRows, numCols, k + 1];
      var q = new Queue<Tuple<int, int, int>>();
      q.Enqueue(Tuple.Create(0, 0, 0));
      while (q.Count > 0) {
        int count = q.Count;
        ++l;
        for (int i = 0; i < count; ++i) {
          var current = q.Dequeue();
          if (current.Item1 == numRows - 1 && current.Item2 == numCols - 1) {
            return l - 1;
          }
          foreach (Tuple<int, int> nextPos in getAdjacents(current.Item1, current.Item2, numRows, numCols)) {
            if (!marked[nextPos.Item1, nextPos.Item2, current.Item3] && (grid[nextPos.Item1][nextPos.Item2] == 0 || current.Item3 + 1 <= k)) {
              if (nextPos.Item1 == numRows - 1 && nextPos.Item2 == numCols - 1) {
                return l;
              }
              marked[nextPos.Item1, nextPos.Item2, current.Item3] = true;
              q.Enqueue(Tuple.Create(nextPos.Item1, nextPos.Item2, current.Item3 + grid[nextPos.Item1][nextPos.Item2]));
            }
          }
        }
      }
      return -1;
    }

    private IEnumerable<Tuple<int, int>> getAdjacents(int row, int col, int numRows, int numCols) {
      for (int i = 0, nextRow, nextCol; i < rowDir.Length; ++i) {
        nextRow = row + rowDir[i];
        nextCol = col + colDir[i];
        if (nextRow >= 0 && nextCol >= 0 && nextRow < numRows && nextCol < numCols) {
          yield return Tuple.Create(nextRow, nextCol);
        }
      }
    }
  }


  #endregion
}
