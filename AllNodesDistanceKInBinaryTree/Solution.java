package AllNodesDistanceKInBinaryTree;

import java.util.ArrayDeque;
import java.util.ArrayList;
import java.util.List;

class Solution {
    private List<Integer> retVal;
    private TreeNode target;
    private Integer k;

    public List<Integer> distanceK(TreeNode root, TreeNode target, int k) {
        retVal = new ArrayList<Integer>();
        this.target = target;
        this.k = k;
        dfs(root);
        return retVal;
    }

    private int dfs(TreeNode node) {
        if (node == null) {
            return -1;
        }
        if (node.val == target.val) {
            retVal.addAll(bfs(node, k));
            return 1;
        }

        int d = dfs(node.left);
        if (d >= 0) {
            if (d > k) {
                return d;
            }
            if (d == k) {
                retVal.add(node.val);
            } else {
                retVal.addAll(bfs(node.right, k - (d + 1)));
            }
            return d + 1;
        }
        d = dfs(node.right);
        if (d >= 0) {
            if (d > k) {
                return d;
            }
            if (d == k) {
                retVal.add(node.val);
            } else {
                retVal.addAll(bfs(node.left, k - (d + 1)));
            }
            return d + 1;
        }

        return -1;
    }

    private List<Integer> bfs(TreeNode node, int level) {
        var retVal = new ArrayList<Integer>();
        var queue = new ArrayDeque<Object[]>();
        queue.push(new Object[] { node, 0 });
        while (!queue.isEmpty()) {
            var current = queue.pop();
            TreeNode currentNode = (TreeNode) current[0];
            Integer currentLevel = (Integer) current[1];
            if (currentLevel > k || currentNode == null) {
                continue;
            }
            queue.push(new Object[] { currentNode.left, currentLevel + 1 });
            queue.push(new Object[] { currentNode.right, currentLevel + 1 });
            if (currentLevel == level) {
                retVal.add(currentNode.val);
            }
        }
        return retVal;
    }
}