using System;

namespace LinkedListCycle {

  public class ListNode {
    public int val;
    public ListNode next;
    public ListNode(int x) {
      val = x;
      next = null;
    }
  }


  class Program {
    public bool HasCycle(ListNode head) {
      if (head == null) {
        return false;
      }
      ListNode tmp, current = head, visitedMakerNode = new ListNode(0);
      while (current.next != null) {
        if (current.next == visitedMakerNode) {
          return true;
        }
        tmp = current.next;
        current.next = visitedMakerNode;
        current = tmp;
      }
      return false;
    }

    static void Main(string[] args) {
      Console.WriteLine("Hello World!");
    }
  }
}
