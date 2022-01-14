<Query Kind="Program" />

void Main()
{

}

// Define other methods and classes here
public class Logger
{
	private Dictionary<string, int> dict;
	const int WINDOW_LENGTH = 10;
	public Logger()
	{
		dict = new Dictionary<string, int>();
	}

	public bool ShouldPrintMessage(int timestamp, string message)
	{
		if (!dict.ContainsKey(message))
		{
			dict.Add(message, timestamp);
			return true;
		}
		var lastTimestamp = dict[message];
		if (timestamp >= lastTimestamp + WINDOW_LENGTH)
		{
			dict[message] = timestamp;
			return true;
		}
		return false;
	}
}

/**
 * Your Logger object will be instantiated and called as such:
 * Logger obj = new Logger();
 * bool param_1 = obj.ShouldPrintMessage(timestamp,message);
 */
