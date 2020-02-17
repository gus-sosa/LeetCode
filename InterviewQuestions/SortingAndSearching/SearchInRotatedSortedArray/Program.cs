using System;

namespace SearchInRotatedSortedArray {
  class Program {
    static void Main(string[] args) {
      var s = new Solution();
      Console.WriteLine(s.Search(new int[] { 5, 1, 2, 3, 4 }, 1) == 1);
      Console.WriteLine(s.Search(new int[] { 5, 1, 3 }, 5) == 0);
      Console.WriteLine(s.Search(new int[] { 4, 5, 2, 3 }, 2) == 2);
      Console.WriteLine(s.Search(new int[] { 4, 5, 2, 3 }, 3) == 3);
      Console.WriteLine(s.Search(new int[] { 4, 5, 2, 3 }, 4) == 0);
      Console.WriteLine(s.Search(new int[] { 4, 5, 2, 3 }, 5) == 1);
      Console.WriteLine(s.Search(new int[] { 4, 5, 2, 3 }, 6) == -1);
      Console.WriteLine(s.Search(new int[] { 4, 5, 2, 3 }, 1) == -1);
      Console.WriteLine(s.Search(new int[] { 1, 2, 3, 4, 0 }, 0) == 4);
      Console.WriteLine(s.Search(new int[] { 1, 2, 3, 4, 0 }, 4) == 3);
      Console.WriteLine(s.Search(new int[] { 1, 2, 3, 4, 0 }, 3) == 2);
      Console.WriteLine(s.Search(new int[] { 1, 2, 3, 4, 0 }, 2) == 1);
      Console.WriteLine(s.Search(new int[] { 1, 2, 3, 4, 0 }, 1) == 0);
      Console.WriteLine(s.Search(new int[] { 1, 2, 3, 4, 0 }, 6) == -1);
    }

    #region MyRegion


    public class Solution {
      public int Search(int[] nums, int target) {
        return Search(nums, target, 0, nums.Length - 1);
      }

      private int Search(int[] nums, int target, int iStart, int iEnd) {
        if (iStart > iEnd) {
          return -1;
        }

        int middle = (iStart + iEnd) / 2;
        if (nums[middle] == target) {
          return middle;
        }
        if (nums[iStart] == target) {
          return iStart;
        }
        if (nums[iEnd] == target) {
          return iEnd;
        }

        if (nums[iStart] < nums[iEnd]) {
          return target < nums[middle] ?
            Search(nums, target, iStart, middle - 1) :
            Search(nums, target, middle + 1, iEnd);
        } else {
          if (nums[iStart] < nums[middle]) {
            return target < nums[iStart] || target > nums[middle] ?
              Search(nums, target, middle + 1, iEnd) :
              Search(nums, target, iStart, middle - 1);
          } else {
            return nums[iEnd] < target || target < nums[middle] ?
              Search(nums, target, iStart, middle - 1) :
              Search(nums, target, middle + 1, iEnd);
          }
        }
      }
    }


    #endregion
  }
}
