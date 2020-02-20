using System;

namespace Sqrt {
  class Program {
    static void Main(string[] args) {
      var s = new Solution();
      Console.WriteLine($"sqrt(1)={s.MySqrt(1)}");
      Console.WriteLine($"sqrt(4)={s.MySqrt(4)}");
      Console.WriteLine($"sqrt(2147483647)={s.MySqrt(2147483647)}");
      Console.WriteLine($"sqrt(9)={s.MySqrt(9)}");
      Console.WriteLine($"sqrt(10)={s.MySqrt(10)}");
    }

    #region MyRegion


    public class Solution {
      public int MySqrt(int x) {
        if (x < 2) {
          return x;
        }
        return MySqrt(1, x / 2, (ulong)x);
      }

      private int MySqrt(int start, int end, ulong num) {
        if (start == end || start + 1 == end) {
          if ((ulong)(end * end) <= num) {
            return end;
          }
          return start;
        }
        ulong mid = (ulong)(start + end) / (ulong)2;
        if (mid * mid == num) {
          return (int)mid;
        } else if (mid * mid < num) {
          return MySqrt((int)mid, end, num);
        } else {
          return MySqrt(start, (int)mid, num);
        }
      }
    }


    #endregion
  }
}
