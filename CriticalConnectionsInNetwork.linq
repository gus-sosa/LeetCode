<Query Kind="Program" />

//https://leetcode.com/problems/critical-connections-in-a-network/

void Main()
{
	var s = new Solution();

	//IList<IList<int>> input = new IList<int>[]
	//{
	//new List<int>(){0,1},
	//new List<int>(){1,2},
	//new List<int>(){2,0},
	//new List<int>(){1,3}
	//}.ToList();

	//s.CriticalConnections(4, input);

	//IList<IList<int>> input1 = new IList<int>[]
	//{
	//new List<int>(){1,0},
	//new List<int>(){2,0},
	//new List<int>(){3,2},
	//new List<int>(){4,2},
	//new List<int>(){4,3},
	//new List<int>(){3,0},
	//new List<int>(){4,0}
	//}.ToList();
	//s.CriticalConnections(5, input1);

	IList<IList<int>> input2 = new IList<int>[]
	{
	new List<int>(){1,0},
	new List<int>(){2,0},
	new List<int>(){3,0},
	new List<int>(){4,1},
	new List<int>(){4,2},
	new List<int>(){4,0}
	}.ToList();
	s.CriticalConnections(5, input2);
}

// Define other methods and classes here
public class Solution
{
	public IList<IList<int>> CriticalConnections(int n, IList<IList<int>> connections)
	{
		int[,] graph = buildGraph(connections);
		bool[] marked=new bool[n];
		dfs(0,marked)
	}

	private int[,] buildGraph(IList<IList<int>> connections)
	{
		throw new NotImplementedException();
	}
}