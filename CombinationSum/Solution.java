package CombinationSum;

import java.util.ArrayList;
import java.util.List;

class Solution {
    public List<List<Integer>> combinationSum(int[] candidates, int target) {
        var retVal = new ArrayList<List<Integer>>();
        int[] candidatesQuantities = new int[candidates.length];
        combinationSumRecur(0, candidatesQuantities, candidates, target, retVal);
        return retVal;
    }

    private void combinationSumRecur(int currentIndex, int[] candidatesQuantities, int[] candidates, int target,
            List<List<Integer>> allCombinations) {
        if (target == 0) {
            allCombinations.add(buildList(candidatesQuantities, candidates));
            return;
        }
        if (target < 0 || currentIndex >= candidates.length) {
            return;
        }

        combinationSumRecur(currentIndex+1, candidatesQuantities, candidates, target, allCombinations);
        
        for (int i = 1; target - candidates[currentIndex] * i >= 0; ++i) {
            candidatesQuantities[currentIndex] = i;
            combinationSumRecur(currentIndex + 1, candidatesQuantities, candidates,
                    target - candidates[currentIndex] * i, allCombinations);
        }
        candidatesQuantities[currentIndex] = 0;
    }

    private List<Integer> buildList(int[] candidatesQuantities, int[] candidates) {
        var arr = new ArrayList<Integer>();
        for (int i = 0, quantity; i < candidates.length; i++) {
            quantity = candidatesQuantities[i];
            while (quantity > 0) {
                arr.add(candidates[i]);
                --quantity;
            }
        }
        return arr;
    }
}