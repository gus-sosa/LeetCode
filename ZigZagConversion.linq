<Query Kind="Program" />

//https://leetcode.com/problems/zigzag-conversion/submissions/

void Main()
{
	var s = new Solution();
	//Input: s = "PAYPALISHIRING", numRows = 3
	//Output: "PAHNAPLSIIGYIR"
	(s.Convert("PAYPALISHIRING", 3) == "PAHNAPLSIIGYIR").Dump();
	//Input: s = "PAYPALISHIRING", numRows = 4
	//Output: "PINALSIGYAHRPI"
	(s.Convert("PAYPALISHIRING", 4) == "PINALSIGYAHRPI").Dump();
	//Input: s = "A", numRows = 1
	//Output: "A"
	(s.Convert("A", 1) == "A").Dump();

	(s.Convert("AB", 1) == "AB").Dump();
	(s.Convert("AB", 2) == "AB").Dump();
	(s.Convert("AB", 3) == "AB").Dump();


	(s.Convert("ABCDE", 5) == "ABCDE").Dump();
	
	(s.Convert("ABCDEF", 5) == "ABCDFE").Dump();
}

// You can define other methods, fields, classes and namespaces here
public class Solution
{
	public string Convert(string s, int numRows)
	{
		if (numRows == 1 || numRows >= s.Length)
		{
			return s;
		}
		var zigzag = Enumerable.Range(0, numRows).Select(i => new List<char>()).ToArray();
		for (int i = 0, currentRow = 0, dir = 1; i < s.Length; i++)
		{
			zigzag[currentRow].Add(s[i]);

			if (currentRow + dir == numRows || currentRow + dir == -1)
			{
				dir *= -1;
			}
			currentRow += dir;
		}
		return getZigZag(zigzag);
	}

	private string getZigZag(List<char>[] zigzag)
	{
		var sb = new StringBuilder();
		foreach (var element in zigzag)
		{
			foreach (var item in element)
			{
				sb.Append(item);
			}
		}
		return sb.ToString();
	}
}