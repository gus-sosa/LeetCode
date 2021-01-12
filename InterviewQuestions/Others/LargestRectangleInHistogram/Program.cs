using System;
using System.Collections.Generic;

namespace LargestRectangleInHistogram
{
  class Program
  {
    static void Main(string[] args) {
      var s = new Solution();
      Console.WriteLine(s.LargestRectangleArea(new[] { 2, 1, 5, 6, 2, 3 }) == 10);
      Console.WriteLine(s.LargestRectangleArea(new[] { 2, 4 }) == 4);
      Console.WriteLine(s.LargestRectangleArea(new[] { 2 }) == 2);
    }

    #region MyRegion

    public class Solution
    {
      public int LargestRectangleArea(int[] heights) {
        var stack = new Stack<int>();
        int maxArea = 0, indexTop = 0, areaWithCurrent = 0, i = 0;

        for (; i < heights.Length; ++i) {
          if (stack.Count == 0 || stack.Peek() <= heights[i]) {
            stack.Push(i);
          } else {
            indexTop = stack.Pop();
            areaWithCurrent = heights[indexTop] * (stack.Count == 0 ? i : i - stack.Peek() - 1);
            if (maxArea < areaWithCurrent) {
              maxArea = areaWithCurrent;
            }
          }
        }

        while (stack.Count > 0) {
          indexTop = stack.Pop();
          areaWithCurrent = heights[indexTop] * (stack.Count == 0 ? i : i - stack.Peek() - 1);
          if (maxArea < areaWithCurrent) {
            maxArea = areaWithCurrent;
          }
        }

        return maxArea;
      }
    }

    #endregion
  }
}
