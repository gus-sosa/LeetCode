using System;

namespace MaximalSquare {
  class Program {
    static void Main(string[] args) {
      var s = new Solution();
      //var matrix = new char[4][] {
      //  new char[5]{ '1','0','1','0','0'},
      //  new char[5]{ '1','0','1','1','1'},
      //  new char[5]{ '1','1','1','1','1'},
      //  new char[5]{ '1','0','0','1','0'}
      //};
      var matrix = new char[5][] {
        new char[4]{'0', '0', '0', '1'},
        new char[4]{'1', '1', '0', '1'},
        new char[4]{'1', '1', '1', '1'},
        new char[4]{'0', '1', '1', '1'},
        new char[4]{'0', '1', '1', '1'}
      };
      Console.WriteLine(s.MaximalSquare(matrix));
    }

    #region MyRegion

    public class Solution {
      const int ONE = '1';
      public int MaximalSquare(char[][] matrix) {
        if (matrix.Length == 0 || matrix[0].Length == 0) {
          return 0;
        }
        int n = matrix.Length, m = matrix[0].Length;
        int maxGlobal = 0;
        for (int i = 0; i < n; ++i) {
          for (int j = 0; j < m; ++j) {
            if (matrix[i][j] == ONE) {
              maxGlobal = Math.Max(maxGlobal, squareBfs(matrix, i, j));
            }
          }
        }
        return maxGlobal * maxGlobal;
      }

      private int squareBfs(char[][] matrix, int i, int j) {
        bool validRowCol;
        int i1 = i, j1 = j, count = 0, step;
        while (i1 < matrix.Length && j1 < matrix[0].Length) {
          validRowCol = true;
          for (step = 0; i1 - step >= i && j1 - step >= j && validRowCol; ++step) {
            validRowCol = validRowCol && matrix[i1 - step][j1] == ONE && matrix[i1][j1 - step] == ONE;
          }
          if (!validRowCol) {
            break;
          }
          ++count;
          ++i1;
          ++j1;
        }
        return count;
      }
    }

    #endregion
  }
}
