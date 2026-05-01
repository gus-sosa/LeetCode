import java.util.HashSet;

class Solution {
    public int countDistinctIntegers(int[] nums) {
        var s = new HashSet<Integer>();
        for (Integer num : nums) {
            s.add(num);
            s.add(reverse(num));
        }
        return s.size();
    }

    private int reverse(int num) {
        int result = 0;
        while (num > 0) {
            result *= 10;
            result += num % 10;
            num /= 10;
        }
        return result;
    }
}