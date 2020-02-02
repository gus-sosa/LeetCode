using System;
using System.Collections.Generic;

namespace BinaryTreeInorderTraversal {
  class Program {
    /**
 * Definition for a binary tree node.*/
    public class TreeNode {
      public int val;
      public TreeNode left;
      public TreeNode right;
      public TreeNode(int x) { val = x; }
    }


    static void Main(string[] args) {
      Console.WriteLine("Hello World!");
    }

    public IList<int> InorderTraversal(TreeNode root) {
      var stack = new Stack<TreeNode>();
      if (root != null) {
        stack.Push(root);
      }
      var result = new List<int>();
      TreeNode current;
      while (stack.Count > 0) {
        current = stack.Pop();
        if (current.left != null) {
          var left = current.left;
          current.left = null;
          stack.Push(current);
          stack.Push(left);
        } else {
          result.Add(current.val);
          if (current.right != null) {
            stack.Push(current.right);
          }
        }
      }
      return result;
    }
  }
}
