<Query Kind="Program" />

void Main()
{
	var s = new Solution();
	s.GrayCode(2).Dump();
	s.GrayCode(3).Dump();
}

// You can define other methods, fields, classes and namespaces here
public class Solution
{
	public IList<int> GrayCode(int n)
	{
		int length = Convert.ToInt32(Math.Pow(2, n)), tLength = 0;
		var l = new List<int>(length) { 0, 1 };
		int round = 1;
		while (l.Count < length)
		{
			tLength = l.Count;
			for (int i = 0; i < tLength; i++)
			{
				l.Add(l[tLength - i - 1]);
			}
			while (tLength < l.Count)
			{
				l[tLength] = 1 << round | l[tLength];
				++tLength;
			}
			++round;
		}
		return l;
	}
}