using System;
using System.Linq;

namespace BestTimeToBuyAndSellStock
{
  class Program
  {
    public int MaxProfit(int[] prices) {
      if (prices.Length < 2) {
        return 0;
      }

      //Debugger.Launch();
      int initSequence = prices[0], profit = 0;
      for (int i = 1; i < prices.Length; i++) {
        if (prices[i] < prices[i - 1]) {
          profit += prices[i - 1] - initSequence;
          initSequence = prices[i];
        }
      }
      profit += prices[prices.Length - 1] - initSequence;

      return profit;
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
