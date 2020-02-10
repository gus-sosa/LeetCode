using System;

namespace SearchForARange {
  class Program {
    static void Main(string[] args) {
      Console.WriteLine("Hello World!");
    }

    #region MyRegion

    public class Solution {
      public int[] SearchRange(int[] nums, int target) {
        int[] result = new int[2] { -1, -1 };
        for (int i = 0; i < nums.Length; ++i) {
          if (nums[i] == target) {
            if (result[0] == -1) {
              result[0] = result[1] = i;
            } else {
              result[1] = i;
            }
          }
        }
        return result;
      }
    }

    #endregion
  }
}
