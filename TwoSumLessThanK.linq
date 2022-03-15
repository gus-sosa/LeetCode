<Query Kind="Program" />

void Main()
{

}

// Define other methods and classes here
public class Solution
{
	public int TwoSumLessThanK(int[] nums, int k)
	{
		int sum = -1;
		for (int i = 0; i < nums.Length; i++)
		{
			for (int j = i + 1; j < nums.Length; j++)
			{
				if (nums[i] + nums[j] < k)
				{
					sum = Math.Max(sum, nums[i] + nums[j]);
				}
			}
		}
		return sum;
	}
}