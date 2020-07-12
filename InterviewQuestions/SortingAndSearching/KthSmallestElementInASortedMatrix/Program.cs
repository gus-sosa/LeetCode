using System;
using System.Data;

namespace KthSmallestElementInASortedMatrix {
  class Program {
    static void Main(string[] args) {
      Console.WriteLine("Hello World!");
    }
  }

  #region MyRegion

  public class Solution {
    public int KthSmallest(int[][] matrix, int k) {
      int[] sortedArr = matrix[0];
      for (int i = 1; i < matrix.Length; ++i) {
        sortedArr = merge(sortedArr, matrix[i]);
      }
      return sortedArr[k - 1];
    }

    private int[] merge(int[] arr1, int[] arr2) {
      int[] result = new int[arr1.Length + arr2.Length];
      for (int i = 0, j = 0, k = 0; i < result.Length; ++i) {
        if (j < arr1.Length && k < arr2.Length) {
          result[i] = arr1[j] < arr2[k] ? arr1[j++] : arr2[k++];
        } else if (j < arr1.Length) {
          result[i] = arr1[j++];
        } else {
          result[i] = arr2[k++];
        }
      }
      return result;
    }
  }

  #endregion

}
