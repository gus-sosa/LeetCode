package HouseRobber;

import java.util.HashMap;
import java.util.Map;

public class Solution {
    Map<Integer, Integer> maxSumAtIndex;

    public int rob(int[] nums) {
        maxSumAtIndex = new HashMap<>();
        return robRecur(nums, 0);
    }

    private int robRecur(int[] nums, int index) {
        if (index >= nums.length) {
            return 0;
        }
        if (maxSumAtIndex.containsKey(index)) {
            return maxSumAtIndex.get(index);
        }
        int result = Math.max(robRecur(nums, index + 1), nums[index] + robRecur(nums, index + 2));
        maxSumAtIndex.put(index, result);
        return result;
    }
}