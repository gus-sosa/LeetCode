import java.util.Arrays;
import java.util.stream.Collectors;

public class MinimumCommonValue {
    public static void main(String[] args) {
        var s = new Solution();
        System.out.println(s.getCommon(new int[]{1, 2, 3}, new int[]{2, 4}));
    }

    static class Solution {
        public int getCommon(int[] nums1, int[] nums2) {
            var set = Arrays.stream(nums1)
                    .boxed()
                    .collect(Collectors.toSet());

            for(int i : nums2){
                if(set.contains(i)) {
                    return i;
                }
            }
            return -1;
        }
    }
}
