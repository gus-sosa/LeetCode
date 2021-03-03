<Query Kind="Program" />

void Main()
{
	var s = new Solution();
	(s.NumberOfArithmeticSlices(new int[] { 1, 2, 3, 8, 9, 10 }) == 2).Dump();
	(s.NumberOfArithmeticSlices(new int[] { 1, 2, 3, 4 }) == 3).Dump();
	(s.NumberOfArithmeticSlices(new int[] { 1 }) == 0).Dump();
	(s.NumberOfArithmeticSlices(new int[] { 1, 2 }) == 0).Dump();
	(s.NumberOfArithmeticSlices(new int[] { 1, 2, 5 }) == 0).Dump();
	(s.NumberOfArithmeticSlices(new int[] { 1, 2, 3 }) == 1).Dump();
}

public class Solution
{
	public int NumberOfArithmeticSlices(int[] nums)
	{
		if (nums.Length < 3)
		{
			return 0;
		}
		return NumberOfArithmeticSlicesRecur(nums, 0, true);
	}

	private int NumberOfArithmeticSlicesRecur(int[] nums, int currentIndex, bool start)
	{
		if (currentIndex >= nums.Length || (start && currentIndex + 2 >= nums.Length))
		{
			return 0;
		}
		if (start)
		{
			if (nums[currentIndex + 2] - nums[currentIndex + 1] == nums[currentIndex + 1] - nums[currentIndex])
			{
				return NumberOfArithmeticSlicesRecur(nums, currentIndex + 3, false) + 1 + NumberOfArithmeticSlicesRecur(nums, currentIndex + 1, true);
			}
			else
			{
				return NumberOfArithmeticSlicesRecur(nums, currentIndex + 1, true);
			}
		}
		else
		{
			if (nums[currentIndex] - nums[currentIndex - 1] == nums[currentIndex - 1] - nums[currentIndex - 2])
			{
				return NumberOfArithmeticSlicesRecur(nums, currentIndex + 1, false) + 1;
			}
			else
			{
				return 0;
			}
		}
	}
}
