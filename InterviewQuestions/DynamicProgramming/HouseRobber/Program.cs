using System;
using System.Linq;

namespace HouseRobber {
  class Program {
    static void Main(string[] args) {
      var p = new Program();
      Console.WriteLine(p.Rob(new int[] { 1, 2, 3, 1 }) == 4);
      Console.WriteLine(p.Rob(new int[] { 2, 7, 9, 3, 1 }) == 12);
      Console.WriteLine(p.Rob(new int[0]) == 0);
    }

    public int Rob(int[] nums) {
      if (nums.Length == 0) {
        return 0;
      }
      var maxs = new int[nums.Length];
      maxs[0] = nums[0];
      if (nums.Length > 1) {
        maxs[1] = Math.Max(nums[0], nums[1]);
      }
      if (nums.Length > 2) {
        for (int i = 2; i < nums.Length; ++i) {
          maxs[i] = Math.Max(maxs[i - 1], nums[i] + maxs[i - 2]);
        }
      }
      return maxs.Max();
    }
  }
}
