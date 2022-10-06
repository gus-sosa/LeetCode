import javax.xml.crypto.dsig.keyinfo.KeyValue;
import java.util.HashMap;
import java.util.Map;

public class Solution1 {
    public static void main(String[] args) {
        Solution s = new Solution();
        System.out.println(s.countNicePairs(new int[]{42, 11, 1, 97}) == 2);
        System.out.println(s.countNicePairs(new int[]{13, 10, 35, 24, 76}) == 4);
    }
}

class Solution {
    public int countNicePairs(int[] nums) {
        HashMap<Integer, Integer> map = new HashMap<>();
        for (int num : nums) {
            int v = num - reverse(num).intValue();
            if (!map.containsKey(v)) {
                map.put(v, 0);
            }
            map.put(v, map.get(v) + 1);
        }
        long count = 0;
        long module = (long) (Math.pow(10, 9) + 7);
        for (Map.Entry<Integer, Integer> entry : map.entrySet()) {
            long n = (long) entry.getValue();
            count = (count + (n * (n - 1l) / 2l)) % module;
        }
        return (int) count;
    }

    private Integer reverse(int num) {
        Integer retVal = 0;
        while (num > 0) {
            retVal = retVal * 10;
            retVal += num % 10;
            num /= 10;
        }
        return retVal;
    }
}