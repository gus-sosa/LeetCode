<Query Kind="Program" />

void Main()
{
	var s = new Solution();
	var commonList = new ListNode(2)
	{
		next = new ListNode(4)
	};
	var l1 = new ListNode(1) { next = new ListNode(9) { next = new ListNode(1) { next = commonList } } };
	var l2 = new ListNode(3) { next = commonList };
	s.GetIntersectionNode(l1, l2);
}

public class ListNode
{
	public int val;
	public ListNode next;
	public ListNode(int x) { val = x; }
}

public class Solution
{
	const int lowerLimit = 1;
	public ListNode GetIntersectionNode(ListNode headA, ListNode headB)
	{
		inverse(headA);
		ListNode pivot = headB, commonNode = null;
		while (commonNode == null && pivot != null)
		{
			if (pivot.val < lowerLimit)
			{
				commonNode = pivot;
			}
			pivot = pivot.next;
		}
		inverse(headA);
		return commonNode;
	}

	void inverse(ListNode node)
	{
		while (node != null)
		{
			node.val *= -1;
			node = node.next;
		}
	}
}