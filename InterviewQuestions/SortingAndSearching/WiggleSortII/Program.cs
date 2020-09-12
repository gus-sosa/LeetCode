using System;
using System.Runtime.InteropServices.ComTypes;
using System.Runtime.InteropServices.WindowsRuntime;

namespace WiggleSortII {
  class Program {
    static void Main(string[] args) {
      var s = new Solution();

      var input = new int[] { 1, 5, 1, 1, 6, 4 };
      printArray(input);
      s.WiggleSort(input);
      printArray(input);
      Console.WriteLine();
      input = new int[] { 1, 3, 2, 2, 3, 1 };
      printArray(input);
      s.WiggleSort(input);
      printArray(input);
      Console.WriteLine();
      input = new int[] { 4, 5, 5, 6 };
      printArray(input);
      s.WiggleSort(input);
      printArray(input);
    }

    private static void printArray(int[] vs) {
      foreach (var item in vs) {
        Console.Write($"{item} ");
      }
      Console.WriteLine();
    }
  }

  #region MyRegion


  public class Solution {
    public void WiggleSort(int[] nums) {
      Array.Sort(nums);
      var retval = new int[nums.Length];
      int m = nums.Length / 2 + (nums.Length % 2 == 0 ? -1 : 0), k = 0;
      for (int i = m; i >= 0; --i, k += 2) {
        retval[k] = nums[i];
      }
      k = 1;
      for (int i = nums.Length - 1; i >= m + 1; --i, k += 2) {
        retval[k] = nums[i];
      }
      for (int l = 0; l < nums.Length; ++l) {
        nums[l] = retval[l];
      }
    }
  }


  #endregion
}
