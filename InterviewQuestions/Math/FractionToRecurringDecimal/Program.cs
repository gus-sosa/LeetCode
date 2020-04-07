using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FractionToRecurringDecimal {
  class Program {
    static void Main(string[] args) {
      var s = new Solution();
      Console.WriteLine(s.FractionToDecimal(4, 9));
      Console.WriteLine(s.FractionToDecimal(1, 2));
      Console.WriteLine(s.FractionToDecimal(2, 1));
      Console.WriteLine(s.FractionToDecimal(2, 3));
      Console.WriteLine(s.FractionToDecimal(-1, -2147483648));
    }
  }

  #region MyRegion


  public class Solution {
    public string FractionToDecimal(int numeratorArg, int denominatorArg) {
      if (numeratorArg == 0) {
        return "0";
      }
      var result = new StringBuilder();
      if (numeratorArg < 0 && denominatorArg > 0 || numeratorArg > 0 && denominatorArg < 0) { //Check for negative results
        result.Append('-');
      }
      long n = numeratorArg, d = denominatorArg;
      ulong dividend = (ulong)Math.Abs(n); ulong divisor = (ulong)Math.Abs(d);
      result.Append((dividend / divisor).ToString());
      ulong remainder = dividend % divisor;
      if (remainder > 0) {
        result.Append('.');
      }
      Dictionary<ulong, int> repeat = new Dictionary<ulong, int>();//The value of map ensures index where repeatition began so ( can be inserted at right place
      while (remainder > 0) {
        if (repeat.ContainsKey(remainder)) {
          result.Insert(repeat[remainder], "(").Append(")");
          remainder = 0;
        } else {
          repeat[remainder] = result.Length;
          remainder *= 10;
          result.Append((remainder / divisor).ToString());
          remainder %= divisor;
        }
      }
      return result.ToString();
    }
  }


  #endregion
}
