package NumberOfSubArraysWithOddSum;

public class NumberOfSubArraysWithOddSum {
    public static void main(String[] args) {
        var s = new Solution();
        System.err.println(s.numOfSubarrays(new int[] { 1, 3, 5 }) == 4);
        System.err.println(s.numOfSubarrays(new int[] { 2, 4, 6 }) == 0);
        System.err.println(s.numOfSubarrays(new int[] { 1, 2, 3, 4, 5, 6, 7 }) == 16);
    }
}
