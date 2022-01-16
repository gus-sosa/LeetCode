<Query Kind="Program" />

void Main()
{
	var s = new Solution();
	(s.NumUniqueEmails(new[] { "test.email+alex@leetcode.com", "test.e.mail+bob.cathy@leetcode.com", "testemail+david@lee.tcode.com" }) == 2).Dump();
}

// Define other methods and classes here
public class Solution
{
	public int NumUniqueEmails(string[] emails)
	{
		var set = new HashSet<string>();
		foreach (var email in emails)
		{
			set.Add(normalizeEmail(email));
		}
		return set.Count;
	}

	private string normalizeEmail(string email)
	{
		string[] tokens = email.Split('@');
		string localName = tokens[0];
		string domain = tokens[1];
		int indexPlus = localName.IndexOf('+');
		if (indexPlus != -1)
		{
			localName = localName.Substring(0, indexPlus);
		}
		localName = localName.Split('.').Aggregate("", (acc, current) => $"{acc}{current}");
		return $"{localName}@{domain}";
	}
}
