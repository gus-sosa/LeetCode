package RangeProductQueriesOfPowers;

import java.util.ArrayList;
import java.util.List;

class Solution {
    private int n;
    private long[] powers;
    private static long MOD = 7 + (long) Math.pow(10, 9);
    private Long[][] products;

    public int[] productQueries(int n, int[][] queries) {
        this.n = n;
        computePowers();
        products = new Long[powers.length + 1][];
        for (int i = 0; i < powers.length + 1; i++) {
            products[i] = new Long[powers.length + 1];
        }
        List<Long> retVal = List.of(queries).stream().map(query -> getPowersSum(query[0], query[1])).toList();
        return retVal.stream().map(i -> i % MOD).mapToInt(Long::intValue).toArray();
    }

    private void computePowers() {
        var powers = new ArrayList<Long>();
        Long currentPowerOfTwo = (long) Math.pow(2, 30);
        Long currentNum = Integer.toUnsignedLong(n);
        while (currentNum > 0) {
            if (currentPowerOfTwo <= currentNum) {
                powers.add(currentPowerOfTwo);
                currentNum -= currentPowerOfTwo;
            }
            currentPowerOfTwo >>= 1;
        }
        this.powers = powers.reversed().stream().mapToLong(Long::longValue).toArray();
    }

    private Long getPowersSum(int l, int h) {
        if (l == h) {
            return powers[l] % MOD;
        }
        if (products[l][h] != null) {
            return products[l][h] % MOD;
        }
        Long result = getPowersSum(l, h - 1) * powers[h] % MOD;
        products[l][h] = result;
        return result;
    }
}