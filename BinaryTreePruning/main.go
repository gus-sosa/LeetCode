package main

type TreeNode struct {
	Val   int
	Left  *TreeNode
	Right *TreeNode
}

func main() {

}

func pruneTree(root *TreeNode) *TreeNode {
	if root == nil {
		return nil
	}
	root.Right = pruneTree(root.Right)
	root.Left = pruneTree(root.Left)
	if root.Right == nil && root.Left == nil && root.Val != 1 {
		return nil
	}
	return root
}
