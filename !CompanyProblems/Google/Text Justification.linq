<Query Kind="Program" />

void Main()
{
	var s = new Solution();
	s.FullJustify(new[] { "This", "is", "an", "example", "of", "text", "justification." }, 16).Dump();
	s.FullJustify(new[] { "What", "must", "be", "acknowledgment", "shall", "be" }, 16).Dump();
	s.FullJustify(new[] { "Science", "is", "what", "we", "understand", "well", "enough", "to", "explain", "to", "a", "computer.", "Art", "is", "everything", "else", "we", "do" }, 20).Dump();
}

// Define other methods and classes here
public class Solution
{
	public IList<string> FullJustify(string[] words, int maxWidth)
	{
		var retVal = new List<string>();
		var currentLine = new List<string>();
		var currentLineLength = 0;
		foreach (var w in words)
		{
			if (currentLineLength + currentLine.Count + w.Length > maxWidth)
			{
				retVal.Add(justifyEvenly(currentLine, maxWidth));
				currentLine.Clear();
				currentLineLength = 0;
			}
			currentLine.Add(w);
			currentLineLength += w.Length;
		}
		if (currentLine.Count > 0)
		{
			retVal.Add(justifyEvenly(currentLine, maxWidth));
		}
		var lastLine = retVal[retVal.Count - 1];
		retVal.RemoveAt(retVal.Count - 1);
		retVal.Add(justifyLeft(lastLine.Split(' ').Where(i => !string.IsNullOrEmpty(i)).ToArray(), maxWidth));
		return retVal;
	}

	string justifyLeft(string[] currenLine, int maxWidth)
	{
		var sb = new StringBuilder();
		foreach (var w in currenLine)
		{
			sb.Append($"{w} ");
		}
		sb.Remove(sb.Length - 1, 1);
		sb.Append(new string(' ', maxWidth - sb.Length));
		return sb.ToString();
	}

	private string justifyEvenly(List<string> currentLine, int maxWidth)
	{
		if (currentLine.Count == 1)
		{
			return justifyLeft(currentLine.ToArray(), maxWidth);
		}
		int numSpaces = maxWidth - currentLine.Sum(i => i.Length);
		int q = numSpaces / (currentLine.Count - 1);
		int r = numSpaces % (currentLine.Count - 1);
		var sb = new StringBuilder();
		for (int i = 0; i < currentLine.Count; i++)
		{
			string w = currentLine[i];
			sb.Append(w);
			if (i != currentLine.Count - 1)
			{
				sb.Append(new string(' ', q));
			}
			if (r > 0)
			{
				--r;
				sb.Append(' ');
			}
		}
		return sb.ToString();
	}
}