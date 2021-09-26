<Query Kind="Program" />

void Main()
{
	var s = new Solution();
	(s.Multiply("9133", "0") == "0").Dump();
	(s.Multiply("0", "0") == "0").Dump();
	(s.Multiply("2", "3") == "6").Dump();
	(s.Multiply("123", "456") == "56088").Dump();
}

// You can define other methods, fields, classes and namespaces here
public class Solution
{
	public string Multiply(string num1, string num2)
	{
		string result = "0";
		int trailingZeros = 0;
		for (int i = num2.Length - 1; i >= 0; i--)
		{
			string mul = multi(num1, num2[i]);
			result = sum(result, mul + new string('0', trailingZeros));
			++trailingZeros;
		}
		result = removeLeadingZeros(result);
		return result;
	}

	string removeLeadingZeros(string result)
	{
		if (result.All(i => i == '0'))
		{
			return "0";
		}
		var sb = new StringBuilder();
		int i = 0;
		while (i < result.Length && result[i] == '0')
		{
			++i;
		}
		while (i < result.Length)
		{
			sb.Append(result[i]);
			++i;
		}
		return sb.ToString();
	}

	string sum(string s1, string s2)
	{
		var sb = new StringBuilder();
		int i = s1.Length - 1;
		int j = s2.Length - 1;
		int sum = 0, carry = 0;
		while (i >= 0 && j >= 0)
		{
			sum = int.Parse(s1[i].ToString()) + int.Parse(s2[j].ToString()) + carry;
			sb.Insert(0, sum % 10);
			carry = sum / 10;
			--i;
			--j;
		}
		while (i >= 0)
		{
			sum = int.Parse(s1[i].ToString()) + carry;
			sb.Insert(0, sum % 10);
			carry = sum / 10;
			--i;
		}
		while (j >= 0)
		{
			sum = int.Parse(s2[j].ToString()) + carry;
			sb.Insert(0, sum % 10);
			carry = sum / 10;
			--j;
		}
		while (carry > 0)
		{
			sb.Insert(0, carry % 10);
			carry /= 10;
		}
		return sb.ToString();
	}

	private string multi(string num, char numDigit)
	{
		var sb = new StringBuilder();
		int digit = int.Parse(numDigit.ToString());
		int carry = 0, sum = 0;
		for (int i = num.Length - 1; i >= 0; i--)
		{
			sum = digit * int.Parse(num[i].ToString()) + carry;
			sb.Insert(0, sum % 10);
			carry = sum / 10;
		}
		while (carry > 0)
		{
			sb.Insert(0, carry % 10);
			carry /= 10;
		}
		return sb.ToString();
	}
}