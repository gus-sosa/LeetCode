using System;

namespace FindTheDuplicateNumber {
  class Program {
    static void Main(string[] args) {
      Console.WriteLine("Hello World!");
    }
  }

  #region MyRegion


  public class Solution {
    public int FindDuplicate(int[] nums) {
      // Find the intersection point of the two runners.
      int tortoise = nums[0];
      int hare = nums[0];
      do {
        tortoise = nums[tortoise];
        hare = nums[nums[hare]];
      } while (tortoise != hare);

      // Find the "entrance" to the cycle.
      tortoise = nums[0];
      while (tortoise != hare) {
        tortoise = nums[tortoise];
        hare = nums[hare];
      }

      return hare;
    }
  }


  #endregion
}
