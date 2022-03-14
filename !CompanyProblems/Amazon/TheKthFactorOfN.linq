<Query Kind="Program" />

void Main()
{

}

// Define other methods and classes here
public class Solution
{
	public int KthFactor(int n, int k)
	{
		int factorCount = 0;
		for (int i = 1; i <= 1000; i++)
		{
			if (n % i == 0)
			{
				++factorCount;
			}
			if (factorCount == k)
			{
				return i;
			}
		}
		return -1;
	}
}