using System;
using System.Collections.Generic;

namespace LowestCommonAncestor {
  class Program {
    public class TreeNode {
      public int val;
      public TreeNode left;
      public TreeNode right;
      public TreeNode(int x) { val = x; }
      public TreeNode(int x, TreeNode left = null, TreeNode right = null) : this(x) { this.left = left; this.right = right; }
    }

    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q) {
      Stack<TreeNode> pathToP = FindPath(root, p);
      Stack<TreeNode> pathToQ = FindPath(root, q);
      TreeNode lca = null;
      while (pathToP.Count > 0 && pathToQ.Count > 0) {
        if (pathToP.Peek().val == pathToQ.Peek().val) {
          lca = pathToP.Peek();
          pathToP.Pop(); pathToQ.Pop();
        } else {
          break;
        }
      }
      return lca;
    }

    private Stack<TreeNode> FindPath(TreeNode node, TreeNode target) {
      if (node.val == target.val) {
        var path = new Stack<TreeNode>();
        path.Push(target);
        return path;
      }

      Stack<TreeNode> result = null;
      if (node.left != null) {
        result = FindPath(node.left, target);
      }
      if (result == null && node.right != null) {
        result = FindPath(node.right, target);
      }
      if (result != null) {
        result.Push(node);
      }
      return result;
    }

    static void Main(string[] args) {
      var prog = new Program();
      Tuple<TreeNode, TreeNode, TreeNode> data = GiveInput();

      Console.WriteLine(prog.LowestCommonAncestor(data.Item1, data.Item2, data.Item3).val);
      data = GiveInput1();
      Console.WriteLine(prog.LowestCommonAncestor(data.Item1, data.Item2, data.Item3).val);
    }

    private static Tuple<TreeNode, TreeNode, TreeNode> GiveInput() {
      var p = new TreeNode(5, new TreeNode(6), new TreeNode(2, new TreeNode(7), new TreeNode(4)));
      var q = new TreeNode(1, new TreeNode(0), new TreeNode(8));
      var tree = new TreeNode(3, p, q);
      return Tuple.Create(tree, p, q);
    }

    private static Tuple<TreeNode, TreeNode, TreeNode> GiveInput1() {
      var q = new TreeNode(4);
      var p = new TreeNode(5, new TreeNode(6), new TreeNode(2, new TreeNode(7), q));
      var tree = new TreeNode(3, p, new TreeNode(1, new TreeNode(0), new TreeNode(8)));
      return Tuple.Create(tree, p, q);
    }
  }
}
