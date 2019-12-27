using System;
using System.Collections;
using System.Collections.Generic;

namespace TrappingRainWater {
  class Program {
    class PondInfo {
      public int Height { get; set; }
      public int Water { get; set; }
      public int Land { get; set; }
      public int Pos { get; set; }
    }

    public int Trap(int[] height) {
      var stack = new Stack<PondInfo>();
      PondInfo lastInStack = null, current;
      for (int i = 0, currentLandArea; i < height.Length; ++i) {
        current = new PondInfo() { Height = height[i], Pos = i };
        if (stack.Count == 0 || stack.Peek().Height > height[i]) {
          stack.Push(current);
        } else {
          currentLandArea = 0;
          while (stack.Count > 0 && stack.Peek().Height <= height[i]) {
            currentLandArea += stack.Peek().Land + stack.Peek().Height;
            lastInStack = stack.Pop();
          }
          if (stack.Count == 0) {
            current.Water = lastInStack.Water + lastInStack.Height * (current.Pos - lastInStack.Pos) - currentLandArea;
          } else {
            current.Land = currentLandArea;
            current.Water = current.Height * (current.Pos - stack.Peek().Pos - 1) - currentLandArea;
          }
          stack.Push(current);
        }
      }
      int totalWater = 0;
      while (stack.Count > 0) {
        lastInStack = stack.Pop();
        totalWater += lastInStack.Water;
      }
      return totalWater;
    }

    static void Main(string[] args) {
      var p = new Program();
      Console.WriteLine(p.Trap(new int[] { 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 }) == 6);
      Console.WriteLine(p.Trap(new int[] { 4, 1, 3, 1, 3, 1, 4 }) == 11);
      Console.WriteLine(p.Trap(new int[] { 4, 2, 3 }) == 1);
      Console.WriteLine(p.Trap(new int[] { 4, 2, 3, 1, 2 }) == 2);
      Console.WriteLine(p.Trap(new int[] { 0, 2, 0 }) == 0);
      Console.WriteLine(p.Trap(new int[] { 4, 1, 3, 1, 3, 1, 4, 5 }) == 11);
      Console.WriteLine(p.Trap(new int[] { 2, 2, 2 }) == 0);
      Console.WriteLine("Hello World!");
    }
  }
}
