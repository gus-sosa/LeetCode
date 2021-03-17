<Query Kind="Program" />

void Main()
{
	var s = new Solution();
	(s.MaxProfit(new[] { 1, 3, 2, 8, 4, 9 }, 2) == 8).Dump();
}

// Define other methods and classes here
public class Solution
{
	public int MaxProfit(int[] prices, int fee)
	{
		int len = prices.Length, buying = 0, selling = -prices[0];
		for (int i = 1; i < len; i++)
		{
			buying = Math.Max(buying, selling + prices[i] - fee);
			selling = Math.Max(selling, buying - prices[i]);
		}
		return buying;
	}
}