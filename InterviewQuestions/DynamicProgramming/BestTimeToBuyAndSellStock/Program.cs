using System;

namespace BestTimeToBuyAndSellStock
{
  class Program
  {
    public int MaxProfit(int[] prices) {
      if (prices == null || prices.Length < 2) {
        return 0;
      }
      int profit = 0, max = prices[prices.Length - 1];
      for (int i = prices.Length - 2; i >= 0; --i) {
        if (prices[i] < max) {
          profit = Math.Max(profit, max - prices[i]);
        } else {
          max = prices[i];
        }
      }
      return profit;
    }

    static void Main(string[] args) {
      var p = new Program();
      Console.WriteLine(p.MaxProfit(new int[] { 7, 1, 5, 3, 6, 4 }) == 5);
      Console.WriteLine(p.MaxProfit(new int[] { 7, 6, 5, 4, 3, 2, 1 }) == 0);
      Console.WriteLine("Hello World!");
    }
  }
}
