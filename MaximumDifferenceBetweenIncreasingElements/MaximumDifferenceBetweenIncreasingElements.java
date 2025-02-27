import java.util.Arrays;
import java.util.List;
import java.util.stream.Collectors;

public class MaximumDifferenceBetweenIncreasingElements {
    public static void main(String[] args) {
        var s = new MaximumDifferenceBetweenIncreasingElements();
        runTest(s, List.of(7, 1, 5, 4), 4);
        runTest(s, List.of(9, 4, 3, 2), -1);
        runTest(s, List.of(1, 5, 2, 10), 9);
    }

    private static void runTest(MaximumDifferenceBetweenIncreasingElements s, List<Integer> list, int expectedResult) {
        System.out.println("=====START=====");
        int[] nums = list.stream().mapToInt(Integer::intValue).toArray();
        String listString = Arrays.stream(nums)
                .mapToObj(String::valueOf)
                .collect(Collectors.joining(","));
        System.out.println("--> Running test for: " + listString);
        System.out.println("--> Expected result: " + expectedResult);
        try {
            int result = s.maximumDifference(nums);
            if (result == expectedResult) {
                System.out.println("PASSED");
            } else {
                System.out.println(String.format("FAILED: result=[%d]", result));
            }
        } catch (Exception e) {
            System.out.println("Exception: " + e.getMessage());
        }
        System.out.println("=====END=====");
    }

    public int maximumDifference(int[] nums) {
        int maxDiffSoFar = -1;
        for (int i = 0; i < nums.length; i++) {
            for (int j = i + 1; j < nums.length; j++) {
                if (nums[i] >= nums[j]) {
                    continue;
                }
                maxDiffSoFar = Math.max(maxDiffSoFar, nums[j] - nums[i]);
            }
        }
        return maxDiffSoFar;
    }
}
