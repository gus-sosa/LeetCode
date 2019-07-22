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
                ListNode newNode = Sum(l1, l2, ref carry);
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

            SumList(l1, ref tail, ref carry);
            SumList(l2, ref tail, ref carry);

            if (carry != 0)
                tail.next = new ListNode(carry);

            return head;
        }

        private static void SumList(ListNode l, ref ListNode tail, ref int carry)
        {
            while (l != null)
            {
                var newNode = Sum(l, null, ref carry);
                tail.next = newNode;
                tail = tail.next;
                l = l.next;
            }
        }

        private static ListNode Sum(ListNode l1, ListNode l2, ref int carry)
        {
            var val1 = l1 != null ? l1.val : 0;
            var val2 = l2 != null ? l2.val : 0;
            int currentSum = val1 + val2 + carry;
            int currentValue = currentSum % 10;
            carry = currentSum / 10;
            return new ListNode(currentValue);
        }
    }
}
