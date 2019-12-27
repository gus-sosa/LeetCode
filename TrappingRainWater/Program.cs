using System;
using System.Collections;
using System.Collections.Generic;

namespace TrappingRainWater {
  class Program {
    class MyClass {
      public int Height { get; set; }
      public int WaterArea { get; set; }
      public int LandArea { get; set; }
      public int Pos { get; set; }
    }

    public int Trap(int[] height) {
      var stack = new Stack<MyClass>();
      int i = 0;
      while (i < height.Length && height[i] == 0) ++i;
      for (; i < height.Length; ++i) {
        if (stack.Count == 0 || stack.Peek().Height >= height[i]) {
          stack.Push(new MyClass() {
            Height = height[i],
            LandArea = 0,
            WaterArea = 0,
            Pos = i
          });
        } else if (stack.Count > 0 && stack.Peek().Height < height[i]) {
          stack.Push(new MyClass() {
            Height = height[i],
            LandArea = 0,
            WaterArea = 0,
            Pos = i
          });
          ConsumeStack(stack);
        }
      }
      if (stack.Count > 1) {
        ConsumeStack(stack);
      }
      return stack.Pop().WaterArea;
    }

    private void ConsumeStack(Stack<MyClass> stack) {
      var current = stack.Pop();
      MyClass toConsume = null;
      while (stack.Count > 0 && stack.Peek().Height < current.Height) {
        toConsume = stack.Pop();
        current.LandArea += toConsume.Height + toConsume.LandArea;
      }
      if (stack.Count > 0) {
        current.WaterArea = current.Height * (current.Pos - stack.Peek().Pos - 1) - current.LandArea;
      } else {
        current.WaterArea = toConsume.Height * (current.Pos - toConsume.Pos) - current.LandArea;
      }
      stack.Push(current);
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
