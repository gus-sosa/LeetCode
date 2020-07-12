using System;
using System.Collections.Generic;

namespace CountOfSmallerNumbersAfterSelf
{
  class Program
  {
    static void Main(string[] args) {
      var s = new Solution();
      Print(s.CountSmaller(new int[] { 5, 2, 6, 1 }));
      Print(s.CountSmaller(new int[] { 2, 1, 1, 0 }));
    }

    private static void Print(IList<int> list) {
      Console.WriteLine("=========");
      foreach (var item in list) {
        Console.WriteLine(item);
      }
    }
  }

  #region MyRegion


  public class Solution
  {
    public IList<int> CountSmaller(int[] nums) {
      var bst = new BST();
      int[] retval = new int[nums.Length];
      for (int i = nums.Length - 1; i >= 0; --i) {
        retval[i] = bst.CountSmaller(nums[i]);
        bst.Insert(nums[i]);
      }
      return retval;
    }

    class BST
    {
      private Node root { get; set; }

      internal int CountSmaller(int v) {
        if (root == null) {
          return 0;
        }
        var current = root;
        return countSmaller(current, v);
      }

      private int countSmaller(Node current, int v) {
        if (current == null) {
          return 0;
        }
        if (current.Value >= v) {
          return countSmaller(current.Left, v);
        }
        int r = current.NumNodesSubtree;
        if (current.Right != null) {
          r -= current.Right.NumNodesSubtree;
        }
        r += countSmaller(current.Right, v);
        return r;
      }

      internal void Insert(int v) {
        if (root == null) {
          root = new Node() { Value = v };
          return;
        }

        var current = root;
        bool flag = false;
        while (!flag) {
          if (v == current.Value) {
            flag = true;
          } else {
            ++current.NumNodesSubtree;
            if (v < current.Value) {
              flag = current.Left == null;
              if (!flag) {
                current = current.Left;
              }
            } else {
              flag = current.Right == null;
              if (!flag) {
                current = current.Right;
              }
            }
          }
        }

        if (v == current.Value) {
          ++current.NumNodesSubtree;
        } else if (v < current.Value) {
          current.Left = new Node() { Value = v };
        } else {
          current.Right = new Node() { Value = v };
        }
      }

      class Node
      {
        public Node() {
          NumNodesSubtree = 1;
        }

        public int Value { get; set; }
        public int NumNodesSubtree { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }
      }
    }
  }


  #endregion
}
