<Query Kind="Program" />

void Main()
{
	var s=new Solution();
	s.MaxValue("-132",3).Dump();
	s.MaxValue("73",6).Dump();
	s.MaxValue("-13",2).Dump();
	s.MaxValue("9",9).Dump();
	s.MaxValue("-9",9).Dump();
	s.MaxValue("55",2).Dump();
}

// Define other methods and classes here
public class Solution
{
	public string MaxValue(string n, int x)
	{
		int indexToInsert = searchIndexToInsert(n, c => n[0] == '-' ? c > x : x>c );
		return n.Insert(indexToInsert, x.ToString());
	}

	private int searchIndexToInsert(string n, Func<int, bool> func)
	{
		int index=0;
		if (n[0]=='-')
		{
			++index;
		}
		for (; index < n.Length; index++)
		{
			if (func((int)(n[index]-'0')))
			{
				break;
			}
		}
		return index;
	}
}