<Query Kind="Program" />

void Main()
{
	var s = new Solution();
	(s.RemovePalindromeSub("ababa") == 1).Dump();
	(s.RemovePalindromeSub("abb") == 2).Dump();
	(s.RemovePalindromeSub("baabb") == 2).Dump();
	(s.RemovePalindromeSub("") == 0).Dump();
	(s.RemovePalindromeSub(new string('a', 1000)) == 1).Dump();
	(s.RemovePalindromeSub(new string('a', 499) + "bb" + new string('a', 499)) == 1).Dump();
}

public class Solution
{
	public int RemovePalindromeSub(string s)
	{
		if (string.IsNullOrEmpty(s))
		{
			return 0;
		}

		for (int i = 0, j = s.Length - 1; i < s.Length; i++, j--)
		{
			if (s[i] != s[j])
			{
				return 2;
			}
		}

		return 1;
	}
}