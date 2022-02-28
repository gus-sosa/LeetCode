<Query Kind="Program" />

void Main()
{
	SparseVector v1 = new SparseVector(new[] { 1, 0, 0, 2, 3 });
	int ans = v1.DotProduct(new SparseVector(new[] { 0, 3, 0, 4, 0 }));
	ans.Dump();
}

// Define other methods and classes here
public class SparseVector
{
	Dictionary<int, int> dict;
	int lenght = 0;
	public SparseVector(int[] nums)
	{
		dict = new Dictionary<int, int>();
		foreach (var element in nums)
		{
			++lenght;
			if (element != 0)
			{
				dict.Add(lenght, element);
			}
		}
	}

	// Return the dotProduct of two sparse vectors
	public int DotProduct(SparseVector vec)
	{
		int max = Math.Min(this.lenght, vec.lenght);
		int result = 0;
		foreach (var element in dict)
		{
			if (element.Key <= max && vec.dict.ContainsKey(element.Key))
			{
				result += element.Value * vec.dict[element.Key];
			}
		}
		return result;
	}
}

