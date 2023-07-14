package MaximumNumberOfJumpsToReachTheLastIndex;

public class problem {
    public static void main(String[] args) {
        test1();
    }

    private static void test1() {
        System.out.println("Test 1");
        var nums = new int[] { 1, 3, 6, 4, 1, 2 };
        var target = 0;
        var solution = new Solution();
        var output = solution.maximumJumps(nums, target);
        System.out.println(output);
        System.out.println(output == -1);
    }
}
