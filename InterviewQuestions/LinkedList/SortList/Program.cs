using System;
using System.Collections.Generic;

namespace SortList {
  class Program {
    static void Main(string[] args) {
      var l = new ListNode(4, new ListNode(2, new ListNode(1, new ListNode(3))));
      var s = new Solution();
      Console.WriteLine("input");
      Print(l);
      var r = s.SortList(l);
      Console.WriteLine("output");
      Print(r);
    }

    private static void Print(ListNode l) {
      while (l != null) {
        Console.WriteLine(l.val);
        l = l.next;
      }
    }
  }

  public class ListNode {
    public int val;
    public ListNode next;
    public ListNode(int val = 0, ListNode next = null) {
      this.val = val;
      this.next = next;
    }
  }


  #region MyRegion

  public class Solution {
    public ListNode SortList(ListNode head) {
      if (head == null) {
        return null;
      }
      ListNode lowersHead = null, lowersTail = null;
      ListNode greatersHead = null, greatersTail = null;
      ListNode current = head.next;
      head.next = null;
      while (current != null) {
        if (current.val <= head.val) {
          addToList(ref lowersHead, ref lowersTail, ref current);
        } else {
          addToList(ref greatersHead, ref greatersTail, ref current);
        }
        var next = current.next;
        current.next = null;
        current = next;
      }
      lowersHead = SortList(lowersHead);
      greatersHead = SortList(greatersHead);
      if (lowersHead != null) {
        current = lowersHead;
        while (current.next != null) {
          current = current.next;
        }
        current.next = head;
      } else {
        lowersHead = head;
      }
      head.next = greatersHead;

      return lowersHead;
    }

    private void addToList(ref ListNode head, ref ListNode tail, ref ListNode node) {
      if (head == null) {
        head = tail = node;
      } else {
        tail.next = node;
        tail = node;
      }
    }
  }


  #endregion
}
