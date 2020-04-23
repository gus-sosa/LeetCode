using System;

namespace FirstMissingPositive {
  class Program {
    static void Main(string[] args) {
      var s = new Solution();
      var arr = new int[] { 1, 2, 7, 8, 9, 11, 12 };
      Console.WriteLine(s.FirstMissingPositive(arr));
    }
  }

  public class Solution {
    public int FirstMissingPositive(int[] nums) {
      int n = nums.Length;
      for (int i = 0; i < n; ++i) {
        if (nums[i] <= 0 || nums[i] > n)
          nums[i] = n + 1;
      }
      for (int j = 0; j < n; ++j) {
        int temp = Math.Abs(nums[j]);
        if (temp <= n) {
          int index = temp - 1;
          nums[index] = -Math.Abs(nums[index]);
        }
      }
      for (int p = 0; p < n; ++p) {
        if (nums[p] > 0)
          return p + 1;
      }
      return n + 1;
    }
  }
}
