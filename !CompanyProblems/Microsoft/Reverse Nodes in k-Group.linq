<Query Kind="Program" />

void Main()
{

}

// Define other methods and classes here
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
	public ListNode ReverseKGroup(ListNode head, int k)
	{
		ListNode previousGroupLastElement = null, current = head;
		var s = new Stack<ListNode>();
		while (current != null)
		{
			if (s.Count == k)
			{
				reverseGroup(s, ref current, ref previousGroupLastElement, ref head);
			}
			s.Push(current);
			current = current.next;
		}
		if (s.Count == k)
		{
			ListNode nil = null;
			reverseGroup(s, ref nil, ref previousGroupLastElement, ref head);
		}
		return head;
	}

	private void reverseGroup(Stack<ListNode> s, ref ListNode current, ref ListNode previousGroupLastElement, ref ListNode head)
	{
		if (previousGroupLastElement == null)
		{
			head = s.Peek();
		}
		else
		{
			previousGroupLastElement.next = s.Peek();
		}
		var groupCurrent = s.Pop();
		while (s.Count > 0)
		{
			groupCurrent.next = s.Peek();
			groupCurrent = s.Pop();
		}
		groupCurrent.next = current;
		previousGroupLastElement = groupCurrent;
	}
}