package MaximumNonNegativeProductInA_Matrix;

import java.util.Arrays;

public class MaximumNonNegativeProductInA_Matrix {
    public static void main(String[] args) {
        System.out.println(Integer.MAX_VALUE);

        test(new int[][] {
                new int[] { -1, -2, -3 },
                new int[] { -2, -3, -3 },
                new int[] { -3, -3, -2 }
        }, -1);

        test(new int[][] {
                new int[] { 1, -2, 1 },
                new int[] { 1, -2, 1 },
                new int[] { 3, -4, 1 }
        }, 8);

        test(new int[][] {
                new int[] { 1, 3 },
                new int[] { 0, -4 }
        }, 0);

        test(new int[][] {
                new int[] { 1, 3, -2 },
                new int[] { 0, -4, 1 }
        }, 0);

        test(new int[][] {
                new int[] { 1, 3, -2 },
                new int[] { 0, -4, -1 }
        }, 12);
    }

    private static void test(int[][] grid, int expectedResult) {
        var s = new Solution();
        int result = 0;
        try {
            result = s.maxProductPath(grid);
        } catch (Exception e) {
            System.out.println(String.format("EXCEPTION: input=%s - error=%s", Arrays.toString(grid), e.getMessage()));
            return;
        }
        if (result == expectedResult) {
            System.out.println("PASSED");
        } else {
            System.out.println(String.format("FAILED: expectedResult=%s - result=%s - input=%s",
                    Integer.toString(expectedResult), Integer.toString(result), Arrays.toString(grid)));
        }
    }
}
