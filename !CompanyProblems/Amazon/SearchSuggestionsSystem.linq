<Query Kind="Program" />

void Main()
{

}

// Define other methods and classes here
public class Solution
{
	class Trie
	{
		public char Value { get; set; }
		public Trie[] Children { get; set; }
		public bool IsEndOfWord { get; set; }
		public Trie Parent { get; set; }

		public Trie()
		{
			Children = new Trie[26];
		}

		public Trie GetNodeWithPrefix(string prefix)
		{
			var current = this;
			for (int i = 0; i < prefix.Length && current != null; i++)
			{
				current = current.Children[getLetterIndex(prefix[i])];
			}
			return current;
		}

		private int getLetterIndex(char letter)
		{
			return (int)(letter - 'a');
		}

		public IEnumerable<Trie> GetEndWords()
		{
			if (IsEndOfWord)
			{
				yield return this;
			}
			foreach (var child in Children.Where(i => i != null))
			{
				foreach (var otherChild in child.GetEndWords())
				{
					yield return otherChild;
				}
			}
		}

		public string GetWord()
		{
			var sb = new StringBuilder();
			var current = this;
			while (current != null)
			{
				sb.Insert(0, current.Value.ToString(), 1);
				current = current.Parent;
			}
			sb.Remove(0, 1);
			return sb.ToString();
		}

		public void AddWord(string word)
		{
			var current = this;
			foreach (var c in word)
			{
				int index = getLetterIndex(c);
				if (current.Children[index] == null)
				{
					current.Children[index] = new Trie()
					{
						Parent = current,
						Value = c
					};
				}
				current = current.Children[index];
			}
			current.IsEndOfWord = true;
		}
	}

	public IList<IList<string>> SuggestedProducts(string[] products, string searchWord)
	{
		Trie root = buildTrie(products);
		var prefixes = Enumerable.Range(1, searchWord.Length).Select(i => searchWord.Substring(0, i).ToLower()).ToArray();
		var retVal = new List<IList<string>>();
		foreach (var prefix in prefixes)
		{
			var nodeWithPrefix = root.GetNodeWithPrefix(prefix);
			if (nodeWithPrefix == null)
			{
				retVal.Add(new List<string>());
			}
			else
			{
				retVal.Add(nodeWithPrefix.GetEndWords().Take(3).Select(i => i.GetWord()).ToList());
			}
		}
		return retVal;
	}

	private Trie buildTrie(string[] products)
	{
		Trie root = new Trie() { Value = '\0' };
		foreach (var prod in products)
		{
			root.AddWord(prod.ToLower());
		}
		return root;
	}
}