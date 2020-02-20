using System;

namespace Pow {
  class Program {
    static void Main(string[] args) {
      var s = new Solution();
      //Console.WriteLine(s.MyPow(2.0, 10));
      //Console.WriteLine(s.MyPow(2.1, 3));
      //Console.WriteLine(s.MyPow(2.0, -2));
      Console.WriteLine(s.MyPow(2.0, -2147483648));
    }

    #region MyRegion


    public class Solution {
      public double MyPow(double x, int n) {
        if (n == 0 || x == 1) {
          return 1.0;
        }
        if (n < 0) {
          return 1 / (n == int.MinValue ? MyPow(x, int.MaxValue - 1) : MyPow(x, -1 * n));
        }
        double result = MyPow(x, n / 2);
        result *= result;
        if (n % 2 != 0) {
          result = x * result;
        }
        return result;
      }
    }


    #endregion
  }
}
