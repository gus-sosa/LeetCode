package main

import "fmt"

func main() {
	t := TreeNode{
		Val:  1,
		Left: &TreeNode{Val: 2},
	}
	fmt.Println(hasPathSum(&t, 1))
}

//////////////////////

type TreeNode struct {
	Val   int
	Left  *TreeNode
	Right *TreeNode
}

//////////////////////
func hasPathSum(root *TreeNode, targetSum int) bool {
	if root == nil {
		return false
	}
	return hasPathSumRecur(root, 0, targetSum)
}

func hasPathSumRecur(root *TreeNode, currentSum, targetSum int) bool {
	currentSum += (*root).Val
	if (*root).Left == nil && (*root).Right == nil {
		if currentSum == targetSum {
			return true
		}
		return false
	}

	if (*root).Left != nil && hasPathSumRecur((*&root).Left, currentSum, targetSum) {
		return true
	}

	if (*root).Right != nil && hasPathSumRecur((*root).Right, currentSum, targetSum) {
		return true
	}

	return false
}
