<Query Kind="Program" />

void Main()
{
	var s = new Solution();
	AreSame(s.ShortestToChar("aaab", 'b'), new int[] { 3, 2, 1, 0 }).Dump();
	AreSame(s.ShortestToChar("abab", 'b'), new int[] { 1, 0, 1, 0 }).Dump();
	AreSame(s.ShortestToChar("bbbb", 'b'), new int[] { 0, 0, 0, 0 }).Dump();
	AreSame(s.ShortestToChar("bahd", 'b'), new int[] { 0, 1, 2, 3 }).Dump();
	AreSame(s.ShortestToChar("loveleetcode", 'e'), new int[] { 3, 2, 1, 0, 1, 0, 0, 1, 2, 2, 1, 0 }).Dump();
}

bool AreSame(int[] arr1, int[] arr2)
{
	return arr1.Length == arr2.Length && Enumerable.Zip(arr1, arr2, (first, second) => first == second).All(i => i);
}

public class Solution
{
	public int[] ShortestToChar(string s, char c)
	{
		var stack = new Stack<int>();
		for (int i = s.Length - 1; i >= 0; --i)
		{
			if (s[i] == c)
			{
				stack.Push(i);
			}
		}

		int previousPos = -1, nextPos = stack.Pop();
		int[] result = new int[s.Length];
		for (int i = 0; i < s.Length; ++i)
		{
			if (i == nextPos)
			{
				previousPos = nextPos;
				if (stack.Count > 0)
				{
					nextPos = stack.Pop();
				}
				else
				{
					nextPos = -1;
				}
			}
			if (previousPos == -1)
			{
				result[i] = Math.Abs(i - nextPos);
			}
			else if (nextPos == -1)
			{
				result[i] = Math.Abs(i - previousPos);
			}
			else
			{
				result[i] = Math.Min(Math.Abs(i - nextPos), Math.Abs(i - previousPos));
			}
		}
		return result;
	}
}
