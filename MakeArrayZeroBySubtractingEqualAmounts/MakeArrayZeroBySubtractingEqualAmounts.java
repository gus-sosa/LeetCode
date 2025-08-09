package MakeArrayZeroBySubtractingEqualAmounts;

import java.util.Arrays;

public class MakeArrayZeroBySubtractingEqualAmounts {
    public static void main(String[] args) {
        var s = new Solution();
        test(s, new int[] { 1, 5, 0, 3, 5 }, 3);
        test(s, new int[] { 0 }, 0);
    }

    private static void test(Solution s, int[] arr, int expectedResult) {
        int result = s.minimumOperations(arr);
        if (result == expectedResult) {
            System.out.println("PASSED");
        } else {
            System.out.println(String.format("FAILED: expected=%s - result=%s - %s", Integer.toString(expectedResult),
                    Integer.toString(result), Arrays.toString(arr)));
        }
    }
}
