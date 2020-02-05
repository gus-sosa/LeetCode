using System;

namespace SortColors {
  class Program {
    static void Main(string[] args) {
      var s = new Solution();
      var arr1 = new int[] { 0, 1, 0, 2, 0, 2, 2, 1, 1, 0, 2 };
      s.SortColors(arr1);
      PrintArray(arr1);
      arr1 = new int[] { 1, 0, 2 };
      s.SortColors(arr1);
      PrintArray(arr1);
      arr1 = new int[] { 2, 0, 1 };
      s.SortColors(arr1);
      PrintArray(arr1);
    }

    private static void PrintArray(int[] arr) {
      foreach (var item in arr) {
        Console.Write($"{item}   ");
      }
      Console.WriteLine();
    }

    #region MyRegion


    public class Solution {
      public void SortColors(int[] nums) {
        for (int start = 0, end = nums.Length - 1, middle = start; middle <= end; ++middle) {
          if (nums[middle] == 0) {
            swap(nums, start++, middle);
          } else if (nums[middle] == 2) {
            swap(nums, middle--, end--);
          }
        }
      }

      public void swap(int[] nums, int i1, int i2) {
        int tmp = nums[i1];
        nums[i1] = nums[i2];
        nums[i2] = tmp;
      }
    }


    #endregion
  }
}
