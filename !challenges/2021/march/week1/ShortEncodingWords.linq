<Query Kind="Program" />

void Main()
{
	var s = new Solution();
	(s.MinimumLengthEncoding(new[] { "time", "me", "bell" }) == 10).Dump();
	(s.MinimumLengthEncoding(new[] { "t" }) == 2).Dump();
	(s.MinimumLengthEncoding(new[] { "a", "b", "c", "d" }) == 8).Dump();
	(s.MinimumLengthEncoding(new[] { "ab", "b", "c", "d" }) == 7).Dump();
}

// You can define other methods, fields, classes and namespaces here
public class Solution
{
	class Trie
	{
		public bool isEnd { get; set; }
		public int dist { get; set; } = 1;
		public Dictionary<char, Trie> children { get; set; } = new Dictionary<char, Trie>();

		public void add(string w)
		{
			if (!string.IsNullOrEmpty(w))
			{
				add(w, 0);
			}
		}

		private void add(string w, int pos)
		{
			if (w.Length == pos)
			{
				return;
			}
			if (!children.ContainsKey(w[pos]))
			{
				children.Add(w[pos], new Trie());
				children[w[pos]].isEnd = pos == w.Length - 1;
				children[w[pos]].dist = 1 + this.dist;
			}
			children[w[pos]].add(w, pos + 1);
		}
	}

	public int MinimumLengthEncoding(string[] words)
	{
		var trie = new Trie();
		foreach (var element in words)
		{
			trie.add(new string(element.Reverse().ToArray()));
		}
		return getLengthMaxEncoding(trie);
	}

	private int getLengthMaxEncoding(Trie trie)
	{
		if (trie.children.Count == 0 && trie.isEnd)
		{
			return trie.dist;
		}
		int count = 0;
		foreach (var child in trie.children.Values)
		{
			count += getLengthMaxEncoding(child);
		}
		return count;
	}
}