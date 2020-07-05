using System;
using System.Collections.Generic;

namespace BestTimeToBuyAndSellStockWithCooldown {
  class Program {
    static void Main(string[] args) {
      var s = new Solution();
      Console.WriteLine(s.MaxProfit(new int[] { 1, 2, 3, 0, 2 }) == 3);
      Console.WriteLine(s.MaxProfit(new int[] { 1 }) == 0);
      Console.WriteLine(s.MaxProfit(new int[] { 2, 1 }) == 0);
      Console.WriteLine(s.MaxProfit(new int[] { 1, 2 }) == 1);
      Console.WriteLine(s.MaxProfit(new int[] { 2, 1, 4 }) == 3);
    }


    #region MyRegion


    public class Solution {
      public int MaxProfit(int[] prices) {
        if (prices.Length < 2) {
          return 0;
        }
        int has1_doNothing = -prices[0], has1_Sell = 0, has0_doNothing = 0, has0_buy = -prices[0];
        for (int i = 1; i < prices.Length; ++i) {
          has1_doNothing = Math.Max(has1_doNothing, has0_buy);
          has0_buy = -prices[i] + has0_doNothing;
          has0_doNothing = Math.Max(has0_doNothing, has1_Sell);
          has1_Sell = prices[i] + has1_doNothing;
        }
        return Math.Max(has1_Sell, has0_doNothing);
      }
    }


    #endregion
  }
}
