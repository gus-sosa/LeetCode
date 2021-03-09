<Query Kind="Program" />

void Main()
{
	var s = new Solution();
	s.CombinationSum(new[] { 2, 3, 6, 7 }, 7).Dump();
	s.CombinationSum(new[] { 2, 3, 5 }, 8).Dump();
	s.CombinationSum(new[] { 2 }, 1).Dump();
	s.CombinationSum(new[] { 1 }, 1).Dump();
	s.CombinationSum(new[] { 1 }, 2).Dump();
}

public class Solution
{
	private IList<IList<int>> allCombinations;
	private IList<int> currentCombination;
	private int[] candidates;
	public IList<IList<int>> CombinationSum(int[] candidates, int target)
	{
		this.currentCombination = new List<int>();
		this.allCombinations = new List<IList<int>>();
		this.candidates = candidates;
		combinatioSumRecur(0, target);
		return allCombinations;
	}

	private void combinatioSumRecur(int currentCandidatePos, int target)
	{
		if (target == 0)
		{
			allCombinations.Add(new List<int>(currentCombination));
			return;
		}
		if (currentCandidatePos == candidates.Length || target < 0)
		{
			return;
		}
		currentCombination.Add(candidates[currentCandidatePos]);
		combinatioSumRecur(currentCandidatePos, target - candidates[currentCandidatePos]);
		currentCombination.RemoveAt(currentCombination.Count - 1);
		combinatioSumRecur(currentCandidatePos + 1, target);
	}
}
