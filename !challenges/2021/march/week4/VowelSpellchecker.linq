<Query Kind="Program" />

void Main()
{
	var s = new Solution();
	AreSame(s.Spellchecker(new[] { "KiTe", "kite", "hare", "Hare" }, new[] { "kite", "Kite", "KiTe", "Hare", "HARE", "Hear", "hear", "keti", "keet", "keto" }), new[] { "kite", "KiTe", "KiTe", "Hare", "hare", "", "", "KiTe", "", "KiTe" });
}

void AreSame(string[] vs1, string[] vs2)
{
	(vs1.Length == vs2.Length && Enumerable.Zip(vs1, vs2, (i, j) => i == j).All(i => i)).Dump();
}

// You can define other methods, fields, classes and namespaces here
public class Solution
{
	public string[] Spellchecker(string[] wordlist, string[] queries)
	{
		var exactDict = new HashSet<string>(wordlist);
		var capitalizationDict = new Dictionary<string, string>();
		var vowelDict = new Dictionary<string, string>();
		foreach (var element in wordlist)
		{
			if (!capitalizationDict.ContainsKey(element.ToLower()))
			{
				capitalizationDict.Add(element.ToLower(), element);
			}
			var str = devowel(element);
			if (!vowelDict.ContainsKey(str))
			{
				vowelDict.Add(str, element);
			}
		}
		var l = new List<string>();
		foreach (var q in queries)
		{
			if (exactDict.Contains(q))
			{
				l.Add(q);
			}
			else if (capitalizationDict.ContainsKey(q.ToLower()))
			{
				l.Add(capitalizationDict[q.ToLower()]);
			}
			else if (vowelDict.ContainsKey(devowel(q)))
			{
				l.Add(vowelDict[devowel(q)]);
			}
			else
			{
				l.Add(string.Empty);
			}
		}
		return l.ToArray();
	}

	private string devowel(string element)
	{
		element = element.ToLower();
		var sb = new StringBuilder();
		char[] vowels = new char[] { 'a', 'e', 'i', 'o', 'u' };
		const char aster = '*';
		foreach (var c in element)
		{
			if (vowels.Contains(c))
			{
				sb.Append(aster);
			}
			else
			{
				sb.Append(c);
			}
		}
		return sb.ToString();
	}
}