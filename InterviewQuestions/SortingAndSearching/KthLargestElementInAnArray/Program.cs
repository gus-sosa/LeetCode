using System;
using System.Collections.Generic;

namespace KthLargestElementInAnArray {
  class Program {
    static void Main(string[] args) {
      Console.WriteLine("Hello World!");
    }

    #region MyRegion

    public class Solution {
      public int FindKthLargest(int[] nums, int k) {
        Array.Sort(nums);
        return nums[nums.Length - k];
      }
    }


    #endregion
  }
}
