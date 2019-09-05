using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestTimeToBuyAndSellStock {
  class Program {
    public int MaxProfit(int[] prices) {
      return MaxProfit(prices, 0, 0);
    }

    private int MaxProfit(int[] prices, int pos, int profit) {
      if (pos == prices.Length) {
        return profit;
      }

      int max = 0;
      for (int i = pos + 1; i < prices.Length; ++i) {
        if (prices[pos] < prices[i]) {
          max = Math.Max(max, MaxProfit(prices, i + 1, profit + prices[i] - prices[pos]));
        }
      }

      return Math.Max(max, MaxProfit(prices, pos + 1, profit));
    }

    static void Main(string[] args) {
      var instance = new Program();
      int[] prices = Console.ReadLine().Split(' ').Select(p => Convert.ToInt32(p)).ToArray();
      int expectedResult = Convert.ToInt32(Console.ReadLine());
      int result = instance.MaxProfit(prices);
      Console.WriteLine(result == expectedResult ? "OK" : "FAIL");
    }
  }
}
