public class BrokenCalculator {
    public static void main(String[] args) {
        System.out.println(brokenCalc(2, 3) == 2);
        System.out.println(brokenCalc(5, 8) == 2);
        System.out.println(brokenCalc(3, 10) == 3);
    }

    public static int brokenCalc(int startValue, int target) {
        if (target <= startValue) {
            return startValue - target;
        }
        if (target % 2 == 0) {
            return 1 + brokenCalc(startValue, target / 2);
        }
        return 1 + brokenCalc(startValue, target + 1);
    }
}
