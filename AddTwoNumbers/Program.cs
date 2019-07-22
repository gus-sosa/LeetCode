using System;

namespace AddTwoNumbers
{
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            int carry = 0;
            ListNode head = null, tail = null;
            while (l1 != null && l2 != null)
            {
                int currentSum = l1.val + l2.val + carry;
                int currentValue = currentSum % 10;
                carry = currentSum / 10;
                var newNode = new ListNode(currentValue);
                if (head == null)
                {
                    head = newNode;
                    tail = head;
                }
                else
                {
                    tail.next = newNode;
                    tail = tail.next;
                }
                l1 = l1.next;
                l2 = l2.next;
            }

            while (l1 != null)
            {
                int currentSum = l1.val + carry;
                int currentValue = currentSum % 10;
                carry = currentSum / 10;
                var newNode = new ListNode(currentValue);
                tail.next = newNode;
                tail = tail.next;
                l1 = l1.next;
            }

            while (l2 != null)
            {
                int currentSum = l2.val + carry;
                int currentValue = currentSum % 10;
                carry = currentSum / 10;
                var newNode = new ListNode(currentValue);
                tail.next = newNode;
                tail = tail.next;
                l2 = l2.next;
            }

            if (carry!=0)
                tail.next = new ListNode(carry);

            return head;
        }
    }
}
