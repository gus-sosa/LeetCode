package main

type Node struct {
	Val      int
	Children []*Node
}

func main() {

}

func levelOrder(root *Node) [][]int {
	if root == nil {
		return [][]int{}
	}
	retVal := [][]int{}
	currentQueue := []*Node{root}
	nextQueue := []*Node{}
	for len(currentQueue) > 0 {
		currentLevel := []int{}
		for _, node := range currentQueue {
			currentLevel = append(currentLevel, node.Val)
			for _, child := range node.Children {
				nextQueue = append(nextQueue, child)
			}
		}
		retVal = append(retVal, currentLevel)
		currentQueue = nextQueue
		nextQueue = []*Node{}
	}
	return retVal
}
