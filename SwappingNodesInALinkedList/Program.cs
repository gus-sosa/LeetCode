using System;
using System.Collections;
using System.Collections.Generic;

namespace SwappingNodesInALinkedList {
  class Program {


    public class ListNode {
      public int val;
      public ListNode next;
      public ListNode(int val = 0, ListNode next = null) {
        this.val = val;
        this.next = next;
      }
    }

    static ListNode CreateListNode(params int[] arr) {
      ListNode head = null, current = null;
      foreach (var item in arr) {
        var node = new ListNode(item);
        if (head == null) {
          head = current = node;
        } else {
          current.next = node;
          current = current.next;
        }
      }
      return head;
    }

    static void Main(string[] args) {
      var s = new Solution();
      CompareListNodes(s.SwapNodes(CreateListNode(1, 2, 3, 4, 5), 2), CreateListNode(1, 4, 3, 2, 5));
      CompareListNodes(s.SwapNodes(CreateListNode(1), 1), CreateListNode(1));
      CompareListNodes(s.SwapNodes(CreateListNode(1, 2), 1), CreateListNode(2, 1));
      CompareListNodes(s.SwapNodes(CreateListNode(1, 2), 2), CreateListNode(2, 1));
      CompareListNodes(s.SwapNodes(CreateListNode(1, 2, 3), 2), CreateListNode(1, 2, 3));
    }

    private static void CompareListNodes(ListNode listNode1, ListNode listNode2) {
      while (listNode1 != null && listNode2 != null) {
        if (listNode1.val != listNode2.val) {
          break;
        }
        listNode1 = listNode1.next;
        listNode2 = listNode2.next;
      }
      Console.WriteLine(listNode1 == null && listNode2 == null);
    }

    #region MyRegion

    public class Solution {
      public ListNode SwapNodes(ListNode head, int k) {
        var queue = new Queue<ListNode>();
        ListNode kThNode = null, current = head;
        int currentPos = 0;
        while (current != null) {
          queue.Enqueue(current);
          if (queue.Count > k) {
            queue.Dequeue();
          }
          if (currentPos == k - 1) {
            kThNode = current;
          }
          ++currentPos;
          current = current.next;
        }
        swapValues(kThNode, queue.Peek());
        return head;
      }

      private void swapValues(ListNode node1, ListNode node2) {
        int tmp = node1.val;
        node1.val = node2.val;
        node2.val = tmp;
      }
    }


    #endregion
  }
}
