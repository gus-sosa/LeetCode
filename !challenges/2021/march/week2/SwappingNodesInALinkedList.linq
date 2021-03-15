<Query Kind="Program" />

void Main()
{

}

// You can define other methods, fields, classes and namespaces here

public class ListNode
{
	public int val;
	public ListNode next;
	public ListNode(int val = 0, ListNode next = null)
	{
		this.val = val;
		this.next = next;
	}
}

public class Solution
{
	public ListNode SwapNodes(ListNode head, int k)
	{
		var length = getLength(head);
		int left = k - 1, right = length - k;
		ListNode current = head, leftNode = null, rightNode = null;
		while (current != null)
		{
			if (left-- == 0)
			{
				leftNode = current;
			}
			if (right-- == 0)
			{
				rightNode = current;
			}
			current = current.next;
		}
		int tmp = leftNode.val;
		leftNode.val = rightNode.val;
		rightNode.val = tmp;
		return head;
	}

	private int getLength(ListNode head)
	{
		int count = 0;
		while (head != null)
		{
			head = head.next;
			++count;
		}
		return count;
	}
}