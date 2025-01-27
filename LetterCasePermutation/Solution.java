package LetterCasePermutation;

import java.util.ArrayList;
import java.util.List;

class Solution {
    private String s;
    private StringBuilder sb;
    private List<String> retVal;

    public List<String> letterCasePermutation(String s) {
        this.retVal = new ArrayList<String>();
        this.s = s;
        sb = new StringBuilder();
        letterCasePermutationRecur(0);
        return retVal;
    }

    private void letterCasePermutationRecur(Integer index) {
        if (index == s.length()) {
            retVal.add(sb.toString());
            return;
        }
        if (Character.isLetter(s.charAt(index))) {
            sb.append(Character.toUpperCase(s.charAt(index)));
            letterCasePermutationRecur(index + 1);
            sb.deleteCharAt(sb.length() - 1);
            sb.append(Character.toLowerCase(s.charAt(index)));
            letterCasePermutationRecur(index + 1);
            sb.deleteCharAt(sb.length() - 1);
        } else {
            sb.append(s.charAt(index));
            letterCasePermutationRecur(index + 1);
            sb.deleteCharAt(sb.length() - 1);
        }
    }
}