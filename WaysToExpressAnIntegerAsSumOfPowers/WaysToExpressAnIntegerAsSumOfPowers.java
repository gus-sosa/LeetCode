package WaysToExpressAnIntegerAsSumOfPowers;

public class WaysToExpressAnIntegerAsSumOfPowers {
    public static void main(String[] args) {
        var s = new Solution();
        test(s, 10, 2, 1);
        test(s, 4, 1, 2);
    }

    private static void test(Solution s, int n, int x, int expectedResult) {
        try {
            int result = s.numberOfWays(n, x);
            if (result == expectedResult) {
                System.out.println("PASS");
            } else {
                System.out.println(String.format("FAILED: (expected,result)=(%d,%d)", expectedResult, result));
            }
        } catch (Exception e) {
            System.out.println(String.format("ERROR: ", e.getMessage()));
        }
    }
}
