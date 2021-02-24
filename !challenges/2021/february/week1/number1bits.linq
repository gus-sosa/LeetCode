<Query Kind="Program" />

void Main()
{
	var s=new Solution();
	(s.HammingWeight(2)==1).Dump();
	(s.HammingWeight(1)==1).Dump();
	(s.HammingWeight(0)==0).Dump();
	(s.HammingWeight(3)==2).Dump();
	(s.HammingWeight(4)==1).Dump();
	(s.HammingWeight(4)==1).Dump();
	(s.HammingWeight(5)==2).Dump();
	(s.HammingWeight(236)==5).Dump();
}

public class Solution
{
	private Dictionary<uint, int> set = new Dictionary<uint, int>() {
		[0]=0
	};
	private const uint one=1;
	public int HammingWeight(uint n)
	{
		if (set.ContainsKey(n))
		{
			return set[n];
		}
		return set[n]=HammingWeight(n>>1)+(int)(n&one);
	}
}
