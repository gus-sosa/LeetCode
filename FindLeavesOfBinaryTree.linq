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
	public IList<IList<int>> FindLeaves(TreeNode root)
	{
		var retVal = new List<IList<int>>();
		while (!isLeaf(root))
		{
			retVal.Add(getLeafs(root));
			removeLeafs(root);
		}
		retVal.Add(new List<int> { root.val });
		return retVal;
	}

	bool removeLeafs(TreeNode root)
	{
		if (root == null)
		{
			return false;
		}
		bool flag = root.left == null && root.right == null;
		if (removeLeafs(root.left))
		{
			root.left = null;
		}
		if (removeLeafs(root.right))
		{
			root.right = null;
		}
		return flag;
	}

	IList<int> getLeafs(TreeNode root)
	{
		if (root == null)
		{
			return new List<int>();
		}
		if (isLeaf(root))
		{
			return new List<int>() { root.val };
		}
		var leafs = getLeafs(root.left);
		foreach (var element in getLeafs(root.right))
		{
			leafs.Add(element);
		}
		return leafs;
	}

	bool isLeaf(TreeNode root)
	{
		return root.left == null && root.right == null;
	}
}