using System;

namespace FindPeakElement {
  class Program {
    static void Main(string[] args) {
      Console.WriteLine("Hello World!");
    }

    #region MyRegion

    public class Solution {
      public int FindPeakElement(int[] nums) {
        for (int i = 0; i < nums.Length - 1; ++i) {
          if (nums[i] > nums[i + 1]) {
            return i;
          }
        }
        return nums.Length - 1;
      }
    }

    #endregion
  }
}
