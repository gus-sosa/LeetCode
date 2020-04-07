using System;

namespace DivideTwoIntegers {
  class Program {
    static void Main(string[] args) {
      var s = new Solution();
      Console.WriteLine(s.Divide(10, 3));
      Console.WriteLine(s.Divide(43, -8));
    }

    #region MyRegion

    public class Solution {
      public int Divide(int dividend, int divisor) {
        if (divisor == 0) return int.MaxValue;
        int sign = dividend > 0 ^ divisor > 0 ? -1 : 1;
        long m = Math.Abs((long)dividend), n = Math.Abs((long)divisor), count = 0;
        for (m -= n; m >= 0; m -= n) {
          count++;
          if (m == 0) break;
          for (int subCount = 1; m - (n << subCount) >= 0; subCount++) {
            m -= n << subCount;
            count += 1 << subCount;
          }
        }
        count = sign == 1 ? count : -count;
        return count > int.MaxValue ? int.MaxValue : (int)count;
      }
    }

    #endregion
  }
}
