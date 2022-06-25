package main

func main() {
	root := Node{
		Val: 1,
		Left: &Node{
			Val:   2,
			Left:  &Node{Val: 4},
			Right: &Node{Val: 5},
		},
		Right: &Node{
			Val:   3,
			Right: &Node{Val: 7},
		},
	}
	connect(&root)
}

////////////////////

type Node struct {
	Val   int
	Left  *Node
	Right *Node
	Next  *Node
}

func connect(root *Node) *Node {
	if root == nil {
		return nil
	}
	currentQueue := []*Node{root}
	nextQueue := []*Node{}
	for len(currentQueue) > 0 {
		for len(currentQueue) > 0 {
			currentNode := currentQueue[0]
			currentQueue = currentQueue[1:]
			if currentNode.Left != nil {
				nextQueue = append(nextQueue, currentNode.Left)
			}
			if currentNode.Right != nil {
				nextQueue = append(nextQueue, currentNode.Right)
			}
			if len(currentQueue) > 0 {
				currentNode.Next = currentQueue[0]
			}
		}
		tmp := currentQueue
		currentQueue = nextQueue
		nextQueue = tmp
	}
	return root
}
