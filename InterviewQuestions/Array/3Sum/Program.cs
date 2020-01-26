using System;
using System.Collections.Generic;
using System.Linq;

namespace _3Sum {
  class Program {
    static void Main(string[] args) {
      var p = new Program();
      p.ThreeSum(new int[] { -1, 0, 1, 2, -1, -4 });
      p.ThreeSum(new int[] { 1, 2, -2, -1 });
    }

    public IList<IList<int>> ThreeSum(int[] nums) {
      Array.Sort(nums);
      var set = new HashSet<Tuple<int, int, int>>();
      for (int firstIndex = 0, secondIndex = 1, thirdIndex = nums.Length - 1, sum = 0; firstIndex < nums.Length - 2; ++firstIndex, thirdIndex = nums.Length - 1) {
        secondIndex = firstIndex + 1;
        while (secondIndex < thirdIndex) {
          sum = nums[firstIndex] + nums[secondIndex] + nums[thirdIndex];
          if (sum < 0) {
            ++secondIndex;
          } else if (sum > 0) {
            --thirdIndex;
          } else {
            var triplet = Tuple.Create(nums[firstIndex], nums[secondIndex], nums[thirdIndex]);
            if (!set.Contains(triplet)) {
              set.Add(triplet);
            }
            do {
              ++secondIndex;
            } while (secondIndex < thirdIndex && nums[secondIndex - 1] == nums[secondIndex]);
            do {
              --thirdIndex;
            } while (secondIndex < thirdIndex && nums[thirdIndex] == nums[thirdIndex + 1]);
          }
        }
        while (firstIndex < nums.Length - 2 && nums[firstIndex] == nums[firstIndex + 1]) {
          ++firstIndex;
        }
      }
      return set.Select(i => (IList<int>)new List<int>() { i.Item1, i.Item2, i.Item3 }).ToList();
    }
  }
}
