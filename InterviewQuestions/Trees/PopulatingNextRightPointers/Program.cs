using System;
using System.Collections;
using System.Collections.Generic;

namespace PopulatingNextRightPointers {
  class Program {
    /*
// Definition for a Node.*/
    public class Node {
      public int val;
      public Node left;
      public Node right;
      public Node next;

      public Node() { }

      public Node(int _val) {
        val = _val;
      }

      public Node(int _val, Node _left, Node _right, Node _next) {
        val = _val;
        left = _left;
        right = _right;
        next = _next;
      }
    }


    static void Main(string[] args) {
      Console.WriteLine("Hello World!");
    }

    public Node Connect(Node root) {
      if (root == null) {
        return null;
      }
      var queue = new Queue<Node>();
      queue.Enqueue(root);
      int currentLevel = 0;
      int numNodesInCurrentLevel = 1;
      while (queue.Count > 0) {
        var currentNode = queue.Dequeue();
        if (--numNodesInCurrentLevel == 0) {
          ++currentLevel;
          numNodesInCurrentLevel = 1 << currentLevel;
        } else {
          currentNode.next = queue.Peek();
        }
        if (currentNode.left != null) {
          queue.Enqueue(currentNode.left);
          queue.Enqueue(currentNode.right);
        }
      }
      return root;
    }
  }
}
