package FindIfArrayCanBeSorted;

import java.util.Arrays;

public class Solution {
    public boolean canSortArray(int[] nums) {
        int numSetBits = getSetBits(nums[0]);
        int start = 0;
        for (int i = 1, currentNumBits = 0; i < nums.length; i++) {
            currentNumBits = getSetBits(nums[i]);
            if (numSetBits != currentNumBits) {
                Arrays.sort(nums, start, i);
                start = i;
                numSetBits = currentNumBits;
            }
        }
        Arrays.sort(nums, start, nums.length);
        return isSorted(nums);
    }

    private boolean isSorted(int[] nums) {
        for (int i = 1; i < nums.length; i++) {
            if (nums[i - 1] > nums[i]) {
                return false;
            }
        }
        return true;
    }

    private int getSetBits(int num) {
        int numBits = 0;
        while (num > 0) {
            numBits += num & 1;
            num >>= 1;
        }
        return numBits;
    }
}
