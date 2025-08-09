package MakeArrayZeroBySubtractingEqualAmounts;

import java.util.Arrays;
import java.util.HashSet;

class Solution {
    public int minimumOperations(int[] nums) {
        var set = new HashSet<Integer>();
        set.addAll(Arrays.stream(nums).boxed().toList());
        set.remove(0);
        return set.size();
    }
}
