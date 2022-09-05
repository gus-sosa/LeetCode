package main

type ListNode struct {
	Val  int
	Next *ListNode
}

func main() {
	l := &ListNode{Val: 1, Next: &ListNode{Val: 2, Next: &ListNode{Val: 3, Next: &ListNode{Val: 4}}}}
	swapPairs(l)
}

func swapPairs(head *ListNode) *ListNode {
	if head == nil || head.Next == nil {
		return head
	}

	previous := head
	current := head.Next
	head = head.Next
	var lastNode *ListNode

	for previous != nil && current != nil {
		nextPrevious := current.Next
		var nextCurrent *ListNode
		if nextPrevious != nil {
			nextCurrent = nextPrevious.Next
		}
		if lastNode != nil {
			lastNode.Next = current
		}
		previous.Next = current.Next
		current.Next = previous
		lastNode = previous

		current = nextCurrent
		previous = nextPrevious
	}

	return head
}
