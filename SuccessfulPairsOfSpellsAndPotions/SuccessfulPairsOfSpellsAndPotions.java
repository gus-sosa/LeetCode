package SuccessfulPairsOfSpellsAndPotions;

import java.util.Arrays;

public class SuccessfulPairsOfSpellsAndPotions {
    public static void main(String[] args) {
        var s = new Solution();
        test(s, new int[] { 5, 1, 3 }, new int[] { 1, 2, 3, 4, 5 }, 7, new int[] { 4, 0, 3 });
        test(s, new int[] { 3, 1, 2 }, new int[] { 8, 5, 8 }, 16, new int[] { 2, 0, 2 });
    }

    private static void test(Solution s, int[] spells, int[] potions, int success, int[] expectedSolution) {
        try {
            int[] result = s.successfulPairs(spells, potions, success);
            if (Arrays.equals(result, expectedSolution)) {
                System.out.println("PASSED");
            } else {
                System.out.println("FAILED");
            }
        } catch (Exception error) {
            System.out.println(String.format("EXCEPTION: %s", error.getMessage()));
        }
    }
}
