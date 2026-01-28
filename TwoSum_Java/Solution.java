import java.util.HashMap;
import java.util.HashSet;

public class Solution {
    public int[] twoSum(int[] nums, int target) {
        var set = new HashMap<Integer, Integer>();
        set.put(nums[0], 0);
        for (int i = 1, compl, currentNum; i < nums.length; ++i) {
            currentNum = nums[i];
            compl = target - currentNum;
            if (set.containsKey(compl)) {
                return new int[] { set.get(compl), i };
            }
            set.put(currentNum, i);
        }
        return null;
    }
}