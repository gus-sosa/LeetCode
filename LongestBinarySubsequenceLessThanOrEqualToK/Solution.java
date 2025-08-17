package LongestBinarySubsequenceLessThanOrEqualToK;

public class Solution {
    public int longestSubsequence(String s, int k) {
        int lengthLongestSubsequence = 0, currentNumber = 0, index = 0;
        for (int i = s.length() - 1; i >= 0; i--, index++) {
            if (s.charAt(i) == '0') {
                lengthLongestSubsequence++;
                continue;
            }
            if (index<=29 && currentNumber + (1 << index) <= k) {
                currentNumber += 1 << index;
                lengthLongestSubsequence++;
            }
        }
        return lengthLongestSubsequence;
    }
}