using System;
using System.Collections.Generic;

namespace BinaryTreeLevelOrderTraversal {
  public class TreeNode {
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int x) { val = x; }
  }


  class Program {
    public IList<IList<int>> LevelOrder(TreeNode root) {
      var map = new SortedList<int, IList<int>>();
      LevelOrder(root, 0, map);
      return map.Values;
    }

    private void LevelOrder(TreeNode root, int level, SortedList<int, IList<int>> map) {
      if (root == null) {
        return;
      }
      if (!map.ContainsKey(level)) {
        map.Add(level, new List<int>());
      }
      map[level].Add(root.val);
      LevelOrder(root.left, level + 1, map);
      LevelOrder(root.right, level + 1, map);
    }

    static void Main(string[] args) {
      Console.WriteLine("Hello World!");
    }
  }
}
