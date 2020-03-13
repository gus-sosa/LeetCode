using System;
using System.Numerics;

namespace FactorialTrailingZeros {
  class Program {
    static void Main(string[] args) {
      var s = new Solution();
      //for (int i = 10; i < 21; ++i) {
      //  Console.WriteLine(s.TrailingZeroes(i));
      //}
      //Console.WriteLine(s.TrailingZeroes(20));
      //Console.WriteLine(s.TrailingZeroes(21));
      //Console.WriteLine();
      //Console.WriteLine();
      s.ComputeFactorials();
      Console.WriteLine(s.TrailingZeroes(100));
    }

    #region MyRegion


    public class Solution {
      public int TrailingZeroes(int n) {
        if (n < 5) {
          return 0;
        }
        if (n < 10) {
          return 1;
        }
        n -= n % 5;
        return n / 5 + TrailingZeroes(n / 5);
      }

      public void ComputeFactorials() {
        BigInteger fact = 1;
        for (int i = 1; i < 102; ++i) {
          Console.WriteLine($"{i - 1}({NumTrailingZeros(fact)})={fact}");
          fact *= i;
        }
      }

      private int NumTrailingZeros(BigInteger fact) {
        int numZeros = 0;
        while (fact > 0) {
          if (fact % 10 == 0) {
            ++numZeros;
            fact /= 10;
          } else {
            break;
          }
        }
        return numZeros;
      }
    }


    #endregion
  }
}
