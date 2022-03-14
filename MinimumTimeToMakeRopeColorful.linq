<Query Kind="Program" />

void Main()
{
	var s = new Solution();
	s.MinCost("abaac", new[] { 1, 2, 3, 4, 5 }).Dump();
	s.MinCost("bbbaaa", new[] { 4, 9, 3, 8, 8, 9 }).Dump();
}

// Define other methods and classes here
public class Solution
{
	public int MinCost(string colors, int[] neededTime)
	{
		int min = 0;
		for (int i = 0, j, s, m; i < colors.Length; i++)
		{
			j = i;
			s = 0;
			m = neededTime[i];
			while (j < colors.Length && colors[j] == colors[i])
			{
				s += neededTime[j];
				m = Math.Max(m, neededTime[j]);
				++j;
			}
			--j;
			if (j - i > 0)
			{
				min += s - m;
			}
			i = j;
		}
		return min;
	}
}