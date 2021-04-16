<Query Kind="Program" />

void Main()
{
	var s = new Solution();
	AreSame(s.WordSubsets(new[] { "amazon", "apple", "facebook", "google", "leetcode" }, new[] { "e", "o" }), new[] { "facebook", "google", "leetcode" });
	AreSame(s.WordSubsets(new[] { "amazon", "apple", "facebook", "google", "leetcode" }, new[] { "l", "e" }), new[] { "apple", "google", "leetcode" });
	AreSame(s.WordSubsets(new[] { "amazon", "apple", "facebook", "google", "leetcode" }, new[] { "e", "oo" }), new[] { "facebook", "google" });
	AreSame(s.WordSubsets(new[] { "amazon", "apple", "facebook", "google", "leetcode" }, new[] { "lo", "eo" }), new[] { "google", "leetcode" });
	AreSame(s.WordSubsets(new[] { "amazon", "apple", "facebook", "google", "leetcode" }, new[] { "ec", "oc", "ceo" }), new[] { "facebook", "leetcode" });
}

void AreSame(IList<string> lists, string[] vs)
{
	(lists.Count == vs.Length && Enumerable.Zip(lists, vs, (i, j) => i == j).All(i => i)).Dump();
}

// You can define other methods, fields, classes and namespaces here
public class Solution
{
	const int num_letters = 30;
	public IList<string> WordSubsets(string[] A, string[] B)
	{
		int[] map = new int[num_letters];
		foreach (var element in B)
		{
			int[] mapElement = countLetters(element);
			for (int i = 0; i < map.Length; i++)
			{
				map[i] = Math.Max(map[i], mapElement[i]);
			}
		}
		var r = new List<string>();
		foreach (var element in A)
		{
			int[] mapElement = countLetters(element);
			if (isSusbset(map, mapElement))
			{
				r.Add(element);
			}
		}
		return r;
	}

	bool isSusbset(int[] map, int[] mapElement)
	{
		return Enumerable.Zip(map, mapElement, (i, j) => i <= j).All(i => i);
	}

	private int[] countLetters(string element)
	{
		int[] map = new int[num_letters];
		foreach (var c in element)
		{
			++map[c - 'a'];
		}
		return map;
	}
}