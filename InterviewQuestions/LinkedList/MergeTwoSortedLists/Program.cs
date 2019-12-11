using System;

namespace MergeTwoSortedLists
{
  public class ListNode
  {
    public int val;
    public ListNode next;
    public ListNode(int x) { val = x; }
  }


  class Program
  {
    public ListNode MergeTwoLists(ListNode l1, ListNode l2) {
      var dummy = new ListNode(0);
      var current = dummy;
      while (l1 != null && l2 != null) {
        if (l1.val < l2.val) {
          current.next = new ListNode(l1.val);
          l1 = l1.next;
        } else {
          current.next = new ListNode(l2.val);
          l2 = l2.next;
        }
        current = current.next;
      }
      if (l1 != null) {
        current.next = l1;
      }
      if (l2 != null) {
        current.next = l2;
      }
      return dummy.next;
    }

    static void Main(string[] args) {
      Console.WriteLine("Hello World!");
    }
  }
}
