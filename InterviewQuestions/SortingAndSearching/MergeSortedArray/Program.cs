using System;

namespace MergeSortedArray {
  class Program {
    public void Merge(int[] nums1, int m, int[] nums2, int n) {
      int[] result = new int[n + m];
      int index = 0, i, j;
      for (i = 0, j = 0; i < m && j < n;) {
        if (nums1[i] < nums2[j]) {
          result[index] = nums1[i];
          ++i;
        } else {
          result[index] = nums2[j];
          ++j;
        }
        ++index;
      }
      while (i < m) {
        result[index] = nums1[i];
        ++index; ++i;
      }
      while (j < n) {
        result[index] = nums2[j];
        ++index; ++j;
      }
      for (int k = 0; k < result.Length; k++) {
        nums1[k] = result[k];
      }
    }

    static void Main(string[] args) {
      Console.WriteLine("Hello World!");
    }
  }
}
