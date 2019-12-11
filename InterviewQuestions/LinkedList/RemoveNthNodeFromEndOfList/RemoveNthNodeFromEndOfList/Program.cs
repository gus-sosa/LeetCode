using System;
using System.Collections;
using System.Collections.Generic;

namespace RemoveNthNodeFromEndOfList
{
  class Program
  {
    public ListNode RemoveNthFromEnd(ListNode head, int n) {
      ListNode dummy = new ListNode(0);
      dummy.next = head;
      ListNode first = dummy, second = dummy;
      for (int i = 0; i < n + 1; ++i) {
        second = second.next;
      }
      while (second != null) {
        first = first.next;
        second = second.next;
      }
      first.next = first.next.next;
      return dummy.next;
    }

    static void Main(string[] args) {
      var p = new Program();
      ListNode nodes;
      nodes = new ListNode(1, new ListNode(2), new ListNode(3), new ListNode(4), new ListNode(5));
      var result = p.RemoveNthFromEnd(nodes, 2);
      PrintList(nodes);
      nodes = new ListNode(1);
      nodes = p.RemoveNthFromEnd(nodes, 1);
      PrintList(nodes);
      nodes = new ListNode(1, new ListNode(2));
      nodes = p.RemoveNthFromEnd(nodes, 2);
      PrintList(nodes);
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
}
