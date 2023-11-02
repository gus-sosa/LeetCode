package UniqueBinarySearchTreeII;

import java.util.ArrayList;
import java.util.List;

class Solution {
    public List<TreeNode> generateTrees(int n) {
        return buildTree(1, n);
    }

    private List<TreeNode> buildTree(int left, int right) {
        if (left == right) {
            return List.of(new TreeNode(left));
        }
        if (left > right) {
            var retVal = new ArrayList<TreeNode>();
            retVal.add(null);
            return retVal;
        }

        var retVal = new ArrayList<TreeNode>();
        for (int i = left; i <= right; i++) {
            List<TreeNode> leftTrees = buildTree(left, i - 1);
            List<TreeNode> rightTrees = buildTree(i + 1, right);
            for (TreeNode leftTree : leftTrees) {
                for (TreeNode rightTree : rightTrees) {
                    retVal.add(new TreeNode(i, leftTree, rightTree));
                }
            }
        }

        return retVal;
    }
}