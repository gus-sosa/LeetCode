<Query Kind="Program" />

void Main()
{
	var s = new Solution();
	TreeNode tree = new TreeNode(3, new TreeNode(9), new TreeNode(20, new TreeNode(15), new TreeNode(7)));
	AreEqual(s.AverageOfLevels(tree), new double[] { 3, 14.5, 11 }).Dump();
}

bool AreEqual(IList<double> l1, double[] l2)
{
	return l1.Count == l2.Length && Enumerable.Zip(l1, l2, (f, s) => f == s).All(i => i);
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
	public IList<double> AverageOfLevels(TreeNode root)
	{
		var levelsSum = new Dictionary<int, long>();
		var levelCount = new Dictionary<int, int>();
		var queue = new Queue<Tuple<int, TreeNode>>();
		queue.Enqueue(Tuple.Create(1, root));
		TreeNode currentNode;
		int currentLevel;
		while (queue.Count > 0)
		{
			currentNode = queue.Peek().Item2;
			currentLevel = queue.Peek().Item1;
			queue.Dequeue();
			if (levelsSum.ContainsKey(currentLevel))
			{
				levelsSum[currentLevel] += currentNode.val;
				levelCount[currentLevel] += 1;
			}
			else
			{
				levelsSum[currentLevel] = currentNode.val;
				levelCount[currentLevel] = 1;
			}
			if (currentNode.left != null)
			{
				queue.Enqueue(Tuple.Create(currentLevel + 1, currentNode.left));
			}
			if (currentNode.right != null)
			{
				queue.Enqueue(Tuple.Create(currentLevel + 1, currentNode.right));
			}
		}
		currentLevel = 1;
		var response = new List<double>(levelsSum.Count);
		while (levelsSum.ContainsKey(currentLevel))
		{
			response.Add(levelsSum[currentLevel] / (1D * levelCount[currentLevel]));
			++currentLevel;
		}
		return response;
	}
}