package StringWithoutAAAOrBBB;
//https://leetcode.com/problems/string-without-aaa-or-bbb/description/
public class Program {
    public static void main(String[] args) {
        // System.out.println("Testing function isValidString");
        // System.out.println(isValidString("abb"));
        // System.out.println(isValidString("bab"));
        // System.out.println(isValidString("bba"));
        // System.out.println(isValidString("aabaa"));
        // System.out.println(isValidString("ckg") == false);
        // System.out.println(isValidString("1234") == false);
        // System.out.println(isValidString(""));
        // System.out.println(isValidString("aaab") == false);

        System.out.println("Testing function strWithout3a3b");
        var s = new Solution();
        System.out.println(isValidString(1, 4, s.strWithout3a3b(1, 4)));
        System.out.println(isValidString(3, 1, s.strWithout3a3b(1, 3)));
        System.out.println(isValidString(1, 2, s.strWithout3a3b(1, 2)));
        System.out.println(isValidString(4, 1, s.strWithout3a3b(4, 1)));
    }

    private static boolean isValidString(int a, int b, String s) {
        for (char i : s.toCharArray()) {
            if (i != 'a' && i != 'b') {
                return false;
            }
        }
        for (int i = 2; i < s.length(); i++) {
            if (s.charAt(i) == s.charAt(i - 1) && s.charAt(i - 1) == s.charAt(i - 2)) {
                return false;
            }
        }
        return s.length() == a + b;
    }
}