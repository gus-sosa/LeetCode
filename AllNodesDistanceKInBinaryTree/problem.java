package AllNodesDistanceKInBinaryTree;

import java.util.Arrays;
import java.util.List;

/**
 * solution
 */
public class problem {
    public static void main(String[] args) {
        test1();
        test2();
    }

    private static void test2() {
        System.out.println("Test 2");
        var root1 = new TreeNode(0,
                new TreeNode(1,
                        new TreeNode(3),
                        new TreeNode(2)),
                null);
        var target = new TreeNode(2);
        var k = 1;
        var solution = new Solution();
        var retVal = solution.distanceK(root1, target, k);
        var expectedResult = List.of(1);
        validate(expectedResult, retVal);
    }

    private static void test1() {
        System.out.println("Test 1");
        var root1 = new TreeNode(3,
                new TreeNode(5,
                        new TreeNode(6),
                        new TreeNode(2, new TreeNode(7), new TreeNode(4))),
                new TreeNode(1, new TreeNode(0), new TreeNode(8)));
        var target = new TreeNode(5);
        var k = 2;
        var solution = new Solution();
        var retVal = solution.distanceK(root1, target, k);
        var expectedResult = List.of(1, 4, 7);
        validate(expectedResult, retVal);
    }

    private static void validate(List<Integer> expected, List<Integer> result) {
        if (result.size() == expected.size() && result.stream().allMatch(i -> expected.contains(i))) {
            System.out.println("ok");
        } else {
            System.out.println("fail");
        }
    }
}