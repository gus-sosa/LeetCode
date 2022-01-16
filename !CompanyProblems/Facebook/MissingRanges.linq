<Query Kind="Program" />

void Main()
{
	var s = new Solution();
	s.FindMissingRanges(new[] { -1 }, -1, 0).Dump();
}

// Define other methods and classes here
public class Solution
{
	public IList<string> FindMissingRanges(int[] nums, int lower, int upper)
	{
		if (nums.Length == 0)
		{
			return new List<string>() { createRange(lower, upper) };
		}
		var retVal = new List<string>();
		if (lower - nums[0] != 0)
		{
			retVal.Add(createRange(lower, nums[0] - 1));
		}
		for (int i = 1; i < nums.Length; i++)
		{
			if (nums[i - 1] - nums[i] + 1 != 0)
			{
				retVal.Add(createRange(nums[i - 1] + 1, nums[i] - 1));
			}
		}
		if (lower != upper && upper - nums[nums.Length - 1] != 0)
		{
			retVal.Add(createRange(nums[nums.Length - 1] + 1, upper));
		}
		return retVal;
	}

	public string createRange(int a, int b)
	{
		return a == b ? $"{a}" : $"{a}->{b}";
	}
}