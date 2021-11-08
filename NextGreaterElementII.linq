<Query Kind="Program" />

void Main()
{
	var s = new Solution();
	s.NextGreaterElements(new[] { 1, 8, -1, -100, -1, 222, 1111111, -111111}).Dump();
	s.NextGreaterElements(new[] { 5, 4, 3, 2, 1}).Dump();
}

// Define other methods and classes here
public class Solution
{
	public int[] NextGreaterElements(int[] nums)
	{
		int?[] result = new int?[nums.Length];
		for (int i = nums.Length - 1; i >= 0; i--)
		{
			result[i] = null;
			for (int j = i + 1; j < nums.Length; j++)
			{
				if (nums[i] < nums[j])
				{
					result[i] = nums[j];
					break;
				}
			}
		}
		for (int i = 0; i < nums.Length; i++)
		{
			if (result[i] == null)
			{
				for (int j = 0; j < i; j++)
				{
					if (nums[i] < nums[j])
					{
						result[i] = nums[j];
						break;
					}
				}
			}
		}
		return result.Select(i=>i.HasValue?i.Value:-1).ToArray();
	}
}