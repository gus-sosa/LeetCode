using System;
using System.Collections.Generic;
using System.Linq;

namespace CoinChange {
  class Program {
    static void Main(string[] args) {
      var s = new Solution();
      Console.WriteLine(s.CoinChange(new int[] { 1, 2, 5 }, 11) == 3);
      Console.WriteLine(s.CoinChange(new int[] { 2 }, 3) == -1);
      Console.WriteLine(s.CoinChange(new int[] { 1, 2, 5 }, 5) == 1);
      Console.WriteLine(s.CoinChange(new int[] { 1, 2, 5 }, 2) == 1);
      Console.WriteLine(s.CoinChange(new int[] { 3, 2, 5 }, 11) == 3);
      Console.WriteLine(s.CoinChange(new int[] { 336, 288, 378, 16, 319, 146 }, 9212) == 26);
      Console.WriteLine(s.CoinChange(new int[] { 336, 288, 378, 16, 319, 146 }, 9212));
    }


    #region MyRegion


    public class Solution {
      public int CoinChange(int[] coins, int amount) {
        Array.Sort(coins);
        Array.Reverse(coins);
        var coinAmounts = new int[coins.Length];
        int result = -1;
        CoinChange(coins, amount, 0, ref result);
        return result;
      }

      private bool CoinChange(int[] coins, int amount, int pos, ref int count) {
        if (amount == 0) {
          count = 0;
          return true;
        }
        if (pos == coins.Length) { 
          return false;
        } else {
          int localMin = int.MaxValue, tmpCount = -1;
          bool flag = false;
          for (int i = 1, l = amount / coins[pos]; i <= l; ++i) {
            if (CoinChange(coins, amount - coins[pos] * i, pos + 1, ref tmpCount)) {
              flag = true;
              localMin = Math.Min(localMin, tmpCount + i);
            }
          }
          flag = flag || CoinChange(coins, amount, pos + 1, ref tmpCount);
          if (flag) {
            count = Math.Min(localMin, tmpCount);
          }
          return flag;
        }
      }
    }


    #endregion

  }
}
