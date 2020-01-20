using System;
using System.Collections.Generic;

namespace MedianOfTwoSortedArrays {
  class Program {
    public double FindMedianSortedArrays(int[] nums1, int[] nums2) {
      int? tmp = null;
      int mergeLength = nums1.Length + nums2.Length, median = 0;
      tmp = FindMedianSortedArrays(nums1, nums2, mergeLength / 2);
      if (tmp.HasValue) {
        median = tmp.Value;
      } else {
        tmp = FindMedianSortedArrays(nums2, nums1, mergeLength / 2);
      }
      if (mergeLength % 2 == 0) {
        tmp = FindMedianSortedArrays(nums1, nums2, mergeLength / 2 - 1);
        return tmp.HasValue ?
          ((tmp.Value + median) / 2.0) :
          ((FindMedianSortedArrays(nums2, nums1, mergeLength / 2 - 1).Value + median) / 2.0);
      }
      return median;
    }

    private int? FindMedianSortedArrays(int[] nums1, int[] nums2, int numElementsBefore) {
      int start = 0, end = nums1.Length - 1, middle;
      for (; end - start > 0; ++start) {
        middle = (end - start) / 2;
        var tmp = binarySearchCount(nums2, nums1[middle]);
        if (!tmp.HasValue) {
          return null;
        }
        (int element, int position) = tmp.Value;
        int numElements = position + middle + 1;
        if (numElementsBefore == numElements) {
          return nums1[middle];
        } else if (numElementsBefore < numElements) {
          start = middle;
        } else {
          end = middle;
        }
      }
      if (start == end) {
        var tmp = binarySearchCount(nums2, nums1[start]);
        if (tmp.HasValue) {
          (int element, int position) = tmp.Value;
          int numElements = position + start + 1;
          if (numElementsBefore == numElements) {
            return nums1[start];
          }
        }
      }
      return null;
    }

    static (int element, int position)? binarySearchCount(int[] arr, int key) {
      int n = arr.Length, left = 0, right = n - 1, count = -1;
      while (left <= right) {
        int mid = (right + left) / 2;
        if (arr[mid] <= key) {
          count = mid + 1;
          left = mid + 1;
        } else {
          right = mid - 1;
        }
      }
      if (count >= 0) {
        return (arr[count - 1], count - 1);
      }
      return null;
    }

    static void Main(string[] args) {
      var p = new Program();
      Console.WriteLine(p.FindMedianSortedArrays(new int[] { 1, 3 }, new int[] { 2 }) == 2.0);
      Console.WriteLine(p.FindMedianSortedArrays(new int[] { 1, 2 }, new int[] { 3, 4 }) == 2.5);
    }
  }
}
