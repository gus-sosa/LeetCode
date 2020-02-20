using System;
using System.Collections.Generic;

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
      Dictionary<int, Dictionary<int, int>> dict;

      public int CoinChange(int[] coins, int amount) {
        Array.Sort(coins);
        dict = new Dictionary<int, Dictionary<int, int>>();
        return CoinChange(coins, coins.Length - 1, amount);
      }

      private int CoinChange(int[] coins, int pos, int amount) {
        if (amount == 0) {
          return 0;
        }
        if (pos == -1) {
          return -1;
        }
        if (dict.ContainsKey(pos) && dict[pos].ContainsKey(amount)) {
          return dict[pos][amount];
        }
        if (coins[pos] <= amount) {
          int minCountGlobal = CoinChange(coins, pos - 1, amount);
          for (int i = amount / coins[pos], minCount = 0; i > 0; --i) {
            minCount = CoinChange(coins, pos - 1, amount - i * coins[pos]);
            if (minCountGlobal == -1) {
              if (minCount != -1) {
                minCountGlobal = minCount + i;
              }
            } else {
              if (minCountGlobal > minCount) {
                minCountGlobal = minCount;
              } else {
                break;
              }
            }

          }
          return AddDictionary(pos, amount, minCountGlobal);
        } else {
          return AddDictionary(pos, amount, CoinChange(coins, pos - 1, amount));
        }
      }

      private int AddDictionary(int pos, int amount, int value) {
        if (!dict.ContainsKey(pos)) {
          dict[pos] = new Dictionary<int, int>();
        }
        return dict[pos][amount] = value;
      }
    }


    #endregion

  }
}
