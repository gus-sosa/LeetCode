package BinaryTreePaths;

import java.util.ArrayList;
import java.util.Collections;
import java.util.List;
import java.util.Queue;

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

class Solution {

    private boolean isLeaf(TreeNode root) {
        return root != null && root.left == null && root.right == null;
    }

    private List<String> buildPrefix(List<String> list, TreeNode root) {
        return list.stream().map(i -> String.format("%s->%s", root.val, i)).toList();
    }

    public List<String> binaryTreePaths(TreeNode root) {
        if (root == null) {
            return List.of();
        }
        if (isLeaf(root)) {
            return List.of(Integer.toString(root.val));
        }

        List<String> leftList = buildPrefix(binaryTreePaths(root.left), root);
        List<String> rightList = buildPrefix(binaryTreePaths(root.right), root);
        List<String> result = new ArrayList<>();
        result.addAll(leftList);
        result.addAll(rightList);
        return result;
    }
}