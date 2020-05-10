using System;

namespace BinaryTreeMaximumPathSum {
  class Program {
    static void Main(string[] args) {
      var s = new Solution();
      TreeNode t;

      t = new TreeNode(-3);
      Console.WriteLine(s.MaxPathSum(t));

      t = new TreeNode(-2, new TreeNode(-1));
      Console.WriteLine(s.MaxPathSum(t));

      t = new TreeNode(1, new TreeNode(-2, new TreeNode(1, new TreeNode(-1)), new TreeNode(3)), new TreeNode(-3, new TreeNode(-2)));
      Console.WriteLine(s.MaxPathSum(t));
    }
  }

  /**
* Definition for a binary tree node.*/
  public class TreeNode {
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null) {
      this.val = val;
      this.left = left;
      this.right = right;
    }
  }


  #region MyRegion

  public class Solution {
    public int MaxPathSum(TreeNode root) {
      var r = new AugmentedTree(root);
      return (int)r.MaxSumSoFar;
    }

    public class AugmentedTree {
      public TreeNode Tree { get; set; }

      public AugmentedTree Left { get; set; }
      public AugmentedTree Right { get; set; }

      public long MaxSumSoFar { get; set; }
      public long MaxSumFromRoot { get; set; }

      public AugmentedTree(TreeNode tree) {
        if (tree == null) {
          MaxSumFromRoot = MaxSumSoFar = int.MinValue;
          return;
        }
        this.Tree = tree;
        this.Left = new AugmentedTree(tree.left);
        this.Right = new AugmentedTree(tree.right);
        if (tree.left == null && tree.right == null) {
          MaxSumFromRoot = MaxSumSoFar = tree.val;
        } else {
          MaxSumFromRoot = Math.Max(Tree.val, Tree.val + Math.Max(Left.MaxSumFromRoot, Right.MaxSumFromRoot));
          MaxSumSoFar = Math.Max(Tree.val, Math.Max(Left.MaxSumSoFar, Math.Max(Right.MaxSumSoFar, Math.Max(MaxSumFromRoot, Tree.val + Left.MaxSumFromRoot + Right.MaxSumFromRoot))));
        }
      }
    }
  }

  #endregion
}
