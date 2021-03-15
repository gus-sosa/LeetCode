<Query Kind="Program" />

void Main()
{
	var s = new Solution();
	(s.HasAllCodes("00110110", 2) == true).Dump();
	(s.HasAllCodes("00110", 2) == true).Dump();
	(s.HasAllCodes("0110", 1) == true).Dump();
	(s.HasAllCodes("0110", 2) == false).Dump();
	(s.HasAllCodes("0000000001011100", 4) == false).Dump();
}

public class Solution
{
	public bool HasAllCodes(string s, int k)
	{
		var marked = new bool[1 << k];
		int hash = 0;
		int allOne = (1 << k) - 1;

		for (int i = 0; i < s.Length; ++i)
		{
			hash = ((hash << 1) & allOne) | (s[i] - '0');
			marked[hash] = i + 1 >= k;
		}

		return marked.All(i => i);
	}
}
