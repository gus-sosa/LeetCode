using System;

namespace KthSmallestElementInBST {
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
      var p = new Program();
      var tree1 = new TreeNode(3) {
        left = new TreeNode(1) { right = new TreeNode(2) },
        right = new TreeNode(4)
      };
      var tree2 = new TreeNode(5) {
        left = new TreeNode(3) {
          left = new TreeNode(2) {
            left = new TreeNode(1)
          },
          right = new TreeNode(4)
        },
        right = new TreeNode(6)
      };
      Console.WriteLine(p.KthSmallest(tree1, 1) == 1);
      Console.WriteLine(p.KthSmallest(tree1, 2) == 2);
      Console.WriteLine(p.KthSmallest(tree1, 3) == 3);
      Console.WriteLine(p.KthSmallest(tree1, 4) == 4);
      Console.WriteLine(p.KthSmallest(tree2, 3) == 3);
    }

    class AumentedTree {

      public AumentedTree(TreeNode node) {
        if (node != null) {
          this.Node = node;
          Left = new AumentedTree(node.left);
          Right = new AumentedTree(node.right);
          Count = 1 + Left.Count + Right.Count;
        }
      }

      public TreeNode Node { get; set; }

      public AumentedTree Left { get; set; }
      public AumentedTree Right { get; set; }

      public int Count { get; set; }
    }

    private int k;
    public int KthSmallest(TreeNode root, int k) {
      this.k = k;
      return KthSmallest(new AumentedTree(root), 0);
    }

    private int KthSmallest(AumentedTree aumentedTree, int countPreviousSmaller) {
      if (aumentedTree == null) {
        return 0;
      }
      if (aumentedTree.Left.Count + countPreviousSmaller + 1 == k) {
        return aumentedTree.Node.val;
      }
      if (aumentedTree.Left.Count + countPreviousSmaller >= k) {
        return KthSmallest(aumentedTree.Left, countPreviousSmaller);
      } else {
        return KthSmallest(aumentedTree.Right, countPreviousSmaller + aumentedTree.Left.Count + 1);
      }
    }
  }
}
