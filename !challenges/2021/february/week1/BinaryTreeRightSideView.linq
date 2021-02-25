<Query Kind="Program" />

void Main()
{
	var s = new Solution();
	var root = new TreeNode(1,
		new TreeNode(2, null, new TreeNode(5)),
		new TreeNode(3, null, new TreeNode(4))
	);
	AreEqual(s.RightSideView(root), new int[] { 1, 3, 4 }).Dump();
}

public bool AreEqual(IList<int> l1, IList<int> l2)
{
	return l1.Count == l2.Count && Enumerable.Zip(l1, l2, (first, second) => first == second).All(i => i);
}

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
	public IList<int> RightSideView(TreeNode root)
	{
		if (root==null)
		{
			return new int[0];
		}
		var nodes = new List<int>();
		var queue = new Queue<Tuple<TreeNode, int>>();
		var levels = new HashSet<int>();
		queue.Enqueue(Tuple.Create(root, 0));
		TreeNode currentNode;
		int currentLevel;
		while (queue.Count > 0)
		{
			currentNode = queue.Peek().Item1;
			currentLevel = queue.Peek().Item2;
			queue.Dequeue();
			if (!levels.Contains(currentLevel))
			{
				levels.Add(currentLevel);
				nodes.Add(currentNode.val);
			}
			if (currentNode.right != null)
			{
				queue.Enqueue(Tuple.Create(currentNode.right, currentLevel + 1));
			}
			if (currentNode.left != null)
			{
				queue.Enqueue(Tuple.Create(currentNode.left, currentLevel + 1));
			}
		}
		return nodes;
	}
}