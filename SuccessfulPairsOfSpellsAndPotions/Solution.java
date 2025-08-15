package SuccessfulPairsOfSpellsAndPotions;

import java.util.Arrays;

class Solution {
    public int[] successfulPairs(int[] spells, int[] potions, long success) {
        Arrays.sort(potions);
        int[] result = new int[spells.length];
        for (int i = 0; i < spells.length; i++) {
            int currentSpell = spells[i];
            if (currentSpell >= success) {
                result[i] = potions.length;
            } else {
                long target = Math.ceilDiv(success, spells[i]);
                result[i] = potions.length - findIndexLowestHigherThan(potions, 0, potions.length - 1, target);
            }
        }
        return result;
    }

    private int findIndexLowestHigherThan(int[] arr, int start, int end, long target) {
        int result = arr.length, middle;
        while (start <= end) {
            middle = (start + end) / 2;
            if (arr[middle] >= target) {
                end = middle - 1;
                result = middle;
            } else {
                start = middle + 1;
            }
        }
        return result;
    }
}