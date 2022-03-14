<Query Kind="Program" />

void Main()
{

}

public class Node
{
	public int val;
	public Node left;
	public Node right;
	public Node parent;
}


public class Solution
{
	public Node LowestCommonAncestor(Node p, Node q)
	{
		Stack<Node> pathP = getPathToRoot(p);
		Stack<Node> pathQ = getPathToRoot(q);

		Node lca = pathP.Pop();
		pathQ.Pop();
		while (pathP.Count > 0 && pathQ.Count > 0 && pathP.Peek().val == pathQ.Peek().val)
		{
			lca = pathP.Pop();
			pathQ.Pop();
		}
		return lca;
	}

	private Stack<Node> getPathToRoot(Node p)
	{
		var s = new Stack<Node>();
		while (p != null)
		{
			s.Push(p);
			p = p.parent;
		}
		return s;
	}
}