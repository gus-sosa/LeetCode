<Query Kind="Program" />

void Main()
{
	var s = new Solution();
	(s.TotalFruit(new[] { 0, 1, 2, 2 }) == 3).Dump();
	(s.TotalFruit(new[] { 0, 1, 2, 2 }) == 3).Dump();
	(s.TotalFruit(new[] { 1, 2, 1 }) == 3).Dump();
	(s.TotalFruit(new[] { 1, 2, 3, 2, 2 }) == 4).Dump();
}

// Define other methods and classes here
public class Solution
{
	public int TotalFruit(int[] fruits)
	{
		var dict = new Dictionary<int, int>();
		int numMaxFruitsPicked = 0;
		int i = 0, j = 0;
		while (j < fruits.Length)
		{
			if (dict.ContainsKey(fruits[j]))
			{
				dict[fruits[j]]++;
				++j;
			}
			else
			{
				while (dict.Count == 2)
				{
					dict[fruits[i]]--;
					if (dict[fruits[i]] == 0)
					{
						dict.Remove(fruits[i]);
					}
					++i;
				}
				dict.Add(fruits[j++], 1);
			}
			numMaxFruitsPicked = Math.Max(numMaxFruitsPicked, dict.Sum(ii => ii.Value));
		}
		return numMaxFruitsPicked;
	}
}