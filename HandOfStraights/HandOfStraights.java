package HandOfStraights;

import java.util.Arrays;

public class HandOfStraights {
    public static void main(String[] args) {
        var solution = new Solution();
        runTest(solution, new int[] { 1, 2, 3, 6, 2, 3, 4, 7, 8 }, 3, true);
        runTest(solution, new int[] { 1, 2, 3, 4, 5 }, 4, false);
        runTest(solution, new int[] { 1, 2, 3, 4, 5, 8, 9, 10 }, 4, false);
        runTest(solution, new int[] { 1, 1, 2, 2, 3, 3 }, 2, false);
    }

    private static void runTest(Solution s, int[] hand, int groupSize, boolean expected) {
        System.out.println("=====START TEST=====");
        try {
            System.out.println(
                    String.format("Running test with hand: %s, group size: %d", Arrays.toString(hand), groupSize));
            boolean result = s.isNStraightHand(hand, groupSize);
            if (expected == result) {
                System.out.println("> PASSED");
            } else {
                System.out.println(String.format("> NOT PASSED, expected: %s", expected));
            }
        } catch (Exception e) {
            System.out.println(String.format("Test failed: %s", e.getMessage()));
        }
        System.out.println("=====END TEST=====");
    }
}