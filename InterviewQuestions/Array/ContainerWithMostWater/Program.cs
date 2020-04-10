using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContainerWithMostWater {
  class Program {
    static void Main(string[] args) {
    }
  }

  #region MyRegion


  public class Solution {
    public int MaxArea(int[] height) {
      int i = 0, j = height.Length - 1, maxArea = 0;
      while (i < j) {
        maxArea = Math.Max(maxArea, Math.Min(height[i], height[j]) * (j - i));
        if (height[i] <= height[j]) {
          ++i;
        } else {
          --j;
        }
      }
      return maxArea;
    }
  }


  #endregion
}
