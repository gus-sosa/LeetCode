<Query Kind="Program" />

void Main()
{

}

// Define other methods and classes here
public class Solution
{
	public int WiggleMaxLength(int[] nums)
	{
		int up = 1, down = 1;
		for (int i = 1; i < nums.Length; i++)
		{
			if (nums[i - 1] < nums[i])
			{
				up = down + 1;
			}
			else if (nums[i - 1] > nums[i])
			{
				down = up + 1;
			}
		}
		return Math.Max(up, down);
	}
}