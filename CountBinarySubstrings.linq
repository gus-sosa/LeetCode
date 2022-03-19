<Query Kind="Program" />

void Main()
{

}

// Define other methods and classes here
public class Solution
{
	public int CountBinarySubstrings(string s)
	{
		var indexes = new List<int>();
		int count = 0, i, j;
		for (i = 1; i < s.Length; i++)
		{
			if (s[i] != s[i - 1])
			{
				indexes.Add(i - 1);
			}
		}
		
		char cI, cJ;
		foreach (var index in indexes)
		{
			i = index;
			j = index + 1;
			cI = s[i];
			cJ = s[j];
			while (i >= 0 && j < s.Length && s[i] == cI && s[j] == cJ)
			{
				i--;
				j++;
				count++;
			}
		}
		return count;
	}
}