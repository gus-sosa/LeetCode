package MaximumNumberOfJumpsToReachTheLastIndex;

import java.util.Arrays;

public class Solution {
    public int maximumJumps(int[] nums, int target) {
        int[] maxs = new int[nums.length];
        Arrays.fill(maxs, -1);
        maxs[maxs.length - 1] = 0;
        for (int i = nums.length - 2, diff = 0; i >= 0; i--) {
            for (int j = i + 1; j < maxs.length; j++) {
                diff = nums[j] - nums[i];
                if (diff >= -target && diff <= target && maxs[j] >= 0) {
                    maxs[i] = Math.max(maxs[i], maxs[j] + 1);
                }
            }
        }
        return maxs[0];
    }
}
