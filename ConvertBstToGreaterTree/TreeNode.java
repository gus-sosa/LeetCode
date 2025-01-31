import java.util.ArrayList;
import java.util.Collections;
import java.util.Comparator;
import java.util.HashMap;
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

class Solution {
    List<Integer> list;
    List<Integer> suffixSums;
    HashMap<Integer, Integer> map;

    public TreeNode convertBST(TreeNode root) {
        preComputation(root);
        convert(root);
        return root;
    }

    private void preComputation(TreeNode root) {
        list = new ArrayList<>();
        map = new HashMap<>();
        suffixSums = new ArrayList<>();
        preComputationRecur(root);
        list.sort(Comparator.naturalOrder());
        computeSuffixSums();
    }

    private void computeSuffixSums() {
        suffixSums.add(0);
        for (int i = list.size() - 1; i >= 0; i--) {
            suffixSums.add(suffixSums.get(suffixSums.size() - 1) + map.get(list.get(i)) * list.get(i));
        }
        Collections.reverse(suffixSums);
        suffixSums.remove(suffixSums.size() - 1); // Remove the last element which is 0.
    }

    private void preComputationRecur(TreeNode root) {
        if (root == null) {
            return;
        }
        list.add(root.val);
        map.put(root.val, map.containsKey(root.val) ? map.get(root.val) + 1 : 1);
        preComputationRecur(root.left);
        preComputationRecur(root.right);
    }

    private void convert(TreeNode root) {
        if (root == null) {
            return;
        }
        root.val = root.val + getSumGreaterThan(root.val);
        convert(root.left);
        convert(root.right);
    }

    private int getSumGreaterThan(int val) {
        int index = Collections.binarySearch(list, val);
        if (index < 0) {
            throw new RuntimeException("Value not found in list. Something wrong because this shouldn't happen.");
        }
        if (index >= list.size() - 1) {
            return 0;
        }
        return suffixSums.get(index + 1);
    }
}