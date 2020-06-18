using System;
using System.Collections.Generic;

namespace PerfectSquares {
  class Program {
    static void Main(string[] args) {
      var s = new Solution();
      Console.WriteLine(s.NumSquares(12) == 3);
      Console.WriteLine(s.NumSquares(13) == 2);
      Console.WriteLine(s.NumSquares(5) == 2);
      Console.WriteLine(s.NumSquares(9) == 1);
    }
  }

  #region MyRegion


  public class Solution {
    Dictionary<int, int> map = new Dictionary<int, int>();
    public int NumSquares(int n) {
      map[1] = 1;
      map[2] = 2;
      map[3] = 3;
      map[4] = 1;
      return NumSquaresRec(n);
    }

    public int NumSquaresRec(int n) {
      if (map.ContainsKey(n)) {
        return map[n];
      }

      int p = (int)Math.Ceiling(Math.Sqrt(n));
      while (p * p > n) {
        --p;
      }

      if (p * p == n) {
        return map[n] = 1;
      }

      map[n] = int.MaxValue;
      while (p > 0 && map[n] != 2) {
        map[n] = Math.Min(map[n], 1 + NumSquaresRec(n - p * p));
        --p;
      }
      return map[n];
    }
  }


  #endregion
}
