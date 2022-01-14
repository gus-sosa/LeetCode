<Query Kind="Program" />

void Main()
{

}

// Define other methods and classes here
public class TreeNode
{
	public int val;
	public TreeNode left;
	public TreeNode right;
	public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
	{
		this.val = val;
		this.left = left;
		this.right = right;
	}
}

public class Solution
{
	public IList<IList<int>> VerticalTraversal(TreeNode root)
	{
		var dict = new SortedDictionary<int, SortedDictionary<int, SortedDictionary<int, int>>>();
		var q = new Queue<ValueTuple<TreeNode, int, int>>();
		q.Enqueue(ValueTuple.Create(root, 0, 0));
		while (q.Count > 0)
		{
			var current = q.Dequeue();
			var tree = current.Item1;
			var row = current.Item2;
			var column = current.Item3;
			if (!dict.ContainsKey(column))
			{
				dict.Add(column, new SortedDictionary<int, SortedDictionary<int, int>>());
			}
			if (!dict[column].ContainsKey(row))
			{
				dict[column].Add(row, new SortedDictionary<int, int>());
			}
			if (!dict[column][row].ContainsKey(tree.val))
			{
				dict[column][row].Add(tree.val, 0);
			}
			dict[column][row][tree.val] += 1;
			if (tree.left != null)
			{
				q.Enqueue(ValueTuple.Create(tree.left, row + 1, column - 1));
			}
			if (tree.right != null)
			{
				q.Enqueue(ValueTuple.Create(tree.right, row + 1, column + 1));
			}
		}
		var retVal = new List<IList<int>>();
		foreach (var col in dict)
		{
			var currentList = new List<int>();
			foreach (var row in col.Value)
			{
				foreach (var v in row.Value)
				{
					for (int i = 0; i < v.Value; i++)
					{
						currentList.Add(v.Key);
					}
				}
			}
			retVal.Add(currentList);
		}
		return retVal;
	}
}