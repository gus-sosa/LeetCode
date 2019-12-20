using System;

namespace TrappingRainWater {
  class Program {
    public int Trap(int[] height) {
      int totalWaterArea = 0, landArea, maxRightLandArea, maxRightPos, maxRightHeight = 0;
      bool maxRightFound = false;
      for (int i = 0, j; i < height.Length - 1; ++i) {
        for (j = i + 1, maxRightPos = i, maxRightHeight = 0, maxRightLandArea = 0, landArea = 0, maxRightFound = false;
          j < height.Length && !maxRightFound && height[i] > 0; ++j) {
          if (height[i] <= height[j]) {
            int waterArea = height[i] * (j - i - 1) - landArea;
            totalWaterArea += waterArea;
            i = j - 1;
            maxRightFound = true;
          } else {
            landArea += height[j];
            if (maxRightHeight < height[j]) {
              maxRightHeight = height[j];
              maxRightPos = j;
              maxRightLandArea = landArea - height[j];
            }
          }
        }
        if (!maxRightFound && height[i] > 0 && maxRightPos > i) {
          int waterArea = height[maxRightPos] * (maxRightPos - i - 1) - maxRightLandArea;
          totalWaterArea += waterArea;
          i = maxRightPos - 1;
        }
      }
      return totalWaterArea;
    }

    static void Main(string[] args) {
      var p = new Program();
      Console.WriteLine(p.Trap(new int[] { 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 }) == 6);
      Console.WriteLine(p.Trap(new int[] { 4, 1, 3, 1, 3, 1, 4 }) == 11);
      Console.WriteLine(p.Trap(new int[] { 4, 2, 3 }) == 1);
      Console.WriteLine(p.Trap(new int[] { 4, 2, 3, 1, 2 }) == 2);
      Console.WriteLine(p.Trap(new int[] { 0, 2, 0 }) == 0);
      Console.WriteLine("Hello World!");
    }
  }
}
