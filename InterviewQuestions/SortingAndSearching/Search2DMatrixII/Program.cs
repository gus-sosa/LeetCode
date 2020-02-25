using System;

namespace Search2DMatrixII {
  class Program {
    static void Main(string[] args) {
      var s = new Solution();
      var matrix = new int[,] {
        {1, 4, 7, 11, 15},
        {2, 5, 8, 12, 19},
        {3, 6, 9, 16, 22},
        {10, 13, 14, 17, 24},
        {18, 21, 23, 26, 30}
      };
      for (int i = 1; i < 20; ++i) {
        Console.WriteLine($"{i}={s.SearchMatrix(matrix, i) == true}");
      }
      Console.WriteLine($"{20}={s.SearchMatrix(matrix, 20) == false}");
      Console.WriteLine($"{21}={s.SearchMatrix(matrix, 21) == true}");
      Console.WriteLine($"{22}={s.SearchMatrix(matrix, 22) == true}");
      Console.WriteLine($"{23}={s.SearchMatrix(matrix, 23) == true}");
      Console.WriteLine($"{24}={s.SearchMatrix(matrix, 24) == true}");
      Console.WriteLine($"{25}={s.SearchMatrix(matrix, 25) == false}");
      Console.WriteLine($"{26}={s.SearchMatrix(matrix, 26) == true}");
      for (int i = 27; i < 50; ++i) {
        Console.WriteLine($"{i}={s.SearchMatrix(matrix, i) == (i == 30)}");
      }
    }

    #region MyRegion


    public class Solution {
      private int target;
      private int[,] matrix;

      public bool SearchMatrix(int[,] matrix, int target) {
        this.matrix = matrix;
        this.target = target;
        return SearchMatrix(0, 0, matrix.GetLength(0) - 1, matrix.GetLength(1) - 1);
      }

      private bool SearchMatrix(int row1, int col1, int row2, int col2) {
        if (row2 - row1 < 2 && col2 - col1 < 2) {
          return IsTargetInMatrixRange(matrix, row1, col1, row2, col2);
        }

        int rowMiddle = GetMiddle(row1, row2);
        int colMiddle = GetMiddle(col1, col2);
        if (target == matrix[rowMiddle, colMiddle]) {
          return true;
        }
        if (target < matrix[rowMiddle, colMiddle]) {
          return SearchMatrix(row1, col1, rowMiddle, colMiddle) ||
            SearchMatrix(rowMiddle, col1, row2, colMiddle) ||
            SearchMatrix(row1, colMiddle, rowMiddle, col2);
        } else {
          return SearchMatrix(row1, colMiddle, rowMiddle, col2) ||
            SearchMatrix(rowMiddle, colMiddle, row2, col2) ||
            SearchMatrix(rowMiddle, col1, row2, colMiddle);
        }
      }

      private int GetMiddle(int v1, int v2) {
        return (v1 + v2) / 2;
      }

      private bool IsTargetInMatrixRange(int[,] matrix, int row1, int col1, int row2, int col2) {
        int currentCol = 0;
        while (row1 <= row2) {
          for (currentCol = col1; currentCol <= col2; ++currentCol) {
            if (matrix[row1, currentCol] == target) {
              return true;
            }
          }
          ++row1;
        }
        return false;
      }
    }


    #endregion
  }
}
