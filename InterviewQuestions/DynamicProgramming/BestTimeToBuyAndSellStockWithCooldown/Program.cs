using System;

namespace BestTimeToBuyAndSellStockWithCooldown {
  class Program {
    static void Main(string[] args) {
      var s = new Solution();
      Console.WriteLine(s.MaxProfit(new int[] { 1, 2, 3, 0, 2 }) == 3);
      Console.WriteLine(s.MaxProfit(new int[] { 1 }) == 0);
      Console.WriteLine(s.MaxProfit(new int[] { 2, 1 }) == 0);
    }


    #region MyRegion


    public class Solution {
      private int[] prices;
      private int[] dict;

      public int MaxProfit(int[] prices) {
        if (prices.Length < 3) {
          return 0;
        }
        return Math.Max(ComputeProfit(prices, 0, true), ComputeProfit(prices, 0, false));
      }

      private int ComputeProfit(int[] prices, int pos, bool buy) {
        if (pos >= prices.Length) {
          return 0;
        }
        if (buy) {
          return ComputeProfit(prices, pos + 1, false) - prices[pos];
        } else {
          return ComputeProfit(prices, pos + 2, true) + prices[pos];
        }
      }
    }


    #endregion
  }
}
