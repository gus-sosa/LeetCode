using System;
using System.Collections.Generic;

namespace BinaryTreeFromPreorderAndInorderTraversal {
  class Program {
    /**
 * Definition for a binary tree node.*/
    public class TreeNode {
      public int val;
      public TreeNode left;
      public TreeNode right;
      public TreeNode(int x) { val = x; }
    }

    private static void PrintTree(TreeNode treeNode) {
      var queue = new Queue<TreeNode>();
      queue.Enqueue(treeNode);
      while (queue.Count > 0) {
        var current = queue.Dequeue();
        Console.Write($"{current.val}   ");
        if (current.left != null) {
          queue.Enqueue(current.left);
        }
        if (current.right != null) {
          queue.Enqueue(current.right);
        }
      }
      Console.WriteLine();
    }

    static void Main(string[] args) {
      var p = new Program();
      PrintTree(p.BuildTree(new int[] { 5, 4, 2, 1, 6, 3, 7, 8, 0 }, new int[] { 2, 4, 1, 6, 5, 3, 7, 0, 8 }));
    }

    public TreeNode BuildTree(int[] preorder, int[] inorder) {
      var dict = new Dictionary<int, int>();
      for (int i = 0; i < inorder.Length; ++i) {
        dict[inorder[i]] = i;
      }
      int currentPreorderPos = 0;
      return BuildTree(preorder, inorder, ref currentPreorderPos, 0, preorder.Length - 1, dict);
    }

    private TreeNode BuildTree(int[] preorder, int[] inorder, ref int currentPreorderPos, int startPosInorder, int endPosInOrder, Dictionary<int, int> map) {
      if (currentPreorderPos > preorder.Length) {
        return null;
      }
      if (startPosInorder > endPosInOrder) {
        --currentPreorderPos;
        return null;
      }

      TreeNode current = new TreeNode(preorder[currentPreorderPos]);
      int inOrderPos = map[preorder[currentPreorderPos]];
      if (inOrderPos < startPosInorder || inOrderPos > endPosInOrder) {
        --currentPreorderPos;
        return null;
      }
      ++currentPreorderPos;
      current.left = BuildTree(preorder, inorder, ref currentPreorderPos, startPosInorder, inOrderPos - 1, map);
      ++currentPreorderPos;
      current.right = BuildTree(preorder, inorder, ref currentPreorderPos, inOrderPos + 1, endPosInOrder, map);
      return current;
    }
  }
}
