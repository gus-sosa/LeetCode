package SumRootToLeafNumbers;

public class Solution {
    private int _sumTotal;

    public int sumNumbers(TreeNode root) {
        this._sumTotal = 0;
        sumNumbersRecur(root, 0);
        return this._sumTotal;
    }

    private void sumNumbersRecur(TreeNode root, int currentNum) {
        if (root == null) {
            return;
        }
        if (isLeaf(root)) {
            this._sumTotal += currentNum * 10 + root.val;
            return;
        }
        sumNumbersRecur(root.left, currentNum * 10 + root.val);
        sumNumbersRecur(root.right, currentNum * 10 + root.val);
    }

    private boolean isLeaf(TreeNode node) {
        return node.left == null && node.right == null;
    }
}
