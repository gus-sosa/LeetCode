using System;
using System.Collections;
using System.Collections.Generic;

namespace ShuffleAnArray {
  class Program {
    static void Main(string[] args) {
      int[] nums = new int[] { 1, 2, 3 };
      var p = new Solution(nums);
      Print(p.Shuffle());
      Print(p.Reset());
      Print(p.Shuffle());
      Print(p.Shuffle());
      Print(p.Shuffle());
      Print(p.Shuffle());
    }

    private static void Print(int[] v) {
      foreach (var item in v) {
        Console.Write($"{item} ");
      }
      Console.WriteLine();
    }
  }

  public class Solution {

    private int[] _nums;
    private Random random = new Random();

    public Solution(int[] nums) {
      _nums = new int[nums.Length];
      Array.Copy(nums, 0, _nums, 0, nums.Length);
    }

    /** Resets the array to its original configuration and return it. */
    public int[] Reset() {
      var result = new int[_nums.Length];
      Array.Copy(_nums, 0, result, 0, _nums.Length);
      return result;
    }

    /** Returns a random shuffling of the array. */
    public int[] Shuffle() {
      var result = new int[_nums.Length];
      Array.Copy(_nums, 0, result, 0, _nums.Length);
      for (int i = 0, pos = 0, tmp = 0; i < result.Length; ++i) {
        pos = random.Next(i, _nums.Length);
        tmp = result[i];
        result[i] = result[pos];
        result[pos] = tmp;
      }
      return result;
    }
  }
}
