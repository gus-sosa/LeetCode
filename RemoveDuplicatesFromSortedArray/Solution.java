package RemoveDuplicatesFromSortedArray;

import java.util.HashSet;

class Solution {
    public int removeDuplicates(int[] nums) {
        int index = 0;
        var set = new HashSet<Integer>();
        for (int i = 0; i < nums.length; i++) {
            if (!set.contains(nums[i])) {
                set.add(nums[i]);
                nums[index] = nums[i];
                index++;
            }
        }
        return index;
    }
}