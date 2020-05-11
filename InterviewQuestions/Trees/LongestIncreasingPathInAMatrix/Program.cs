using System;
using System.ComponentModel.Design;
using System.Diagnostics;

namespace LongestIncreasingPathInAMatrix {
  class Program {
    static void Main(string[] args) {
      var s = new Solution();
      var arr = new int[][] {
        new int[]{ 9,9,4},
        new int[]{ 6,6,8},
        new int[]{ 2,1,1}
      };
      Console.WriteLine(s.LongestIncreasingPath(arr) == 4);

      arr = new int[][] {
        new int[]{ 3,4,5},
        new int[]{ 3,2,6},
        new int[]{ 2,2,1}
      };
      Console.WriteLine(s.LongestIncreasingPath(arr) == 4);
    }
  }

  #region MyRegion


  public class Solution {
    private static int[] dirRows = new int[] { -1, 0, 1, 0 };
    private static int[] dirCols = new int[] { 0, 1, 0, -1 };

    public int LongestIncreasingPath(int[][] matrix) {
      if (matrix.Length == 0) {
        return 0;
      }
      int maxPathLength = 0;
      int[,] marked = new int[matrix.Length, matrix[0].Length];
      for (int i = 0; i < matrix.Length; ++i) {
        for (int j = 0; j < matrix[0].Length; ++j) {
          maxPathLength = Math.Max(maxPathLength, dfs(matrix, marked, i, j));
        }
      }
      return maxPathLength;
    }

    private int dfs(int[][] matrix, int[,] marked, int i, int j) {
      marked[i, j] = 1;
      for (int p = 0, nextI, nextJ; p < dirRows.Length; ++p) {
        nextI = i + dirRows[p];
        nextJ = j + dirCols[p];
        if (nextI >= 0 && nextJ >= 0 && nextI < matrix.Length && nextJ < matrix[0].Length && matrix[i][j] < matrix[nextI][nextJ]) {
          if (marked[nextI, nextJ] > 0) {
            marked[i, j] = Math.Max(marked[i, j], 1 + marked[nextI, nextJ]);
          } else {
            marked[i, j] = Math.Max(marked[i, j], 1 + dfs(matrix, marked, nextI, nextJ));
          }
        }
      }
      return marked[i, j];
    }
  }


  #endregion
}
