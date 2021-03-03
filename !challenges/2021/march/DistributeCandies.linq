<Query Kind="Program" />

void Main()
{
	var s = new Solution();
	(s.DistributeCandies(new int[] { 1, 1, 2, 2, 3, 3 }) == 3).Dump();
	(s.DistributeCandies(new int[] { 1, 1, 2, 3 }) == 2).Dump();
	(s.DistributeCandies(new int[] { 6, 6, 6, 6 }) == 1).Dump();
	(s.DistributeCandies(new int[] { 1, 2 }) == 1).Dump();
	(s.DistributeCandies(new int[] { 1, 1 }) == 1).Dump();
}

public class Solution
{
	public int DistributeCandies(int[] candyType)
	{
		var set = new HashSet<int>();
		foreach (var type in candyType)
		{
			set.Add(type);
		}
		return Math.Min(candyType.Length / 2, set.Count);
	}
}