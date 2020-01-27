using System;

namespace AddTwoNumbers1 {
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

    public ListNode AddTwoNumbers(ListNode l1, ListNode l2) {
      int carry = 0, sum;
      ListNode head = null, current = null;
      while (l1 != null && l2 != null) {
        sum = l1.val + l2.val + carry;
        var node = new ListNode(sum % 10);
        carry = sum / 10;
        if (current == null) {
          current = node;
          head = current;
        } else {
          current.next = node;
          current = node;
        }
        if (l1.next == null && l2.next != null) {
          l1.next = new ListNode(0);
        }
        if (l2.next == null && l1.next != null) {
          l2.next = new ListNode(0);
        }
        l1 = l1.next;
        l2 = l2.next;
      }
      if (carry != 0) {
        current.next = new ListNode(carry);
      }
      return head;
    }
  }
}
