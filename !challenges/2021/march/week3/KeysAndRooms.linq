<Query Kind="Program" />

void Main()
{

}

// Define other methods and classes here
public class Solution
{
	private IList<IList<int>> rooms;
	private bool[] marks;
	public bool CanVisitAllRooms(IList<IList<int>> rooms)
	{
		this.marks = new bool[rooms.Count];
		this.rooms = rooms;
		dfs(0);
		return marks.All(i => i);
	}

	private void dfs(int pos)
	{
		if (pos == rooms.Count)
		{
			return;
		}
		marks[pos] = true;
		foreach (var key in rooms[pos])
		{
			if (!marks[key])
			{
				dfs(key);
			}
		}
	}
}