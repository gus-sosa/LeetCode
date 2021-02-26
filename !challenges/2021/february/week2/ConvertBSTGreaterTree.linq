<Query Kind="Program" />

void Main()
{
	var s = new Solution();
	var t1 = new TreeNode(4,
	new TreeNode(1,
		new TreeNode(0),
		new TreeNode(2, null, new TreeNode(3))
	),
	new TreeNode(6,
		new TreeNode(5),
		new TreeNode(7, null, new TreeNode(8))
	));
	var t2 = new TreeNode(30,
	new TreeNode(36,
		new TreeNode(36),
		new TreeNode(35, null, new TreeNode(33))
	),
	new TreeNode(21,
		new TreeNode(26),
		new TreeNode(15, null, new TreeNode(8))
	));
	AreSame(s.ConvertBST(t1), t2).Dump();
}

bool AreSame(TreeNode t1, TreeNode t2)
{
	if (t1 == null && t2 == null)
	{
		return true;
	}
	if (t1 == null || t2 == null)
	{
		return false;
	}
	return t1.val == t2.val && AreSame(t1.left, t2.left) && AreSame(t1.right, t2.right);
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
	private Queue<TreeNode> q = new Queue<TreeNode>();
	public TreeNode ConvertBST(TreeNode root)
	{
		ConvertBSTRecur(root);
		int previousValue = 0;
		TreeNode current;
		while (q.Count > 0)
		{
			current = q.Dequeue();
			current.val += previousValue;
			previousValue = current.val;
		}
		return root;
	}

	private void ConvertBSTRecur(TreeNode root)
	{
		if (root != null)
		{
			ConvertBSTRecur(root.right);
			q.Enqueue(root);
			ConvertBSTRecur(root.left);
		}
	}
}