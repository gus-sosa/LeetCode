using System;
using System.Collections.Generic;
using System.Linq;

namespace LongestConsecutiveSequence {
  class Program {
    static void Main(string[] args) {
      var testCases = new Tuple<int, int[]>[]{
        Tuple.Create(4, new int[] { 100, 4, 200, 1, 3, 2 }),
        Tuple.Create(5, new int[] { 5, 100, 4, 201, 200, 1, 3, 2 }),
        Tuple.Create(3,new int[] { 1, 2, 3 }),
        Tuple.Create(5,new int[] { 1, 2, 3, 5, 1, 2, 3, 4 }),
        Tuple.Create(1,new int[] { 1, 5 }),
        Tuple.Create(0,new int[0]),
        Tuple.Create(3,new int[]{ 0,0,1,-1})
      };
      var s = new Solution();
      for (int i = 0; i < testCases.Length; i++) {
        Console.WriteLine($"test case {i + 1}");
        bool result = s.LongestConsecutive(testCases[i].Item2) == testCases[i].Item1;
        Console.WriteLine(result ? "passed" : "failed");
      }
    }
  }

  #region MyRegion


  public class Solution {
    public int LongestConsecutive(int[] nums) {
      if (nums.Length < 2) {
        return nums.Length;
      }
      var numPos = GetNumPos(nums);
      var numReferences = GetNumReferences(nums, numPos);
      int[] markers = Enumerable.Repeat(1, nums.Length).ToArray();
      for (int i = 0; i < nums.Length; ++i) {
        if (numReferences[i] != -1 && markers[i] == 1) {
          dfs(numReferences, markers, i);
        }
      }
      return markers.Max();
    }

    private void dfs(int[] numReferences, int[] markers, int pos) {
      if (numReferences[pos] == -1 || markers[pos] != 1) {
        return;
      }
      dfs(numReferences, markers, numReferences[pos]);
      markers[pos] = 1 + markers[numReferences[pos]];
    }

    private static int[] GetNumReferences(int[] nums, Dictionary<int, int> numPos) {
      var numReferences = Enumerable.Repeat(-1, nums.Length).ToArray();
      for (int i = 0; i < nums.Length; ++i) {
        if (numPos.ContainsKey(nums[i] + 1)) {
          numReferences[i] = numPos[nums[i] + 1];
        }
      }
      return numReferences;
    }

    private static Dictionary<int, int> GetNumPos(int[] nums) {
      var numPos = new Dictionary<int, int>();
      for (int i = 0; i < nums.Length; ++i) {
        if (!numPos.ContainsKey(nums[i])) {
          numPos[nums[i]] = i;
        }
      }
      return numPos;
    }
  }


  #endregion
}
