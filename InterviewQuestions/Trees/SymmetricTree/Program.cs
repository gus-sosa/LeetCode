using System;
using System.Collections;
using System.Collections.Generic;

namespace SymmetricTree {
  public class TreeNode {
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int x) { val = x; }
  }


  class Program {
    public bool IsSymmetric(TreeNode root) {
      if (root == null) {
        return true;
      }
      return IsSymmetric(root.left, root.right);
    }

    private bool IsSymmetric(TreeNode left, TreeNode right) {
      if (left?.val != right?.val) {
        return false;
      }
      return (left == null && right == null) || (IsSymmetric(left.left, right.right) && IsSymmetric(left.right, right.left));
    }

    static void Main(string[] args) {
      Console.WriteLine("Hello World!");
    }
  }
}
