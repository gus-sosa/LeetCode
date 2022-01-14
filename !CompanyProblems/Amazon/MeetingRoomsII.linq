<Query Kind="Program" />

void Main()
{
	var s = new Solution();
	(s.MinMeetingRooms(new[] { new[] { 13, 15 }, new[] { 1, 13 } }) == 1).Dump();
	(s.MinMeetingRooms(new[] { new[] { 0, 30 }, new[] { 5, 10 }, new[] { 15, 20 } }) == 2).Dump();
	(s.MinMeetingRooms(new[] { new[] { 7, 10 }, new[] { 2, 4 } }) == 1).Dump();
}

// Define other methods and classes here
public class Solution
{
	public int MinMeetingRooms(int[][] intervals)
	{
		var sorter = new IntervalSorter();
		var intervalss = new List<int[]>(intervals);
		var rooms = new List<List<int[]>>();
		intervalss.Sort(sorter);
		foreach (var interval in intervalss)
		{
			int index = findAvailableRoom(interval, rooms);
			if (index == -1)
			{
				rooms.Add(new List<int[]>(intervals.Length));
				rooms[rooms.Count - 1].Add(interval);
			}
		}
		return rooms.Count;
	}

	class IntervalSorter : IComparer<int[]>
	{
		public int Compare(int[] x, int[] y)
		{
			return x[0].CompareTo(y[0]);
		}
	}

	private int findAvailableRoom(int[] interval, List<List<int[]>> rooms)
	{
		for (int i = 0; i < rooms.Count; i++)
		{
			var currentRoom = rooms[i];
			if (currentRoom[currentRoom.Count - 1][1] <= interval[0])
			{
				currentRoom.Add(interval);
				return currentRoom.Count - 1;
			}
			if (interval[1] <= currentRoom[0][0])
			{
				currentRoom.Insert(0, interval);
				return 0;
			}
			for (int j = currentRoom.Count - 1; j > 0; j--)
			{
				if (currentRoom[j - 1][1] <= interval[0] && interval[1] <= currentRoom[j][0])
				{
					currentRoom.Insert(i, interval);
					return i;
				}
			}
		}
		return -1;
	}
}