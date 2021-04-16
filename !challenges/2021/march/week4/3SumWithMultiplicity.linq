<Query Kind="Program" />

void Main()
{
	var s = new Solution();
	(s.ThreeSumMulti(new int[] { 1, 1, 2, 2, 3, 3, 4, 4, 5, 5 }, 8) == 20).Dump();
}

// You can define other methods, fields, classes and namespaces here
public class Solution
{
	public int ThreeSumMulti(int[] arr, int target)
	{
		Array.Sort(arr);
		int count = 0, mod = (int)Math.Pow(10, 9) + 7, a, b, c, t, left, right;
		for (int i = 0, j, k; i < arr.Length; i++)
		{
			a = arr[i];
			j = i + 1;
			k = arr.Length - 1;
			t = target - a;
			while (j < k)
			{
				b = arr[j];
				c = arr[k];
				if (b + c < t)
				{
					++j;
				}
				else if (b + c > t)
				{
					--k;
				}
				else if (b != c)
				{
					left = 1;
					right = 1;
					while (j + 1 < k && arr[j] == arr[j + 1])
					{
						++left;
						++j;
					}
					while (k - 1 > j && arr[k] == arr[k - 1])
					{
						++right;
						--k;
					}
					count = (count + left * right) % mod;
					++j;
					--k;
				}
				else
				{
					count += (k - j + 1) * (k - j) / 2;
					count %= mod;
					break;
				}
			}
		}
		return count;
	}
}