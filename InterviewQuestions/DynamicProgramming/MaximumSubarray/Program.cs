using System;

namespace MaximumSubarray {
  class Program {
    static void Main(string[] args) {
      var p = new Program();
      Console.WriteLine(p.MaxSubArray(new int[] { -2, 1, -3, 4, -1, 2, 1, -5, 4 }) == 6);
      Console.WriteLine(p.MaxSubArray(new int[] { 1 }) == 1);
      Console.WriteLine(p.MaxSubArray(new int[] { -1 }) == -1);
    }

    public int MaxSubArray(int[] nums) {
      int size = nums.Length;
      int max_so_far = int.MinValue,
          max_ending_here = 0;

      for (int i = 0; i < size; i++) {
        max_ending_here = max_ending_here + nums[i];

        if (max_so_far < max_ending_here)
          max_so_far = max_ending_here;

        if (max_ending_here < 0)
          max_ending_here = 0;
      }

      return max_so_far;
    }
  }
}
