<Query Kind="Program" />

void Main()
{

}

// Define other methods and classes herepublic class Solution {
public class Solution
{
	public class Node
	{
		public bool Marked { get; set; }

		public List<Node> Children { get; set; }
		public int Value { get; set; }


		public Node(int v)
		{
			this.Value = v;
			Children = new List<Node>();
		}

		public void AddAdj(Node n)
		{
			this.Children.Add(n);
		}
	}

	public int[] RestoreArray(int[][] adjacentPairs)
	{
		var nodes = new Dictionary<int, Node>();
		foreach (var adj in adjacentPairs)
		{
			var node1 = getNode(adj[0], nodes);
			var node2 = getNode(adj[1], nodes);
			node1.AddAdj(node2);
			node2.AddAdj(node1);
		}
		return getList(nodes);
	}

	int[] getList(Dictionary<int, Node> nodes)
	{
		Node head = nodes.Values.First(i => i.Children.Count == 1);
		var l = new List<int>();
		var q = new Queue<Node>();
		q.Enqueue(head);
		while (q.Count > 0)
		{
			var c = q.Dequeue();
			l.Add(c.Value);
			c.Marked = true;
			foreach (var element in c.Children.Where(i => !i.Marked))
			{
				q.Enqueue(element);
			}
		}
		return l.ToArray();
	}

	private Node getNode(int v, Dictionary<int, Node> nodes)
	{
		if (!nodes.ContainsKey(v))
		{
			nodes.Add(v, new Node(v));
		}
		return nodes[v];
	}
}