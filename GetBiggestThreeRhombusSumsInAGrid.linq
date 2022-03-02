<Query Kind="Program" />

void Main()
{
	var s = new Solution();
	//s.GetBiggestThree(new[] {
	//new[]{3,4,5,1,3},
	//new[]{3,3,4,2,3},
	//new[]{20,30,200,40,10},
	//new[]{1,5,5,4,1},
	//new[]{4,3,2,2,5}
	//}).Dump();// [228,216,211]
	s.GetBiggestThree(new[] {
	new[]{7,7,7}
	}).Dump();//[7]
}

// Define other methods and classes here
public class Solution
{
	int[][] grid;
	int n, m;
	public int[] GetBiggestThree(int[][] grid)
	{
		this.grid = grid;
		n = grid.Length;
		m = grid[0].Length;
		var l = new SortedSet<int>();
		foreach (var sum in getSums())
		{
			l.Add(sum);
			if (l.Count > 3)
			{
				l.Remove(l.Min);
			}
		}
		return l.Reverse().ToArray();
	}

	private IEnumerable<int> getSums()
	{
		for (int i = 0; i < n; i++)
		{
			for (int j = 0; j < m; j++)
			{
				for (int l = 1; l <= n; l++)
				{
					int sum = getRhombusSum(i, j, l);
					if (sum == -1)
					{
						break;
					}
					yield return sum;
				}

			}
		}
	}

	private int getRhombusSum(int i, int j, int l)
	{
		if (l == 1)
		{
			return grid[i][j];
		}
		ValueTuple<int, int> pos1 = ValueTuple.Create(i, j);
		ValueTuple<int, int> pos2 = ValueTuple.Create(i + l - 1, j + l - 1);
		ValueTuple<int, int> pos3 = ValueTuple.Create(pos2.Item1 + l - 1, pos2.Item2 - l + 1);
		ValueTuple<int, int> pos4 = ValueTuple.Create(pos1.Item1 + l - 1, pos1.Item2 - l + 1);

		if (!isInside(pos1) || !isInside(pos2) || !isInside(pos3) || !isInside(pos4))
		{
			return -1;
		}

		int[] rowDirs = new int[] { 1, 1, -1, -1 };
		int[] colDirs = new int[] { 1, -1, -1, 1 };
		var poss = new[] { pos2, pos3, pos4, pos1 };
		int sum = 0;
		for (int iDir = 0; iDir < rowDirs.Length; iDir++)
		{
			while (i != poss[iDir].Item1 && j != poss[iDir].Item2)
			{
				sum += grid[i][j];
				i += rowDirs[iDir];
				j += colDirs[iDir];
			}
		}
		return sum;
	}

	private bool isInside(ValueTuple<int, int> t)
	{
		return t.Item1 >= 0 && t.Item2 >= 0 && t.Item1 < n && t.Item2 < m;
	}
}