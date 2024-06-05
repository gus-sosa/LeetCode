package NumberOfEquivalentDominoPairs;

class Solution {
    public int numEquivDominoPairs(int[][] dominoes) {
        int[][] map = new int[10][];
        for (int i = 0; i < map.length; i++) {
            map[i] = new int[10];
        }

        int min, max;
        for (int[] domino : dominoes) {
            min = Math.min(domino[0], domino[1]);
            max = Math.max(domino[0], domino[1]);
            map[min][max]++;
        }

        int count = 0;
        for (int i = 0, n = 0, j; i < map.length; i++) {
            for (j = 0; j < map[0].length; j++) {
                n = map[i][j];

                count += n * (n - 1) / 2;
            }
        }
        return count;
    }
}