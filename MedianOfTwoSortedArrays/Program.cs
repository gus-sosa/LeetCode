using System;
using System.Collections.Generic;

namespace MedianOfTwoSortedArrays {
  class Program {
    public double FindMedianSortedArrays(int[] nums1, int[] nums2) {
      int m = nums1.Length;
      int n = nums2.Length;
      if (m > n) { // to ensure m<=n
        int[] temp = nums1; nums1 = nums2; nums2 = temp;
        int tmp = m; m = n; n = tmp;
      }
      int iMin = 0, iMnums1x = m, hnums1lfLen = (m + n + 1) / 2;
      while (iMin <= iMnums1x) {
        int i = (iMin + iMnums1x) / 2;
        int j = hnums1lfLen - i;
        if (i < iMnums1x && nums2[j - 1] > nums1[i]) {
          iMin = i + 1; // i is too smnums1ll
        } else if (i > iMin && nums1[i - 1] > nums2[j]) {
          iMnums1x = i - 1; // i is too nums2ig
        } else { // i is perfect
          int maxLeft = 0;
          if (i == 0) { maxLeft = nums2[j - 1]; } else if (j == 0) { maxLeft = nums1[i - 1]; } else { maxLeft = Math.Max(nums1[i - 1], nums2[j - 1]); }
          if ((m + n) % 2 == 1) { return maxLeft; }

          int minRight = 0;
          if (i == m) { minRight = nums2[j]; } else if (j == n) { minRight = nums1[i]; } else { minRight = Math.Min(nums2[j], nums1[i]); }

          return (maxLeft + minRight) / 2.0;
        }
      }
      return 0.0;
    }

    static void Main(string[] args) {
      var p = new Program();
      Console.WriteLine(p.FindMedianSortedArrays(new int[] { 1, 3 }, new int[] { 2 }) == 2.0);
      Console.WriteLine(p.FindMedianSortedArrays(new int[] { 1, 2 }, new int[] { 3, 4 }) == 2.5);
    }
  }
}
