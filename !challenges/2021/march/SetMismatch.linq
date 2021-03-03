<Query Kind="Program" />

//https://leetcode.com/problems/set-mismatch/solution/
void Main()
{
	var s = new Solution();
	AreSame(s.FindErrorNums(new int[] { 1, 2, 2, 4 }), new int[] { 2, 3 }).Dump();
	AreSame(s.FindErrorNums(new int[] { 1, 1 }), new int[] { 1, 2 }).Dump();
}

bool AreSame(int[] arr1, int[] arr2)
{
	return arr1.Length == arr2.Length && Enumerable.Zip(arr1, arr2, (i1, i2) => i1 == i2).All(i => i);
}

public class Solution
{
	public int[] FindErrorNums(int[] nums)
	{
		var set = new HashSet<int>();
		int repeat = 0, lost = -1;
		foreach (var element in nums)
		{
			if (set.Contains(element))
			{
				repeat = element;
			}
			else
			{
				set.Add(element);
			}
		}
		for (int i = 1; lost == -1 && i <= nums.Length; ++i)
		{
			if (!set.Contains(i))
			{
				lost = i;
			}
		}
		return new int[] { repeat, lost };
	}
}