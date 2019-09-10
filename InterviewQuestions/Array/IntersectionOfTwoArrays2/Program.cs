using System;
using System.Collections.Generic;
using System.Linq;

namespace IntersectionOfTwoArrays2
{
  class Program
  {
    public int[] Intersect(int[] nums1, int[] nums2) {
      Array.Sort(nums1);
      Array.Sort(nums2);
      var result = new List<int>();
      int i1 = 0, i2 = 0;
      while (i1 < nums1.Length && i2 < nums2.Length) {
        if (nums1[i1] == nums2[i2]) {
          result.Add(nums1[i1]);
          ++i1; ++i2;
        } else if (nums1[i1] < nums2[i2]) {
          ++i1;
        } else {
          ++i2;
        }
      }
      return result.ToArray();
    }

    static void Main(string[] args) {
      var p = new Program();
      Console.WriteLine(CompareArrays(p.Intersect(new[] { 1, 2, 2, 1 }, new[] { 2, 2 }), new[] { 2, 2 }) ? "OK" : "FAIL");
      Console.WriteLine(CompareArrays(p.Intersect(new[] { 4, 9, 5 }, new[] { 9, 4, 9, 8, 4 }), new[] { 4, 9 }) ? "OK" : "FAIL");
    }

    private static bool CompareArrays(int[] arr1, int[] arr2) {
      if (arr1.Length != arr2.Length) {
        return false;
      }
      for (int i = 0; i < arr2.Length; i++) {
        if (arr1[i] != arr2[i]) {
          return false;
        }
      }
      return true;
    }
  }
}
