using System;
using System.Linq;

namespace LongestIncreasingSubsequence {
  class Program {
    static void Main(string[] args) {
      var s = new Solution();
      Console.WriteLine(s.LengthOfLIS(new int[] { 10, 9, 2, 5, 3, 7, 101, 18 }));
    }

    #region MyRegion

    public class Solution {
      public int LengthOfLIS(int[] nums) {
        if (nums == null || nums.Length == 0) {
          return 0;
        }
        var dps = new int[nums.Length];
        Array.Fill(dps, 1);
        for (int i = 1, j; i < nums.Length; ++i) {
          for (j = i - 1; j >= 0; --j) {
            if (nums[j] < nums[i]) {
              dps[i] = Math.Max(dps[i], dps[j] + 1);
            }
          }
        }
        return dps.Max();
      }
    }


    #endregion


  }
}
