<Query Kind="Program" />

void Main()
{
	var s = new Solution();
	(s.ReorderedPowerOf2(1) == true).Dump();
	(s.ReorderedPowerOf2(1892) == true).Dump();
}

// Define other methods and classes here
public class Solution
{
	public bool ReorderedPowerOf2(int n)
	{
		int[] nCount = count(n);
		for (int i = 0; i < 31; i++)
		{
			if (Enumerable.Zip(nCount, count((1 << i)), (m, k) => k == m).All(ii => ii))
			{
				return true;
			}
		}
		return false;
	}

	private int[] count(int n)
	{
		int[] ans = new int[10];
		while (n > 0)
		{
			++ans[n % 10];
			n /= 10;
		}
		return ans;
	}
}