using System;
using System.Collections.Generic;
using System.Linq;

namespace IntersectionOfTwoLinkedList {
  class Program {
    /**
 * Definition for singly-linked list.*/
    public class ListNode {
      public int val;
      public ListNode next;
      public ListNode(int x) { val = x; }

      public ListNode(IEnumerable<int> nums) {
        int l = nums.Count();
        if (l > 0) {
          val = nums.First();
          if (l - 1 > 0) {
            next = new ListNode(nums.Skip(1));
          }
        }
      }
    }


    static void Main(string[] args) {
      Console.WriteLine();
    }

    public ListNode GetIntersectionNode(ListNode headA, ListNode headB) {
      var set = new HashSet<ListNode>();
      while (headA != null) {
        set.Add(headA);
        headA = headA.next;
      }
      while (headB != null) {
        if (set.Contains(headB)) {
          return headB;
        }
        headB = headB.next;
      }
      return null;
    }
  }
}
