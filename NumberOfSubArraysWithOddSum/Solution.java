package NumberOfSubArraysWithOddSum;

class Solution {
    public int numOfSubarrays(int[] arr) {
        int numberSubArrayWithEvenSum = arr[arr.length - 1] % 2 == 0 ? 1 : 0;
        int numberSubArrayWithOddSum = arr[arr.length - 1] % 2 == 1 ? 1 : 0;
        int temp = 0;
        int mod = 7 + (int) Math.pow(10, 9);
        int result = numberSubArrayWithOddSum;

        for (int i = arr.length - 2; i >= 0; i--) {
            if (arr[i] % 2 == 0) {
                numberSubArrayWithEvenSum = (1 + numberSubArrayWithEvenSum) % mod;
            } else {
                temp = numberSubArrayWithOddSum;
                numberSubArrayWithOddSum = (1 + numberSubArrayWithEvenSum) % mod;
                numberSubArrayWithEvenSum = temp;
            }
            result = (result + numberSubArrayWithOddSum) % mod;
        }

        return result;
    }
}