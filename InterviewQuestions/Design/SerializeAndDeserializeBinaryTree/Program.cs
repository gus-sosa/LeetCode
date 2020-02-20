using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace SerializeAndDeserializeBinaryTree {
  class Program {
    static void Main(string[] args) {
      var s = new Codec();
      var tree = new TreeNode(1) {
        left = new TreeNode(2),
        right = new TreeNode(3) {
          left = new TreeNode(4),
          right = new TreeNode(5)
        }
      };
      Console.WriteLine(s.serialize(tree));
      var result = s.deserialize(s.serialize(tree));
    }

    /**
* Definition for a binary tree node.*/
    public class TreeNode {
      public int val;
      public TreeNode left;
      public TreeNode right;
      public TreeNode(int x) { val = x; }
    }


    #region MyRegion


    public class Codec {

      const char LEVEL_SEPARATOR = '|';
      const char NULL_ELEMENT = '_';
      const char ELEMENT_SEPARATOR = ',';
      const char ZERO = '0';
      const char MINUS = '-';

      class AugmentedTree {
        public TreeNode Tree { get; set; }
        public int Level { get; set; }
      }

      // Encodes a tree to a single string.
      public string serialize(TreeNode root) {
        var sb = new StringBuilder();
        var queue = new Queue<AugmentedTree>();
        queue.Enqueue(new AugmentedTree() { Tree = root, Level = 0 });
        int lastLevel = 0;
        while (queue.Count > 0) {
          var current = queue.Dequeue();
          if (current.Level != lastLevel) {
            lastLevel = current.Level;
            sb.Append(LEVEL_SEPARATOR);
          }
          if (sb.Length > 0 && (char.IsDigit(sb[sb.Length - 1]) || sb[sb.Length - 1] == NULL_ELEMENT)) {
            sb.Append(ELEMENT_SEPARATOR);
          }
          if (current.Tree == null) {
            sb.Append(NULL_ELEMENT);
          } else {
            sb.Append(current.Tree.val);
            EnqueueElement(current.Tree.left, queue, current.Level + 1);
            EnqueueElement(current.Tree.right, queue, current.Level + 1);
          }
        }
        return sb.ToString();
      }

      private void EnqueueElement(TreeNode tree, Queue<AugmentedTree> queue, int level) {
        var node = new AugmentedTree() { Level = level };
        queue.Enqueue(node);
        if (tree != null) {
          node.Tree = tree;
        }
      }

      // Decodes your encoded data to tree.
      public TreeNode deserialize(string data) {
        var current = new Queue<TreeNode>();
        var previousLevel = new Queue<TreeNode>();
        for (int i = data.Length - 1, val = 0, j = 0; i >= 0; --i) {
          if (data[i] == LEVEL_SEPARATOR) {
            var tmp = current;
            current = previousLevel;
            previousLevel = tmp;
          } else if (data[i] == NULL_ELEMENT) {
            current.Enqueue(null);
          } else if (data[i] != ELEMENT_SEPARATOR) {
            for (j = 0, val = 0; i - j >= 0 && data[i - j] != ELEMENT_SEPARATOR && data[i - j] != LEVEL_SEPARATOR; ++j) {
              if (data[i - j] == MINUS) {
                val *= -1;
              } else {
                val = val + (data[i - j] - ZERO) * Convert.ToInt32(Math.Pow(10, j));
              }
            }
            i = i - j;
            var node = new TreeNode(val);
            node.right = previousLevel.Dequeue();
            node.left = previousLevel.Dequeue();
            current.Enqueue(node);
            if (i >= 0 && data[i] == LEVEL_SEPARATOR) {
              ++i;
            }
          }
        }
        return current.Dequeue();
      }
    }

    // Your Codec object will be instantiated and called as such:
    // Codec codec = new Codec();
    // codec.deserialize(codec.serialize(root));

    #endregion


  }
}
