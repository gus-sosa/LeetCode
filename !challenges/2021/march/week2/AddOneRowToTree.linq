<Query Kind="Program" />

void Main()
{
	var s = new Solution();
	//Input:
	//	A binary tree as following:
	//       4
	//	 /   \
	//    2     6
	//   / \   /
	//  3   1 5
	//
	//v = 1
	//
	//d = 2
	//
	//Output:
	//	4
	//   / \
	//     1   1
	//	/     \
	//   2       6
	//  / \     /
	// 3   1   5
	var input = new TreeNode(4, new TreeNode(2, new TreeNode(3), new TreeNode(1)), new TreeNode(6, new TreeNode(5)));
	var output = new TreeNode(4, new TreeNode(1, new TreeNode(2, new TreeNode(3), new TreeNode(1))), new TreeNode(1, null, new TreeNode(6, new TreeNode(5))));
	AreSame(s.AddOneRow(input, 1, 2), output).Dump();


	//Input:
	//	A binary tree as following:
	//      4
	//	 /
	//	2
	//   / \   
	//  3   1
	//
	//v = 1
	//
	//d = 3
	//
	//Output:
	//	4
	//   /
	//  2
	// / \    
	//  1   1
	// /     \  
	//3       1

	var input1 = new TreeNode(4, new TreeNode(2, new TreeNode(3), new TreeNode(1)));
	var output1 = new TreeNode(4, new TreeNode(2, new TreeNode(1, new TreeNode(3)), new TreeNode(1, null, new TreeNode(1))));
	AreSame(s.AddOneRow(input1, 1, 3), output1).Dump();

}

bool AreSame(TreeNode node1, TreeNode node2)
{
	if (node1 == null && node2 == null)
	{
		return true;
	}
	if (node1 == null || node2 == null)
	{
		return false;
	}
	return node1.val == node2.val && AreSame(node1.left, node2.left) && AreSame(node1.right, node2.right);
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
	public TreeNode AddOneRow(TreeNode root, int v, int d)
	{
		if (d == 1)
		{
			return new TreeNode(v, root);
		}
		var q = new Queue<Tuple<TreeNode, int>>();
		q.Enqueue(Tuple.Create<TreeNode, int>(root, 1));
		TreeNode node;
		int currentLevel = 0;
		while (q.Count > 0)
		{
			node = q.Peek().Item1;
			currentLevel = q.Peek().Item2;
			q.Dequeue();
			if (currentLevel == d - 1)
			{
				var leftNode = new TreeNode(v, node.left);
				var rightNode = new TreeNode(v, null, node.right);
				node.left = leftNode;
				node.right = rightNode;
			}
			else
			{
				if (node.left != null)
				{
					q.Enqueue(Tuple.Create(node.left, currentLevel + 1));
				}
				if (node.right != null)
				{
					q.Enqueue(Tuple.Create(node.right, currentLevel + 1));
				}
			}
		}
		return root;
	}
}