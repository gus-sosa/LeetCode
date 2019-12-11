using System;
using System.Collections;
using System.Collections.Generic;

namespace RemoveNthNodeFromEndOfList
{
  class Program
  {
    public ListNode RemoveNthFromEnd(ListNode head, int n) {
      var queue = new Queue<ListNode>();
      ListNode current = head;
      while (current != null) {
        Enqueue(queue, current, n + 1);
        current = current.next;
      }
      if (queue.Count <= n) {
        head = head.next;
      } else {
        current = queue.Dequeue();
        if (queue.Count>1) {
          queue.Dequeue();
          current.next = queue.Dequeue();
        } else {
          current.next = null;
        }
      }
      return head;
    }

    private void Enqueue(Queue<ListNode> queue, ListNode current, int capacity) {
      if (queue.Count >= capacity) {
        queue.Dequeue();
      }
      queue.Enqueue(current);
    }

    static void Main(string[] args) {
      var p = new Program();
      var nodes = new ListNode(1, new ListNode(2), new ListNode(3), new ListNode(4), new ListNode(5));
      var result = p.RemoveNthFromEnd(nodes, 2);
      PrintList(result);
      Console.WriteLine("Hello World!");
    }

    private static void PrintList(ListNode result) {
      if (result != null) {
        Console.WriteLine(result.val);
        PrintList(result.next);
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
