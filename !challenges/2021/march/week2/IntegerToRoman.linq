<Query Kind="Program" />

void Main()
{
	var s = new Solution();
	string[] arr = new[] { "I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX", "X", "XI", "XII", "XIII", "XIV", "XV", "XVI", "XVII", "XVIII", "XIX", "XX" };
	for (int i = 0; i < arr.Length; i++)
	{
		(i + 1).Dump();
		(s.IntToRoman(i + 1) == arr[i]).Dump();
	}
	"other tests".Dump();
	(s.IntToRoman(58) == "LVIII").Dump();
	(s.IntToRoman(1994) == "MCMXCIV").Dump();
	(s.IntToRoman(80) == "LXXX").Dump();
}

// Define other methods and classes here


public class Solution
{
	private int[] nums = new int[] { 1, 5, 10, 50, 100, 500, 1000 };
	private char[] numsRepresentation = new char[] { 'I', 'V', 'X', 'L', 'C', 'D', 'M' };

	public string IntToRoman(int num)
	{
		string[] romans = getNumRepresentation(num).Select(i => convertToRoman(i)).ToArray();
		var sb = new StringBuilder();
		foreach (var element in romans)
		{
			sb.Append(element);
		}
		return sb.ToString();
	}

	string convertToRoman(int num)
	{
		if (num <= 0)
		{
			return string.Empty;
		}
		if (num >= nums[nums.Length - 1])
		{
			return numsRepresentation[nums.Length - 1] + convertToRoman(num - nums[nums.Length - 1]);
		}
		int i;
		for (i = nums.Length - 1; i > 0; i--)
		{
			if (nums[i - 1] <= num && num <= nums[i])
			{
				break;
			}
		}
		if (num == nums[i])
		{
			return numsRepresentation[i].ToString();
		}
		if (num == nums[i - 1])
		{
			return numsRepresentation[i - 1].ToString();
		}
		switch (numsRepresentation[i])
		{
			case 'V':
			case 'X':
				if (nums[i] - 1 == num)
				{
					return "I" + numsRepresentation[i];
				}
				break;
			case 'L':
			case 'C':
				if (nums[i] - 10 == num)
				{
					return "X" + numsRepresentation[i];
				}
				break;
			case 'D':
			case 'M':
				if (nums[i] - 100 == num)
				{
					return "C" + numsRepresentation[i];
				}
				break;
			default:
				throw new ApplicationException("not existing case");
		}
		--i;
		for (; i >= 0; i--)
		{
			if (nums[i] <= num)
			{
				break;
			}
		}
		return numsRepresentation[i].ToString() + convertToRoman(num - nums[i]);
	}

	private int[] getNumRepresentation(int num)
	{
		int counter = 0;
		var representation = new List<int>();
		while (num > 0)
		{
			representation.Add((num % 10) * (int)Math.Pow(10, counter));
			num /= 10;
			++counter;
		}
		representation.Reverse();
		return representation.ToArray();
	}
}