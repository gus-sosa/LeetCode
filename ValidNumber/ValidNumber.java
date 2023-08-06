package ValidNumber;

public class ValidNumber {
    public static void main(String[] args) {
        var s = new Solution();
        passedTests(s);
        failedTests(s);
    }

    private static void passedTests(Solution s) {
        var cases = new String[] { "2e10", "2", "0089", "-0.1", "+3.14", "4.", "-.9", "-90E3", "3e+7", "+6e-1",
                "53.5e93", "-123.456e789" };
        System.out.println("Executing test cases that should pass");
        for (int index = 0; index < cases.length; index++) {
            var result = s.isNumber(cases[index]);
            passed(result, index + 1);
        }
    }

    private static void failedTests(Solution s) {
        var cases = new String[] { "abc", "1a", "1e", "e3", "99e2.5", "--6", "-+3", "95a54e53" };
        System.out.println("Executing test cases that should fail");
        for (int index = 0; index < cases.length; index++) {
            var result = s.isNumber(cases[index]);
            failed(result, index + 1);
        }
    }

    private static void failed(boolean result, int numTest) {
        passed(!result, numTest);
    }

    private static void passed(boolean result, int numTest) {
        if (result) {
            System.out.println("test" + numTest + " passed");
        } else {
            System.out.println("test" + numTest + " failed");
        }
    }
}
