using System;
using System.Collections.Generic;

namespace ClimbingStairs
{
  class Program
  {
    public int ClimbStairs(int n) {
      var map = new Dictionary<int, int>();
      map[1] = 1;
      map[2] = 2;
      return ClimbStairs(n, map);
    }

    private int ClimbStairs(int n, Dictionary<int, int> map) {
      if (map.ContainsKey(n)) {
        return map[n];
      }
      return map[n] = ClimbStairs(n - 1, map) + ClimbStairs(n - 2, map);
    }

    static void Main(string[] args) {
      var p = new Program();
      Console.WriteLine(p.ClimbStairs(3) == 3);
      Console.WriteLine(p.ClimbStairs(4) == 5);
      Console.WriteLine("Hello World!");
    }
  }
}
