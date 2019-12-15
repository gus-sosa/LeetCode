using System;

namespace MaximumDepthOfBinaryTree {
  public class TreeNode {
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int x) { val = x; }
  }


  class Program {
    public int MaxDepth(TreeNode root) {
      if (root == null) {
        return 0;
      }
      return Math.Max(MaxDepth(root.left), MaxDepth(root.right)) + 1;
    }

    static void Main(string[] args) {
      Console.WriteLine("Hello World!");
    }
  }
}
