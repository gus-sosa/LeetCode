<Query Kind="Program" />

void Main()
{

}

// Define other methods and classes here
public class Codec
{
	private Dictionary<string, string> dictEncoding = new Dictionary<string, string>();
	private Dictionary<string, string> dictDecoding = new Dictionary<string, string>();
	private string tinyUrlPrefix = "http://tinyurl.com/";

	// Encodes a URL to a shortened URL
	public string encode(string longUrl)
	{
		if (dictEncoding.ContainsKey(longUrl))
		{
			return dictEncoding[longUrl];
		}
		var shortUrl = tinyUrlPrefix + Guid.NewGuid().ToString();
		dictDecoding[shortUrl] = longUrl;
		return dictEncoding[longUrl] = shortUrl;
	}

	// Decodes a shortened URL to its original URL.
	public string decode(string shortUrl)
	{
		return dictDecoding[shortUrl];
	}
}