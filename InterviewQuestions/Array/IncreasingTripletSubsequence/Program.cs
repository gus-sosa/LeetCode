using System;
using System.Collections;
using System.Collections.Generic;

namespace IncreasingTripletSubsequence {
  class Program {
    static void Main(string[] args) {
      var p = new Program();
      Console.WriteLine(p.IncreasingTriplet(new int[] { 1, 5, 4, 8, 2, 1, 9, 4 }) == true);
      Console.WriteLine(p.IncreasingTriplet(new int[] { 5, 6, 2, 8 }) == true);
      Console.WriteLine(p.IncreasingTriplet(new int[] { 1, 2, 3, 4, 5 }) == true);
      Console.WriteLine(p.IncreasingTriplet(new int[] { 5, 4, 3, 2, 1 }) == false);
      Console.WriteLine(p.IncreasingTriplet(new int[] { 5, 6, 4, 5, 3, 4, 2, 3 }) == false);
      Console.WriteLine(p.IncreasingTriplet(new int[] { 5, 6, 4, 5, 3, 4, 2, 8 }) == true);
    }

    public bool IncreasingTriplet(int[] nums) {
      if (nums == null || nums.Length < 3) {
        return false;
      }
      int start = nums[0], mid = nums[0];
      bool flag = false, noMid = true;
      for (int i = 0; !flag && i < nums.Length; ++i) {
        if (nums[i] < start) {
          start = nums[i];
        } else if (nums[i] > start) {
          if (noMid || nums[i] < mid) {
            noMid = false;
            mid = nums[i];
          } else if (nums[i] > mid) {
            flag = true;
          }
        }
      }
      return flag;
    }
  }
}
