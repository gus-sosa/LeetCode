using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace BinaryTreeZigzagLevelOrderTraversal {
  class Program {
    static void Main(string[] args) {
      Console.WriteLine("Hello World!");
    }

    /**
 * Definition for a binary tree node. */
    public class TreeNode {
      public int val;
      public TreeNode left;
      public TreeNode right;
      public TreeNode(int x) { val = x; }
    }

    class TreeNodeProcessingInfo {
      public TreeNode Node { get; set; }
      public bool LeftDirection { get; set; }
      public int Level { get; set; }
    }

    class TreeLevelContainer : IEnumerable<int> {
      private int _level;
      private Action<int> _internalAdd;
      private Queue<int> _queue;
      private Stack<int> _stack;

      public TreeLevelContainer(int level) {
        this._level = level;
        if (level % 2 == 0) {
          _internalAdd = addToStack;
          _stack = new Stack<int>();
        } else {
          _internalAdd = addToQueue;
          _queue = new Queue<int>();
        }
      }

      private void addToQueue(int obj) => _queue.Enqueue(obj);

      private void addToStack(int obj) => _stack.Push(obj);

      public int Count => _level % 2 == 0 ? _stack.Count : _queue.Count;

      public bool IsReadOnly => false;

      public void Add(int item) => _internalAdd(item);

      public IEnumerator<int> GetEnumerator() {
        if (_level % 2 == 0) {
          return _stack.GetEnumerator();
        }
        return _queue.GetEnumerator();
      }

      IEnumerator IEnumerable.GetEnumerator() {
        throw new NotImplementedException();
      }
    }

    public IList<IList<int>> ZigzagLevelOrder(TreeNode root) {
      var queue = new Queue<TreeNodeProcessingInfo>();
      if (root != null) {
        queue.Enqueue(new TreeNodeProcessingInfo() {
          LeftDirection = true,
          Level = 1,
          Node = root
        });
      }
      var levels = new List<TreeLevelContainer>();
      while (queue.Count > 0) {
        var current = queue.Dequeue();
        if (current.Node.left != null) {
          queue.Enqueue(new TreeNodeProcessingInfo() {
            LeftDirection = !current.LeftDirection,
            Node = current.Node.left,
            Level = current.Level + 1
          });
        }
        if (current.Node.right != null) {
          queue.Enqueue(new TreeNodeProcessingInfo() {
            LeftDirection = !current.LeftDirection,
            Node = current.Node.right,
            Level = current.Level + 1
          });
        }
        if (current.Level > levels.Count) {
          levels.Add(new TreeLevelContainer(current.Level));
        }
        levels[current.Level - 1].Add(current.Node.val);
      }
      var result = new List<IList<int>>();
      for (int i = 0; i < levels.Count; ++i) {
        result.Add(levels[i].ToList());
      }
      return result;
    }
  }
}
