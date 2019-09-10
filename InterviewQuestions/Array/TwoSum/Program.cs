using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility;

namespace TwoSum
{
  class Program
  {
    public int[] TwoSum(int[] nums, int target) {
      int[] pos = Enumerable.Range(0, nums.Length).ToArray();
      Array.Sort(nums, pos);
      int s = 0, e = nums.Length - 1;
      while (s < e) {
        if (nums[s] + nums[e] == target) {
          break;
        }

        if (nums[s] + nums[e] < target) {
          ++s;
        } else {
          --e;
        }
      }
      return new int[] { pos[s], pos[e] };
    }

    static void Main(string[] args) {
      var p = new Program();
      Console.WriteLine(p.TwoSum(new[] { 2, 7, 11, 15 }, 9).SameArrays(new[] { 0, 1 }) ? "OK" : "FAIL");
      Console.WriteLine(p.TwoSum(new[] { 3, 2, 4 }, 6).SameArrays(new[] { 1, 2 }) ? "OK" : "FAIL");
    }
  }
}
