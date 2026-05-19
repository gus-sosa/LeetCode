package NumberOfOperationsToMakeNetworkConnected;

import java.util.List;

public class NumberOfOperationsToMakeNetworkConnected {
    public static void main(String[] args) {
        var s = new Solution();
        int[][] arr = List.of(
                new int[] { 6, 8 },
                new int[] { 0, 4 },
                new int[] { 1, 2 },
                new int[] { 5, 8 },
                new int[] { 0, 9 },
                new int[] { 1, 8 },
                new int[] { 1, 4 },
                new int[] { 4, 9 },
                new int[] { 4, 6 },
                new int[] { 3, 7 },
                new int[] { 2, 4 },
                new int[] { 3, 5 },
                new int[] { 6, 7 },
                new int[] { 4, 5 }).toArray(int[][]::new);
        System.out
                .println(s.makeConnected(10, arr));
    }
}
