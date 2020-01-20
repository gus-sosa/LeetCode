using System;

namespace MinStack {
  class Program {
    static void Main(string[] args) {
      Console.WriteLine("Hello World!");
    }
  }

  public class MinStack {

    class Node {
      public int value { get; set; }
      public Node previous { get; set; }
      public int minSoFar { get; set; }
    }

    private Node head;

    /** initialize your data structure here. */
    public MinStack() {

    }

    public void Push(int x) {
      var node = new Node() { value = x };
      if (head == null) {
        node.minSoFar = x;
        head = node;
      } else {
        node.previous = head;
        node.minSoFar = Math.Min(x, head.minSoFar);
        head = node;
      }
    }

    public void Pop() {
      if (head != null) {
        head = head.previous;
      }
    }

    public int Top() {
      return head.value;
    }

    public int GetMin() {
      return head.minSoFar;
    }
  }
}
