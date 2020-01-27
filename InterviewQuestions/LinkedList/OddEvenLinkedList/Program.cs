using System;

namespace OddEvenLinkedList {
  class Program {
    /**
 * Definition for singly-linked list.*/
    public class ListNode {
      public int val;
      public ListNode next;
      public ListNode(int x) { val = x; }
    }


    static void Main(string[] args) {
      Console.WriteLine("Hello World!");
    }

    public ListNode OddEvenList(ListNode head) {
      if (head == null) {
        return head;
      }
      ListNode evenListHead = new ListNode(0), evenListTail = evenListHead, current = head, lastOddNode = head, next;
      int index = 0;
      while (current != null) {
        next = current.next;
        if (++index % 2 == 0) {
          lastOddNode.next = current.next;
          evenListTail.next = current;
          evenListTail = evenListTail.next;
          evenListTail.next = null;
        } else {
          lastOddNode = current;
        }
        current = next;
      }
      lastOddNode.next = evenListHead.next;
      return head;
    }
  }
}
