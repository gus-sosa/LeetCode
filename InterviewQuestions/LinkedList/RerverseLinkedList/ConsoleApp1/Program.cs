using System;

namespace ReverseLinkedList
{
  class Program
  {
    public class ListNode
    {
      public ListNode(int val, params ListNode[] nodes) {
        this.val = val;
        ListNode current = this;
        foreach (var node in nodes) {
          current.next = node;
          current = node;
        }
      }

      public int val;
      public ListNode next;
      public ListNode(int x) { val = x; }
    }


    public ListNode ReverseList(ListNode head) {
      var dummy = new ListNode(0);
      ReverseListRecur(head, dummy);
      return dummy.next;
    }

    private ListNode ReverseListRecur(ListNode head, ListNode tail) {
      if (head == null) {
        return null;
      }
      var result = ReverseListRecur(head.next, tail);
      var nodeClone = new ListNode(head.val);
      if (result == null) {
        tail.next = nodeClone;
      } else {
        result.next = nodeClone;
      }

      return nodeClone;
    }

    static void Main(string[] args) {
      var p = new Program();
      ListNode nodes;
      nodes = new ListNode(1, new ListNode(2), new ListNode(3), new ListNode(4), new ListNode(5));
      var result = p.ReverseList(nodes);
      PrintList(result);
      Console.WriteLine("Hello World!");
    }

    private static void PrintList(ListNode result) {
      if (result == null) {
        Console.WriteLine("empty list");
      }
      while (result != null) {
        Console.WriteLine(result.val);
        result = result.next;
      }
    }
  }
}
