package LongestBinarySubsequenceLessThanOrEqualToK;

public class LongestBinarySubsequenceLessThanOrEqualToK {
    public static void main(String[] args) {
        var s = new Solution();
        test(s, "1001010", 5, 5);
        test(s, "00101001", 1, 6);
        test(s, "001010101011010100010101101010010", 93951055, 31);
    }

    private static void test(Solution s, String inpuString, int k, int expectedResult) {
        try {
            int result = s.longestSubsequence(inpuString, k);
            if (result == expectedResult) {
                System.out.println("PASS");
            } else {
                System.out.println(String.format("FAIL: (expected,result)=(%d,%d)", expectedResult, result));
            }
        } catch (Exception e) {
            System.out.println(String.format("FAIL: %s", e.getMessage()));
        }
    }
}
