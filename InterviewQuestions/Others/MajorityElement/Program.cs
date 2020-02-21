using System;
using System.Collections.Generic;

namespace MajorityElement {
  class Program {
    static void Main(string[] args) {
      var s = new Solution();
      Console.WriteLine(s.MajorityElement(new int[] { 3, 2, 3 }) == 3);
    }

    #region MyRegion


    public class Solution {
      public int MajorityElement(int[] nums) {
        var dict = new Dictionary<int, int>();
        foreach (var item in nums) {
          if (!dict.ContainsKey(item)) {
            dict[item] = 0;
          }
          ++dict[item];
        }
        int element = 0, count = int.MinValue;
        foreach (var item in dict) {
          if (item.Value > count) {
            element = item.Key;
            count = item.Value;
          }
        }
        return element;
      }
    }


    #endregion


  }
}
