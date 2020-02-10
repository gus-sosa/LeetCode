using System;
using System.Linq;

namespace SearchForARange {
  static class MyClass {
    public static bool EqualsTo(this int[] arr, int[] arr1) => arr.Length == arr1.Length && Enumerable.Zip(arr, arr1).All(i => i.First == i.Second);
  }

  class Program {
    static void Main(string[] args) {
      var s = new Solution();
      ///testing binarySearchL
      Console.WriteLine(s.binarySearch(new int[] { 5, 7, 7, 8, 8, 10 }, 0, 5, 8) == 3);
      Console.WriteLine(s.binarySearch(new int[] { 5, 7, 7, 8, 8, 10 }, 0, 5, 6) == -1);
      Console.WriteLine(s.binarySearch(new int[] { 5, 7, 7, 8, 8 }, 0, 4, 8) == 3);
      ///testing search range
      Console.WriteLine(s.SearchRange(new int[] { 5, 7, 7, 8, 8, 10 }, 8).EqualsTo(new int[] { 3, 4 }));
      Console.WriteLine(s.SearchRange(new int[] { 5, 7, 7, 8, 8, 10 }, 6).EqualsTo(new int[] { -1, -1 }));
      Console.WriteLine(s.SearchRange(new int[] { 5, 7, 7, 8, 8 }, 8).EqualsTo(new int[] { 3, 4 }));
      Console.WriteLine(s.SearchRange(new int[] { 5, 7, 7, 8, 8 }, 6).EqualsTo(new int[] { -1, -1 }));
      Console.WriteLine(s.SearchRange(new int[] { 5, 7, 7, 8, 8, 10 }, 5).EqualsTo(new int[] { 0, 0 }));
      Console.WriteLine(s.SearchRange(new int[] { 5, 7, 7, 8, 8, 10 }, 7).EqualsTo(new int[] { 1, 2 }));
      Console.WriteLine(s.SearchRange(new int[] { 5, 7, 7, 8, 8 }, 7).EqualsTo(new int[] { 1, 2 }));
      Console.WriteLine(s.SearchRange(new int[] { 5, 7, 7, 7, 8, 8 }, 5).EqualsTo(new int[] { 0, 0 }));
      Console.WriteLine(s.SearchRange(new int[] { 5 }, 5).EqualsTo(new int[] { 0, 0 }));
      Console.WriteLine(s.SearchRange(new int[] { 5 }, 14).EqualsTo(new int[] { -1, -1 }));
      Console.WriteLine(s.SearchRange(new int[] { 5, 6 }, 14).EqualsTo(new int[] { -1, -1 }));
      Console.WriteLine(s.SearchRange(new int[] { 5, 6 }, 6).EqualsTo(new int[] { 1, 1 }));
      Console.WriteLine(s.SearchRange(new int[] { 5, 6 }, 5).EqualsTo(new int[] { 0, 0 }));
      Console.WriteLine(s.SearchRange(new int[] { 5, 6, 7 }, 5).EqualsTo(new int[] { 0, 0 }));
      Console.WriteLine(s.SearchRange(new int[] { 5, 6, 7 }, 6).EqualsTo(new int[] { 1, 1 }));
      Console.WriteLine(s.SearchRange(new int[] { 5, 6, 7 }, 7).EqualsTo(new int[] { 2, 2 }));
      Console.WriteLine(s.SearchRange(new int[] { 5, 6, 7 }, 8).EqualsTo(new int[] { -1, -1 }));
    }

    #region MyRegion

    public class Solution {
      public int[] SearchRange(int[] nums, int target) {
        int left = binarySearch(nums, 0, nums.Length - 1, target);
        if (left != -1) {
          return new int[] { left, binarySearch(nums, 0, nums.Length - 1, target, false) };
        }
        return new int[] { -1, -1 };
      }

      public int binarySearch(int[] nums, int iStart, int iEnd, int target, bool left = true) {
        if (iStart > iEnd) {
          return -1;
        }
        if (iStart == iEnd) {
          return nums[iStart] == target ? iStart : -1;
        } else {
          int mid = (iStart + iEnd) / 2;
          if (nums[mid] == target) {
            if (left) {
              return binarySearch(nums, iStart, mid, target, left);
            } else {
              if (nums[iEnd] == target) {
                return iEnd;
              }
              return binarySearch(nums, mid, iEnd - 1, target, left);
            }
          }
          return nums[mid] < target ? binarySearch(nums, mid + 1, iEnd, target, left) : binarySearch(nums, iStart, mid, target, left);
        }
      }
    }

    #endregion
  }
}
