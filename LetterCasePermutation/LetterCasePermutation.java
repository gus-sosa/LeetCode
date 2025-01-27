package LetterCasePermutation;

import java.util.List;

public class LetterCasePermutation {
    public static void main(String[] args) {
        var s = new Solution();
        runTest(s,"a1b2",4);
        runTest(s,"3z4",2);
    }

    private static void runTest(Solution s, String input, Integer expectedLength) {
        System.out.println("=======START TEST========");
        List<String> result = s.letterCasePermutation(input);
        System.out.println("Result: " + result);
        if (expectedLength==result.size()) {
            System.out.println("Test passed");
        } else {
            System.out.println("Test failed");
        }
        System.out.println("=======END TEST========");
    }
}