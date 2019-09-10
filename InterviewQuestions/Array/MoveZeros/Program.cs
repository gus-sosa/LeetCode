using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoveZeros
{
  class Program
  {
    public void MoveZeroes(int[] nums) {
      int numZeros = 0;
      for (int i = 0; i < nums.Length; i++) {
        if (nums[i] == 0) {
          ++numZeros;
        }
      }
      int pivot = 0;
      for (int i = 0; i < nums.Length; i++) {
        if (nums[i] != 0) {
          nums[pivot++] = nums[i];
        }
      }
      for (int i = 0; i < numZeros; i++) {
        nums[nums.Length - 1 - i] = 0;
      }
    }

    static void Main(string[] args) {
      var p = new Program();
      var arr = new[] { 0, 1, 0, 3, 12 };
      p.MoveZeroes(arr);
      Console.WriteLine(SameArrays(arr, new[] { 1, 3, 12, 0, 0 }) ? "OK" : "FAIL");
    }

    private static bool SameArrays(int[] arr1, int[] arr2) => Enumerable.Zip(arr1, arr2, (i1, i2) => i1 == i2).All(t => t);
  }
}
