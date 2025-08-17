package MinimumAddToMakeParenthesesValid;

public class MinimumAddToMakeParenthesesValid {
    public static void main(String[] args) {
        var s = new Solution();
        test(s, "())", 1);
        test(s, "(((", 3);
        test(s, "((()", 2);
        test(s, "((()))", 0);
        test(s, "((()))))", 2);
        test(s, "())(()))", 2);
        test(s, "()))(())", 2);
    }

    private static void test(Solution s, String input, int expectedResult) {
        try {
            int result = s.minAddToMakeValid(input);
            if (result == expectedResult) {
                System.out.println("PASSED");
            } else {
                System.out.println(String.format("FAILED: (expected,result)=(%s,%s)", Integer.toString(expectedResult),
                        Integer.toString(result)));
            }
        } catch (Exception e) {
            System.out.println(String.format("ERROR: %s", e.getMessage()));
        }
    }
}
