using System;
using System.Collections.Generic;
using Utility;

namespace TwoSum
{
  class Program
  {
    public int[] TwoSum(int[] nums, int target) {
      var hash = new Dictionary<int, int>();
      for (int i = 0; i < nums.Length; i++) {
        if (hash.ContainsKey(target - nums[i])) {
          var pos = hash[target - nums[i]];
          if (pos != i) {
            return new int[] { Math.Min(i, pos), Math.Max(i, pos) };
          }
        } else if (!hash.ContainsKey(nums[i])) {
          hash.Add(nums[i], i);
        }
      }
      return new int[0];
    }

    static void Main(string[] args) {
      var p = new Program();
      Console.WriteLine(p.TwoSum(new[] { 2, 7, 11, 15 }, 9).SameArrays(new[] { 0, 1 }) ? "OK" : "FAIL");
      Console.WriteLine(p.TwoSum(new[] { 3, 2, 4 }, 6).SameArrays(new[] { 1, 2 }) ? "OK" : "FAIL");
    }
  }
}
