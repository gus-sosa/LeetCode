package MinimumAddToMakeParenthesesValid;

public class Solution {
    public int minAddToMakeValid(String s) {
        int numOpenParentheses = 0;
        int requiredOpenParentheses = 0;
        for (int i = 0; i < s.length(); i++) {
            if (s.charAt(i) == '(') {
                numOpenParentheses++;
            } else {
                if (numOpenParentheses == 0) {
                    requiredOpenParentheses++;
                } else {
                    numOpenParentheses--;
                }
            }
        }

        return requiredOpenParentheses + numOpenParentheses;
    }
}