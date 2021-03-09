<Query Kind="Program">
  <NuGetReference>MoreLinq.Source.MoreEnumerable.ForEach</NuGetReference>
</Query>

void Main()
{
	var s = new Solution();
	s.FourSum(new[] { 1, 0, -1, 0, -2, 2 }, 0).Dump();
}

public class Solution
{
	public IList<IList<int>> FourSum(int[] nums, int target)
	{
		var set = new Dictionary<int, List<int[]>>();
		for (int i = 0; i < nums.Length; i++)
		{
			for (int j = i + 1; j < nums.Length; j++)
			{
				if (!set.ContainsKey(nums[i] + nums[j]))
				{
					set.Add(nums[i] + nums[j], new List<int[]>());
				}
				set[nums[i] + nums[j]].Add(new[] { i, j });
			}
		}
		var response = new Dictionary<int, Dictionary<int, Dictionary<int, HashSet<int>>>>();
		for (int i = 0; i < nums.Length; i++)
		{
			for (int j = i + 1; j < nums.Length; j++)
			{
				var key = -(nums[i] + nums[j]) + target;
				if (set.ContainsKey(key))
				{
					foreach (var element in set[key].Where(s => !s.Contains(i) && !s.Contains(j)))
					{
						var arr = new[] { nums[i], nums[j], nums[element[0]], nums[element[1]] };
						Array.Sort(arr);
						if (!contains(response, arr))
						{
							add(response, arr);
						}

					}
				}
			}
		}
		return getList(response);
	}

	IList<IList<int>> getList(Dictionary<int, Dictionary<int, Dictionary<int, HashSet<int>>>> dict)
	{
		var response = new List<IList<int>>();
		foreach (var keyV1 in dict)
		{
			foreach (var keyV2 in keyV1.Value)
			{
				foreach (var keyV3 in keyV2.Value)
				{
					foreach (var keyV4 in keyV3.Value)
					{
						response.Add(new List<int> { keyV1.Key, keyV2.Key, keyV3.Key, keyV4 });
					}
				}
			}
		}
		return response;
	}

	void add(Dictionary<int, Dictionary<int, Dictionary<int, HashSet<int>>>> dict, int[] arr)
	{
		if (!dict.ContainsKey(arr[0]))
		{
			dict.Add(arr[0], new Dictionary<int, Dictionary<int, HashSet<int>>>());
		}
		if (!dict[arr[0]].ContainsKey(arr[1]))
		{
			dict[arr[0]].Add(arr[1], new Dictionary<int, HashSet<int>>());
		}
		if (!dict[arr[0]][arr[1]].ContainsKey(arr[2]))
		{
			dict[arr[0]][arr[1]].Add(arr[2], new HashSet<int>());
		}
		dict[arr[0]][arr[1]][arr[2]].Add(arr[3]);
	}

	private bool contains(Dictionary<int, Dictionary<int, Dictionary<int, HashSet<int>>>> dict, int[] arr)
	{
		return dict.ContainsKey(arr[0]) && dict[arr[0]].ContainsKey(arr[1]) && dict[arr[0]][arr[1]].ContainsKey(arr[2]) && dict[arr[0]][arr[1]][arr[2]].Contains(arr[3]);
	}
}
