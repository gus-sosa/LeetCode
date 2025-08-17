package WaysToExpressAnIntegerAsSumOfPowers;

import java.util.HashMap;
import java.util.HashSet;

class Solution {
    private int x;
    private HashMap<Integer, Integer> map;
    private static final Integer MODULE_BIG = Integer.valueOf((int) Math.pow(10, 10));
    private static final Integer MODULE = Integer.valueOf((int) Math.pow(10, 9)) + 7;

    public int numberOfWays(int n, int x) {
        this.x = x;
        return numberOfWays(n) % MODULE;
    }

    private int numberOfWays(int n) {
        if (n==0) {
            return 1;
        }
    }
}