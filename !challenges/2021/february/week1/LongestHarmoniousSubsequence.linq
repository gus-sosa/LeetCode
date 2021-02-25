<Query Kind="Program" />

void Main()
{
	var s = new Solution();
	(s.FindLHS(new int[] { 1, 3, 2, 2, 5, 2, 3, 7 }) == 5).Dump();
	(s.FindLHS(new int[] { 1, 2, 3, 4 }) == 2).Dump();
	(s.FindLHS(new int[] { 1, 1, 1, 1 }) == 0).Dump();
	(s.FindLHS(new int[] { 1, 2, 2, 1 }) == 4).Dump();
}

public class Solution
{
	public int FindLHS(int[] nums)
	{
		Array.Sort(nums);
		int maxLhs = 0;
		int minPos = 0, maxPos = 0;
		while (maxPos < nums.Length)
		{
			if (minPos == maxPos)
			{
				++maxPos;
			}
			while (maxPos < nums.Length && nums[maxPos] - nums[minPos] < 2)
			{
				++maxPos;
			}
			if (nums[maxPos - 1] - nums[minPos] == 1)
			{
				maxLhs = Math.Max(maxLhs, maxPos - minPos);
			}
			while (minPos < maxPos && maxPos < nums.Length && nums[maxPos] - nums[minPos] > 1)
			{
				++minPos;
			}
		}
		return maxLhs;
	}
}
