using System;

namespace ValidateBinarySearchTree {
  public class TreeNode {
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int x) { val = x; }
  }


  class Program {
    public bool IsValidBST(TreeNode root) {
      if (root == null) {
        return true;
      }
      if ((root.left != null && root.left.val >= root.val) || (root.right != null && root.right.val <= root.val)) {
        return false;
      }
      return IsValidBST(root.left) && IsValidBST(root.right) && ValidLeftSubTree(root.left, root.val) && ValidRigthSubTree(root.right, root.val);
    }

    private bool ValidRigthSubTree(TreeNode right, int val) {
      if (right == null) {
        return true;
      }
      while (right.left != null) {
        right = right.left;
      }
      return right.val > val;
    }

    private bool ValidLeftSubTree(TreeNode left, int val) {
      if (left == null) {
        return true;
      }
      while (left.right != null) {
        left = left.right;
      }
      return left.val < val;
    }

    static void Main(string[] args) {
      var p = new Program();
      var tree = new TreeNode(2);
      tree.left = new TreeNode(1);
      tree.right = new TreeNode(3);
      Console.WriteLine(p.IsValidBST(tree));
    }
  }
}
