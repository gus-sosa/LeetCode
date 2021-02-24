<Query Kind="Program" />

void Main()
{
	var s=new Solution();
	var list=new ListNode(1);
	(s.HasCycle(list)==false).Dump();
}

public class ListNode {
    public int val;
    public ListNode next;
    public ListNode(int x) {
        val = x;
        next = null;
    }
}

public class Solution
{
	public bool HasCycle(ListNode head)
	{
		var slow=head;
		var fast=head;
		while (slow!=null && fast!=null)
		{
			slow=slow.next;
			fast=fast.next;
			if (fast!=null)
			{
				fast=fast.next;
			}
			if (slow==fast && slow!=null)
			{
				return true;
			}
		}
		return false;
	}
}