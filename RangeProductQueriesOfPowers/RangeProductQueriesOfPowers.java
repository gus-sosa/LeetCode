package RangeProductQueriesOfPowers;

import java.util.Arrays;

public class RangeProductQueriesOfPowers {
    public static void main(String[] args) {
        var s = new Solution();
        // System.err.println(s.productQueries(15, new int[][] { { 0, 1 }, { 2, 2 }, {
        // 0, 3 } }));
        // System.err.println(s.productQueries(2, new int[][] { { 0, 0 } }));
        int n = 39;
        int[][] queries = new int[][] { { 1, 1 }, { 3, 3 }, { 0, 3 }, { 1, 3 }, { 3, 3 }, { 0, 3 } };
        System.err.println(Arrays.toString(s.productQueries(n, queries)));
    }
}
