using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualBasic.FileIO;

namespace SlidingWindowMaximum
{
  class Program
  {
    static void Main(string[] args) {
      var s = new Solution();
      var arr = new int[] { 1, 3, -1, -3, 5, 3, 6, 7 };
      var r = s.MaxSlidingWindow(arr, 3);
      foreach (var item in r) {
        Console.WriteLine(item);
      }
    }
  }

  #region MyRegion

  public class Solution
  {
    public int[] MaxSlidingWindow(int[] nums, int k) {
      var numCount = new Dictionary<int, int>();
      var numSet = new HashSet<int>();
      var retVal = new List<int>();
      for (int i = 0, kOriginal = k; i < nums.Length; ++i) {
        insert(numCount, numSet, nums[i]);
        --k;
        if (k < 0) {
          delete(numCount, numSet, nums[i - kOriginal]);
        }
        if (k <= 0) {
          retVal.Add(numSet.Max());
        }
      }
      return retVal.ToArray();
    }

    private void delete(Dictionary<int, int> numCount, HashSet<int> numSet, int v) {
      numCount[v] -= 1;
      if (numCount[v] == 0) {
        numCount.Remove(v);
        numSet.Remove(v);
      }
    }

    private void insert(Dictionary<int, int> numCount, HashSet<int> numSet, int v) {
      if (numCount.ContainsKey(v)) {
        numCount[v] += 1;
      } else {
        numCount[v] = 1;
        numSet.Add(v);
      }
    }
  }


  #endregion
}
