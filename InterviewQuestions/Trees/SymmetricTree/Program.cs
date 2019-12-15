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
      var left = new Queue<TreeNode>();
      var right = new Queue<TreeNode>();
      left.Enqueue(root.left);
      right.Enqueue(root.right);
      while (left.Count > 0 && right.Count > 0) {
        var currentLeft = left.Dequeue();
        var currentRight = right.Dequeue();
        if (currentLeft?.val != currentRight?.val) {
          return false;
        }
        if (currentLeft != null && currentRight != null) {
          left.Enqueue(currentLeft.left);
          right.Enqueue(currentRight.right);
          left.Enqueue(currentLeft.right);
          right.Enqueue(currentRight.left);
        }
      }
      return left.Count == 0 && right.Count == 0;
    }

    static void Main(string[] args) {
      Console.WriteLine("Hello World!");
    }
  }
}
