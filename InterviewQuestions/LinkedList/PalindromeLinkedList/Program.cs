using System;

namespace PalindromeLinkedList
{
  public class ListNode
  {
    public int val;
    public ListNode next;
    public ListNode(int x) { val = x; }
  }


  class Program
  {
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

    public bool IsPalindrome(ListNode head) {
      ListNode reverse = ReverseList(head);
      while (head != null) {
        if (head.val != reverse.val) {
          return false;
        }
        head = head.next;
        reverse = reverse.next;
      }
      return true;
    }

    static void Main(string[] args) {
      Console.WriteLine("Hello World!");
    }
  }
}
