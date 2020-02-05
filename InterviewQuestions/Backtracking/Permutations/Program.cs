using System;
using System.Collections.Generic;
using System.Linq;

namespace Permutations {
  class Program {
    static void Main(string[] args) {
      Console.WriteLine("Hello World!");
    }
  }

  #region MyRegion


  public class Solution {
    public IList<IList<int>> Permute(int[] nums) {
      var result = new List<IList<int>>();
      foreach (var item in Permute(nums, 0)) {
        result.Add(item);
      }
      return result;
    }

    private IEnumerable<IList<int>> Permute(int[] nums, int currentPos) {
      if (nums.Length == currentPos) {
        yield return nums.ToList();
      } else {
        foreach (var item in Permute(nums, currentPos + 1)) {
          yield return item;
        }
        for (int i = currentPos + 1, tmp = 0; i < nums.Length; ++i) {
          tmp = nums[currentPos];
          nums[currentPos] = nums[i];
          nums[i] = tmp;
          foreach (var item in Permute(nums, currentPos + 1)) {
            yield return item;
          }
          tmp = nums[currentPos];
          nums[currentPos] = nums[i];
          nums[i] = tmp;
        }
      }
    }
  }

  #endregion
}
