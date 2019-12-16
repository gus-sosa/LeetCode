using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ConvertSortedArrayBinarySearchTree {
  public class TreeNode {
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int x) { val = x; }
  }

  class Program {
    public TreeNode SortedArrayToBST(int[] nums) {
      return SortedArrayToBST(nums, 0, nums.Length);
    }

    private TreeNode SortedArrayToBST(int[] nums, int index, int length) {
      if (length <= 0 || index < 0 || index >= nums.Length) {
        return null;
      }
      if (length == 1) {
        return new TreeNode(nums[index]);
      }

      int middle = index + length / 2;
      var result = new TreeNode(nums[middle]);
      result.left = SortedArrayToBST(nums, index, middle - index);
      result.right = SortedArrayToBST(nums, middle + 1, length - (middle - index) - 1);
      return result;
    }

    static void PrintTree(TreeNode tree) {
      var q = new Queue<TreeNode>();
      q.Enqueue(tree);
      var s = new StringBuilder();
      while (q.Count > 0) {
        var current = q.Dequeue();
        if (current == null) {
          Console.WriteLine("N");
          continue;
        }
        Console.WriteLine(current.val);
        q.Enqueue(current.left);
        q.Enqueue(current.right);
      }
    }

    static void Main(string[] args) {
      var p = new Program();
      PrintTree(p.SortedArrayToBST(new[] { -10, -3, 0, 5, 9 }));
      PrintTree(p.SortedArrayToBST(new[] { 0, 1, 2, 3, 4, 5, 6 }));
      PrintTree(p.SortedArrayToBST(new[] { 0, 1, 2, 3, 4, 5, 6, 7 }));
    }
  }
}
