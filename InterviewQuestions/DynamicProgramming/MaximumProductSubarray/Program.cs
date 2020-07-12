using System;
using System.Collections.Generic;

namespace MaximumProductSubarray {
  class Program {
    static void Main(string[] args) {
      var s = new Solution();
      Console.WriteLine(s.MaxProduct(new int[] { 2, 3, -2, 4 }) == 6);
      Console.WriteLine(s.MaxProduct(new int[] { -2, 0, -1 }) == 0);
      Console.WriteLine(s.MaxProduct(new int[] { 0, 2 }) == 2);
      Console.WriteLine(s.MaxProduct(new int[] { 2, 0 }) == 2);
      Console.WriteLine(s.MaxProduct(new int[] { 2, 0, 3 }) == 3);
    }
  }

  #region MyRegion


  public class Solution {
    public int MaxProduct(int[] nums) {
      if (nums.Length == 1) {
        return nums[0];
      }

      var zerosPos = new List<int>();
      for (int i = 0; i < nums.Length; ++i) {
        if (nums[i] == 0) {
          zerosPos.Add(i);
        }
      }

      int max = nums[0];
      if (zerosPos.Count > 0) {
        max = Math.Max(max, 0);
        int startArray = 0, endArray = 0;
        if (nums[nums.Length - 1] != 0) {
          zerosPos.Add(nums.Length);
        }
        for (int i = 0; i < zerosPos.Count; ++i) {
          endArray = zerosPos[i] - 1;
          if (startArray <= endArray) {
            max = Math.Max(max, MaxProductNonZeros(buildArray(nums, startArray, endArray)));
          }
          startArray = endArray + 2;
        }
      } else {
        max = Math.Max(max, MaxProductNonZeros(nums));
      }

      return max;
    }

    private int[] buildArray(int[] nums, int startArray, int endArray) {
      int[] arr = new int[endArray - startArray + 1];
      for (int i = 0; i < arr.Length; ++i, ++startArray) {
        arr[i] = nums[startArray];
      }
      return arr;
    }

    private int MaxProductNonZeros(int[] nums) {
      if (nums.Length == 1) {
        return nums[0];
      }

      int[] t = nums;
      nums = new int[nums.Length + 1];
      nums[0] = 1;
      Array.Copy(t, 0, nums, 1, t.Length);
      var negatives = new List<int>();
      int[] prod = new int[nums.Length];
      prod[0] = 1;
      for (int i = 1; i < nums.Length; ++i) {
        if (nums[i] < 0) {
          negatives.Add(i);
        }
        prod[i] = nums[i] * prod[i - 1];
      }

      if (prod[prod.Length - 1] > 0) {
        return prod[prod.Length - 1];
      }

      int max = prod[prod.Length - 1];
      for (int i = 0, neg = 0, negPos = 0; i < negatives.Count; ++i) {
        negPos = negatives[i];
        neg = nums[negPos];
        if (negPos != 0) {
          max = Math.Max(max, prod[negPos] / nums[negPos]);
        }
        if (negPos != nums.Length - 1) {
          max = Math.Max(max, prod[prod.Length - 1] / prod[negPos]);
        }
      }
      return max;
    }
  }



  #endregion

}