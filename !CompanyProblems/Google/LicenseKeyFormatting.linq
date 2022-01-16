<Query Kind="Program" />

void Main()
{
	var s = new Solution();
	s.LicenseKeyFormatting("---", 4).Dump();
	s.LicenseKeyFormatting("5F3Z-2e-9-w", 4).Dump();
	(s.LicenseKeyFormatting("5F3Z-2e-9-w", 4) == "5F3Z-2E9W").Dump();
	(s.LicenseKeyFormatting("2-5g-3-J", 2) == "2-5G-3J").Dump();
}

// Define other methods and classes here
public class Solution
{
	public string LicenseKeyFormatting(string s, int k)
	{
		var stack = new Stack<string>();
		for (int i = s.Length - 1; i >= 0; i--)
		{
			if (s[i] == '-')
			{
				continue;
			}
			if (stack.Count == 0 || stack.Peek().Length == k)
			{
				stack.Push(s[i].ToString());
			}
			else
			{
				var top = stack.Pop();
				stack.Push($"{s[i]}{top}");
			}
		}
		return createLicenseKey(stack, k);
	}

	private string createLicenseKey(Stack<string> s, int k)
	{
		var retVal = new StringBuilder();
		while (s.Count > 0)
		{
			var current = s.Pop();
			if (string.IsNullOrEmpty(current))
			{
				continue;
			}
			retVal.Append($"{current}-");
		}
		if (retVal.Length > 0)
		{
			retVal.Remove(retVal.Length - 1, 1);
		}
		return retVal.ToString().ToUpper();
	}
}