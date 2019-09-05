using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestTimeToBuyAndSellStock {
  class Program {
    int[] map;
    public int MaxProfit(int[] prices) {
      //Debugger.Launch();
      map = new int[prices.Length];
      return MaxProfit(prices, 0);
    }

    private int MaxProfit(int[] prices, int pos) {
      if (pos == prices.Length) {
        return 0;
      }

      if (map[pos] > 0) {
        return map[pos];
      }

      int max = MaxProfit(prices, pos + 1);
      for (int i = pos + 1; i < prices.Length; ++i) {
        if (prices[pos] < prices[i]) {
          max = Math.Max(max, prices[i] - prices[pos] + MaxProfit(prices, i + 1));
        }
      }

      return map[pos] = max;
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
