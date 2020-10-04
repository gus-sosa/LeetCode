using System;
using System.IO;
using System.Linq;

namespace BurstBalloons {
  public class Program {
    static void Main(string[] args) {
      var s = new Solution();

      var arr = new int[] { 3, 1, 5, 8 };
      Console.WriteLine(s.MaxCoins(arr) == 167);
    }
  }

  #region MyRegion


  public class Solution {
    public int MaxCoins(int[] nums) {
      nums = new int[] { 1 }.Concat(nums.Concat(new int[] { 1 })).ToArray();
      var map = new int[nums.Length, nums.Length];
      for (int l = 1, start = 0, end; l < nums.Length - 1; ++l) {
        for (start = 1; start + l - 1 < nums.Length - 1; ++start) {
          end = start + l - 1;
          foreach (var posToBurst in Enumerable.Range(start, l)) {
            map[start, end] = Math.Max(map[start, end], nums[start - 1] * nums[posToBurst] * nums[end + 1] + map[start, posToBurst - 1] + map[posToBurst + 1, end]);
          }
        }
      }
      return map[1, nums.Length - 2];
    }
  }


  #endregion
}
