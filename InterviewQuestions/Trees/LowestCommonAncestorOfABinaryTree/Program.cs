using System;
using System.Collections;
using System.Collections.Generic;

namespace LowestCommonAncestorOfABinaryTree {
  class Program {
    static void Main(string[] args) {
      var s = new Solution();
      var left = new TreeNode(5) {
        left = new TreeNode(6),
        right = new TreeNode(2) {
          left = new TreeNode(7),
          right = new TreeNode(4)
        }
      };
      var right = new TreeNode(1) {
        left = new TreeNode(0),
        right = new TreeNode(8)
      };
      var root = new TreeNode(3) {
        left = left,
        right = right
      };
      var r = s.LowestCommonAncestor(root, left, right);
      Console.WriteLine(r.val);
    }

    public class TreeNode {
      public int val;
      public TreeNode left;
      public TreeNode right;
      public TreeNode(int x) { val = x; }
    }


    #region MyRegion


    public class Solution {
      public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q) {
        Stack<TreeNode> parentsP = getParents(root, p);
        Stack<TreeNode> parentsQ = getParents(root, q);
        TreeNode lca = null;
        while (parentsP.Count > 0 && parentsQ.Count > 0 && parentsP.Peek().val == parentsQ.Peek().val) {
          lca = parentsP.Pop();
          parentsQ.Pop();
        }
        return lca;
      }

      private Stack<TreeNode> getParents(TreeNode root, TreeNode node) {
        if (root == null) {
          return null;
        }
        if (root.val == node.val) {
          var retval = new Stack<TreeNode>();
          retval.Push(node);
          return retval;
        }
        var result = getParents(root.left, node);
        if (result == null) {
          result = getParents(root.right, node);
        }
        if (result != null) {
          result.Push(root);
        }
        return result;
      }
    }

    #endregion
  }
}
