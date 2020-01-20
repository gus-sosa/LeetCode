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
      int sum = nums[0], partialSum = 0;
      for (int i = 0; i < nums.Length; ++i) {
        partialSum = nums[i];
        if (partialSum > sum) {
          sum = partialSum;
        }
        for (int j = i + 1; j < nums.Length; ++j) {
          partialSum += nums[j];
          if (partialSum > sum) {
            sum = partialSum;
          }
        }
      }
      return sum;
    }
  }
}
