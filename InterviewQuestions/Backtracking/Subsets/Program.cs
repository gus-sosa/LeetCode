using System;
using System.Collections.Generic;
using System.Linq;

namespace Subsets {
  class Program {
    static void Main(string[] args) {
      Console.WriteLine("Hello World!");
    }

    #region MyRegion


    public class Solution {
      public IList<IList<int>> Subsets(int[] nums) {
        var result = new List<IList<int>>();
        var marked = new bool[nums.Length];
        foreach (var item in Subsets(nums, marked, 0)) {
          result.Add(item);
        }
        return result;
      }

      private IEnumerable<IList<int>> Subsets(int[] nums, bool[] marked, int currentPos) {
        if (currentPos == nums.Length) {
          yield return nums.Where((_, ind) => marked[ind]).ToList();
        } else {
          marked[currentPos] = true;
          foreach (var item in Subsets(nums, marked, currentPos + 1)) {
            yield return item;
          }
          marked[currentPos] = false;
          foreach (var item in Subsets(nums, marked, currentPos + 1)) {
            yield return item;
          }
        }
      }
    }

    #endregion
  }
}
