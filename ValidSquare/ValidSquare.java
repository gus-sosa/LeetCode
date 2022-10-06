public class ValidSquare {
    public static void main(String[] args) {
        Solution s = new Solution();
        System.out.println(s.validSquare(new int[]{0, 0}, new int[]{1, 1}, new int[]{0, 0}, new int[]{1, 1}));
    }
}

class Solution {
    public boolean validSquare(int[] p1, int[] p2, int[] p3, int[] p4) {
        int[][] arr = new int[][]{p1, p2, p3, p4};
        for (int i = 0; i < arr.length; i++) {
            for (int j = 0; j < arr.length; j++) {
                if (i == j) {
                    continue;
                }
                for (int k = 0; k < arr.length; k++) {
                    if (k == i || k == j) {
                        continue;
                    }
                    for (int l = 0; l < arr.length; l++) {
                        if (l == i || l == j || l == k) {
                            continue;
                        }
                        int[] pp1 = arr[i];
                        int[] pp2 = arr[j];
                        int[] pp3 = arr[k];
                        int[] pp4 = arr[l];

                        if (check(pp1, pp2, pp3, pp4)) {
                            return true;
                        }
                    }
                }
            }
        }
        return false;
    }

    public static boolean check(int[] p1, int[] p2, int[] p3, int[] p4) {
        int d = dist(p1, p2);
        int diag = dist(p1, p3);
        return d > 0 && diag > 0 && d == dist(p2, p3) && d == dist(p3, p4) && d == dist(p4, p1) && dist(p1, p3) == dist(p2, p4);
    }

    public static int dist(int[] p1, int[] p2) {
        return (p1[1] - p2[1]) * (p1[1] - p2[1]) + (p1[0] - p2[0]) * (p1[0] - p2[0]);
    }
}