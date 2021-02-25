<Query Kind="Program" />

void Main()
{
	var s = new Solution();
	(s.SimplifyPath("/home/") == "/home").Dump();
	(s.SimplifyPath("/home//foo/") == "/home/foo").Dump();
	(s.SimplifyPath("/../") == "/").Dump();
	(s.SimplifyPath("/a/./b/../../c/") == "/c").Dump();
	(s.SimplifyPath("./a") == "/a").Dump();
	(s.SimplifyPath("./../a") == "/a").Dump();

}

public class Solution
{
	private const string BACK = "..";
	private const string DOUBLE_SLASH = "//";
	private const string SINGLE_SLASH = "/";
	private const string CURRENT_DIR = ".";
	public string SimplifyPath(string path)
	{
		var stack = getDirectoryStackFromPath(path.Replace(DOUBLE_SLASH, SINGLE_SLASH));
		var stack1 = new Stack<string>();
		string current;
		int numBacks = 0;
		while (stack.Count > 0)
		{
			current = stack.Pop();
			if (current == string.Empty || current == CURRENT_DIR)
			{
				continue;
			}
			if (current == BACK)
			{
				++numBacks;
				continue;
			}
			if (numBacks>0)
			{
				--numBacks;
				continue;
			}
			stack1.Push(current);
		}
		var sb=new StringBuilder();
		while (stack1.Count>0)
		{
			sb.Append($"/{stack1.Pop()}");
		}
		if (sb.Length==0)
		{
			sb.Append("/");
		}
		return sb.ToString();
	}

	private Stack<string> getDirectoryStackFromPath(string path)
	{
		var stack = new Stack<string>();
		foreach (var token in path.Split('/'))
		{
			stack.Push(token);
		}
		return stack;
	}
}
