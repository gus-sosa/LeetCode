package RotateList;

import java.util.Stack;

class Solution {
    public ListNode rotateRight(ListNode head, int k) {
        if (k == 0 || head == null) {
            return head;
        }

        var stack = new Stack<ListNode>();
        ListNode current = head;
        while (current != null) {
            stack.push(current);
            current = current.next;
        }
        k = k % stack.size();

        stack.peek().next = head;
        while (!stack.empty() && k > 0) {
            head = stack.pop();
            --k;
        }
        if (!stack.empty()) {
            stack.peek().next = null;
        }
        return head;
    }
}