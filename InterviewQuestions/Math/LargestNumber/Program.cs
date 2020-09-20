using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace LargestNumber {
  class Program {
    static void Main(string[] args) {
      var s = new Solution();
      int[] input;

      input = new int[] { 10, 2 };
      Console.WriteLine(s.LargestNumber(input));
      Console.WriteLine(s.LargestNumber(input) == "210");

      input = new int[] { 3, 30, 34, 5, 9 };
      Console.WriteLine(s.LargestNumber(input));
      Console.WriteLine(s.LargestNumber(input) == "9534330");
    }

    #region MyRegion


    public class Solution {
      public string LargestNumber(int[] nums) {
        string[] strNumbs = nums.Select(i => Convert.ToString(i)).ToArray();
        Array.Sort(strNumbs, new NumSorter());
        return strNumbs.Aggregate("", (acc, curr) => acc + curr);
      }
    }

    internal class NumSorter : IComparer<string> {
      public int Compare(string x, string y) {
        return -(x + y).CompareTo(y + x);
      }
    }

    #endregion
  }


}
