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
        if (dividend == int.MinValue && divisor == -1) {
          return int.MaxValue;
        }

        if (divisor == 1) {
          return dividend;
        }

        long sign = ((dividend < 0) ^
                     (divisor < 0)) ? -1 : 1;

        dividend = Math.Abs(dividend);
        divisor = Math.Abs(divisor);

        int quotient = 0, temp = 0, temp1 = 0;

        while (dividend >= divisor) {
          temp = divisor;
          temp1 = 1;
          while (dividend >= temp) {
            temp <<= 1;
            temp1 <<= 1;
          }
          dividend -= temp >> 1;
          quotient += temp1 >> 1;
        }

        return (int)(sign * quotient);
      }
    }

    #endregion
  }
}
