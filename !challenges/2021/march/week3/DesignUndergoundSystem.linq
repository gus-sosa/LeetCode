<Query Kind="Program">
  <Namespace>System.Diagnostics.CodeAnalysis</Namespace>
</Query>

void Main()
{
	var undergroundSystem = new UndergroundSystem();
	undergroundSystem.CheckIn(45, "Leyton", 3);
	undergroundSystem.CheckIn(32, "Paradise", 8);
	undergroundSystem.CheckIn(27, "Leyton", 10);
	undergroundSystem.CheckOut(45, "Waterloo", 15);
	undergroundSystem.CheckOut(27, "Waterloo", 20);
	undergroundSystem.CheckOut(32, "Cambridge", 22);
	(undergroundSystem.GetAverageTime("Paradise", "Cambridge") == 14.00000).Dump();
	(undergroundSystem.GetAverageTime("Leyton", "Waterloo") == 11.00000).Dump();
	undergroundSystem.CheckIn(10, "Leyton", 24);
	(undergroundSystem.GetAverageTime("Leyton", "Waterloo") == 11.00000).Dump();
	undergroundSystem.CheckOut(10, "Waterloo", 38);
	(undergroundSystem.GetAverageTime("Leyton", "Waterloo") == 12.00000).Dump();
	//
	//
	"another one".Dump();
	undergroundSystem = new UndergroundSystem();
	undergroundSystem.CheckIn(10, "Leyton", 3);
	undergroundSystem.CheckOut(10, "Paradise", 8);
	(undergroundSystem.GetAverageTime("Leyton", "Paradise") == 5.00000).Dump();
	undergroundSystem.CheckIn(5, "Leyton", 10);
	undergroundSystem.CheckOut(5, "Paradise", 16);
	(undergroundSystem.GetAverageTime("Leyton", "Paradise") == 5.50000).Dump();
	undergroundSystem.CheckIn(2, "Leyton", 21);
	undergroundSystem.CheckOut(2, "Paradise", 30);
	undergroundSystem.GetAverageTime("Leyton", "Paradise").Dump();
	(undergroundSystem.GetAverageTime("Leyton", "Paradise") == 6.66667).Dump();
}

// You can define other methods, fields, classes and namespaces here
public class UndergroundSystem
{
	private Dictionary<int, Tuple<string, int>> checkin = new Dictionary<int, System.Tuple<string, int>>();
	private Dictionary<string, Dictionary<string, int>> dist = new Dictionary<string, System.Collections.Generic.Dictionary<string, int>>();
	private Dictionary<string, Dictionary<string, int>> freq = new Dictionary<string, System.Collections.Generic.Dictionary<string, int>>();

	public UndergroundSystem()
	{
	}

	public void CheckIn(int id, string stationName, int t)
	{
		checkin.Add(id, Tuple.Create(stationName, t));
	}

	public void CheckOut(int id, string stationName, int t)
	{
		var checkInInfo = checkin[id];
		checkin.Remove(id);
		if (!dist.ContainsKey(checkInInfo.Item1))
		{
			dist.Add(checkInInfo.Item1, new Dictionary<string, int>());
			freq.Add(checkInInfo.Item1, new Dictionary<string, int>());
		}
		if (!dist[checkInInfo.Item1].ContainsKey(stationName))
		{
			dist[checkInInfo.Item1].Add(stationName, 0);
			freq[checkInInfo.Item1].Add(stationName, 0);
		}
		dist[checkInInfo.Item1][stationName] += t - checkInInfo.Item2;
		freq[checkInInfo.Item1][stationName] += 1;
	}

	public double GetAverageTime(string startStation, string endStation)
	{
		if (!dist.ContainsKey(startStation) || !dist[startStation].ContainsKey(endStation))
		{
			return 0;
		}
		return Math.Round(dist[startStation][endStation] / (freq[startStation][endStation] * 1d), 5);
	}
}

/**
 * Your UndergroundSystem object will be instantiated and called as such:
 * UndergroundSystem obj = new UndergroundSystem();
 * obj.CheckIn(id,stationName,t);
 * obj.CheckOut(id,stationName,t);
 * double param_3 = obj.GetAverageTime(startStation,endStation);
 */