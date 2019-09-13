using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace RotateImage {
  class Program {
    public void Rotate(int[][] matrix) {
      //Debugger.Launch();
      int l = matrix.Length == 1 ? 0 : Convert.ToInt32(Math.Ceiling(matrix.Length / 2d));
      for (int i = 0; i < l; ++i) {
        for (int j = i; j < matrix.Length - i - 1; ++j) {
          List<int[]> posToSwitch = SelectPositionsToSwitch(matrix, i, j);
          foreach (var pos in posToSwitch) {
            matrix[pos[0]][pos[1]] = pos[2];
          }
        }
      }
    }

    private List<int[]> SelectPositionsToSwitch(int[][] matrix, int row, int col) {
      int row1 = row, row2 = col, row3 = matrix.Length - row - 1, row4 = matrix.Length - 1 - col;
      int col1 = col, col2 = matrix.Length - row - 1, col3 = matrix.Length - 1 - col, col4 = row;
      return new List<int[]>() {
        new int[]{ row1,col1,matrix[row4][col4] },
        new int[]{ row2,col2,matrix[row1][col1] },
        new int[]{ row3,col3,matrix[row2][col2] },
        new int[]{ row4,col4,matrix[row3][col3] }
      };
    }

    static void Main(string[] args) {
      var matrix = BuildMatrix();
      new Program().Rotate(matrix);
      var expectedMatrix = BuildMatrix();
      Console.WriteLine(SameMatrix(matrix, expectedMatrix));
    }

    private static bool SameMatrix(int[][] matrix, int[][] expectedMatrix) {
      int l = matrix.Length;
      for (int i = 0; i < l; i++) {
        int[] arr = matrix[i], expectedArr = expectedMatrix[i];
        for (int j = 0; j < l; j++) {
          if (arr[j] != expectedArr[j]) {
            return false;
          }
        }
      }
      return true;
    }

    private static int[][] BuildMatrix() {
      var firstRow = Console.ReadLine().Split().Select(int.Parse).ToArray();
      var matrix = new int[firstRow.Length][];
      matrix[0] = firstRow;
      for (int i = 1; i < firstRow.Length; i++) {
        var row = Console.ReadLine().Split().Select(int.Parse).ToArray();
        matrix[i] = row;
      }
      return matrix;
    }
  }
}
