<Query Kind="Program" />

void Main()
{
	var s = new Solution();
	(s.RemoveKdigits("112", 1) == "11").Dump();
	(s.RemoveKdigits("10", 2) == "0").Dump();
	(s.RemoveKdigits("1432219", 3) == "1219").Dump();
}

// Define other methods and classes here
public class Solution
{
	public string RemoveKdigits(string num, int k)
	{
		if (k >= num.Length)
		{
			return "0";
		}
		var s = new Stack<char>();
		int count = 0;
		foreach (var element in num)
		{
			while (s.Count > 0 && s.Peek() > element && count < k)
			{
				s.Pop();
				++count;
			}
			s.Push(element);
		}
		while (count<k)
		{
			s.Pop();
			++count;
		}
		var sb = new StringBuilder();
		while (s.Count > 0)
		{
			sb.Insert(0, s.Pop().ToString(), 1);
		}
		var result = sb.ToString().TrimStart(new[] { '0' });
		return string.IsNullOrEmpty(result) ? "0" : result;
	}
}