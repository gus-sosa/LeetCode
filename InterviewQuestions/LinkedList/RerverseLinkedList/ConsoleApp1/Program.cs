using System;

namespace ConsoleApp1
{
  class Program
  {
    public class ListNode
    {
      public int val;
      public ListNode next;
      public ListNode(int x) { val = x; }
    }


    public ListNode ReverseList(ListNode head) {
      ListNode result = null;
      while (head != null) {
        var node = new ListNode(head.val);
        node.next = result;
        result = node;
        head = head.next;
      }
      return result;
    }

    static void Main(string[] args) {
      Console.WriteLine("Hello World!");
    }
  }
}
