<Query Kind="Program" />

void Main()
{
	var s = new Solution();
	(s.CoinChange(new int[] { 1, 2, 5 }, 11) == 3).Dump();
}

// Define other methods and classes here
public class Solution
{
	public int CoinChange(int[] coins, int amount)
	{
		int[] table = new int[amount + 1];
		for (int i = 1; i < table.Length; i++)
		{
			table[i] = int.MaxValue;
		}
		for (int v = 1, sub_res = 0; v <= amount; v++)
		{
			foreach (var coin in coins.Where(c => c <= v))
			{
				sub_res = table[v - coin];
				if (sub_res != int.MaxValue && sub_res + 1 < table[v])
				{
					table[v] = sub_res + 1;
				}
			}
		}
		if (table[amount] == int.MaxValue)
		{
			return -1;
		}
		return table[amount];
	}
}