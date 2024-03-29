package main

func main() {

}

type TreeNode struct {
	Val   int
	Left  *TreeNode
	Right *TreeNode
}

var set map[int]int

func maxLevelSum(root *TreeNode) int {
	set = make(map[int]int)
	dfs(root, 1)
	bestLevel := -1
	bestSum := 0
	for key, value := range set {
		if bestLevel == -1 {
			bestLevel = key
			bestSum = value
			continue
		}
		if bestSum == value && key < bestLevel {
			bestLevel = key
			continue
		}
		if value > bestSum {
			bestSum = value
			bestLevel = key
		}
	}
	return bestLevel
}

func dfs(node *TreeNode, level int) {
	if node == nil {
		return
	}
	if _, ok := set[level]; !ok {
		set[level] = 0
	}
	set[level] += node.Val
	dfs(node.Left, level+1)
	dfs(node.Right, level+1)
}
