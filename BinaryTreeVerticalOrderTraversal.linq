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
	public IList<IList<int>> VerticalOrder(TreeNode root)
	{
		var dict = new SortedDictionary<int, IList<int>>();
		var q = new Queue<Tuple<TreeNode, int>>();
		q.Enqueue(Tuple.Create(root, 0));
		while (q.Count > 0)
		{
			var c = q.Dequeue();
			var tree = c.Item1;
			var column = c.Item2;
			if (tree == null)
			{
				continue;
			}
			addItemInDict(dict, column, tree);
			q.Enqueue(Tuple.Create(tree.left, column - 1));
			q.Enqueue(Tuple.Create(tree.right, column + 1));
		}
		return dict.Values.ToList();
	}

	private void addItemInDict(SortedDictionary<int, IList<int>> dict, int column, TreeNode tree)
	{
		if (!dict.ContainsKey(column))
		{
			dict.Add(column, new List<int>());
		}
		dict[column].Add(tree.val);
	}
}