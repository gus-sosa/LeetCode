<Query Kind="Program" />

void Main()
{
	var s = new Solution();
	(s.MissingNumber(new int[] {3,0,1})==2).Dump();
	(s.MissingNumber(new int[] {0,1})==2).Dump();
	(s.MissingNumber(new int[] {9,6,4,2,3,5,7,0,1})==8).Dump();
	(s.MissingNumber(new int[] {0})==1).Dump();
}

public class Solution
{
	public int MissingNumber(int[] nums)
	{
		int sum=nums.Sum(),n=nums.Length;
		return (n*(n+1)/2)-sum;
	}
}