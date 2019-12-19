using System;

namespace TrappingRainWater {
  class Program {
    public int Trap(int[] height) {
      int totalWaterArea = 0, landArea;
      for (int i = 0, j; i < height.Length - 1; ++i) {
        for (j = i + 1, landArea = 0; j <= height.Length && height[i] > 0; ++j) {
          if (j==height.Length) {

          }
          if (height[i] <= height[j]) {
            int waterArea = height[i] * (j - i - 1) - landArea;
            totalWaterArea += waterArea;
            i = j - 1;
            break;
          }
          landArea += height[j];
        }
      }
      return totalWaterArea;
    }

    static void Main(string[] args) {
      var p = new Program();
      //Console.WriteLine(p.Trap(new int[] { 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 }) == 6);
      //Console.WriteLine(p.Trap(new int[] { 4, 1, 3, 1, 3, 1, 4 }) == 11);
      Console.WriteLine(p.Trap(new int[] { 4, 2, 3 }) == 1);
      Console.WriteLine("Hello World!");
    }
  }
}
