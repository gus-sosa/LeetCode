import java.util.Collections;
import java.util.Arrays;
import java.util.HashSet;
import java.util.List;

public class TreeNode {
    int val;
    TreeNode left;
    TreeNode right;

    TreeNode() {
    }

    TreeNode(int val) {
        this.val = val;
    }

    TreeNode(int val, TreeNode left, TreeNode right) {
        this.val = val;
        this.left = left;
        this.right = right;
    }
}

class TreeResult {
    public int count;
    public HashSet<Integer> bestNumbers;

    public TreeResult() {
        this.count = 0;
        this.bestNumbers = new HashSet<>();
    }

    public TreeResult(int count, HashSet<Integer> bestNumbers) {
        this.count = count;
        this.bestNumbers = bestNumbers;
    }
}

class Solution {
    public int[] findMode(TreeNode root) {
        TreeResult result = findModeRecur(root);
        if (result == null) {
            return new int[0];
        } else {
            return result.bestNumbers.stream().mapToInt(i -> i).toArray();
        }
    }

    private TreeResult findModeRecur(TreeNode root) {
        if (root == null) {
            return null;
        }

        int currentCount = 1 + countNumberInTree(root.left, root.val) + countNumberInTree(root.right, root.val);

        TreeResult left = findModeRecur(root.left);
        TreeResult right = findModeRecur(root.right);

        return mergeResults(new TreeResult(currentCount, new HashSet<>(List.of(Integer.valueOf(root.val)))),
                mergeResults(left, right));
    }

    private TreeResult mergeResults(TreeResult a, TreeResult b) {
        if (a == null) {
            return b;
        }
        if (b == null) {
            return a;
        }
        if (a.count == b.count) {
            var bestNumbers = new HashSet<Integer>();
            bestNumbers.addAll(a.bestNumbers);
            bestNumbers.addAll(b.bestNumbers);
            return new TreeResult(a.count, bestNumbers);
        }
        return a.count > b.count ? a : b;
    }

    private int countNumberInTree(TreeNode root, int val) {
        if (root == null) {
            return 0;
        }
        return countNumberInTree(root.left, val) + countNumberInTree(root.right, val) + (root.val == val ? 1 : 0);
    }
}