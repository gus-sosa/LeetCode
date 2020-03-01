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
      //Console.WriteLine(s.CoinChange(new int[] { 3, 2, 5 }, 11));
      Console.WriteLine(s.CoinChange(new int[] { 3, 2, 5 }, 11) == 3);
      Console.WriteLine(s.CoinChange(new int[] { 336, 288, 378, 16, 319, 146 }, 9212) == 26);
      Console.WriteLine(s.CoinChange(new int[] { 336, 288, 378, 16, 319, 146 }, 9212));
    }


    #region MyRegion


    public class Solution {
      private int[] _coins;
      private Dictionary<int, int> _map;

      public int CoinChange(int[] coins, int amount) {
        this._coins = coins;
        this._map = new Dictionary<int, int>();
        _map[0] = 0;
        return CoinChange(amount);
      }

      private int CoinChange(int amount) {
        if (_map.ContainsKey(amount)) {
          return _map[amount];
        }

        int best = -1, localMin;
        foreach (var coinDenomination in _coins.Where(c => c <= amount)) {
          localMin = CoinChange(amount - coinDenomination);
          if (best == -1 || (localMin >= 0 && localMin < best)) {
            best = localMin;
          }
        }
        return _map[amount] = best == -1 ? -1 : (best + 1);
      }
    }


    #endregion

  }
}
