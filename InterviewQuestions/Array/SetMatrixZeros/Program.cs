using System;

namespace SetMatrixZeros {
  class Program {
    static void Main(string[] args) {
      var p = new Program();
      var m = new int[][] {
        new int[]{ 0,1,2,0},
        new int[]{ 3,4,5,2},
        new int[]{ 1,3,1,5}
      };
      p.SetZeroes(m);
      PrintMatrix(m);
    }

    private static void PrintMatrix(int[][] m) {
      Console.WriteLine();
      Console.WriteLine();
      for (int i = 0; i < m.Length; i++) {
        for (int j = 0; j < m[0].Length; j++) {
          Console.Write($"{m[i][j]}  ");
        }
        Console.WriteLine();
      }
    }

    public void SetZeroes(int[][] matrix) {
      int n = matrix.Length, m = matrix[0].Length;
      bool resetFirstColumn = false;
      for (int i = 0; i < n; ++i) {
        resetFirstColumn = resetFirstColumn || matrix[i][0] == 0;
        for (int j = 1; j < m; ++j) {
          if (matrix[i][j] == 0) {
            matrix[i][0] = matrix[0][j] = 0;
          }
        }
      }
      for (int i = 1; i < n; ++i) {
        for (int j = 1; j < m; ++j) {
          if (matrix[i][0] == 0 || matrix[0][j] == 0) {
            matrix[i][j] = 0;
          }
        }
      }
      if (matrix[0][0] == 0) {
        for (int j = 0; j < m; ++j) {
          matrix[0][j] = 0;
        }
      }
      if (resetFirstColumn) {
        for (int i = 0; i < n; ++i) {
          matrix[i][0] = 0;
        }
      }
    }
  }
}
