package main

import "fmt"

func main() {
	tree1 := TreeNode{
		Val:   1,
		Right: &TreeNode{Val: 8},
	}
	tree2 := TreeNode{
		Val:  8,
		Left: &TreeNode{Val: 1},
	}
	fmt.Println("%v", getAllElements(&tree1, &tree2))
}

type TreeNode struct {
	Val   int
	Left  *TreeNode
	Right *TreeNode
}

///////////////////
func getAllElements(root1 *TreeNode, root2 *TreeNode) []int {
	list1 := getList(root1)
	fmt.Println(list1)
	list2 := getList(root2)
	fmt.Println(list2)
	return mergeSortedLists(list1, list2)
}

func getList(root *TreeNode) []int {
	if root == nil {
		return []int{}
	}

	leftList := getList(root.Left)
	leftList = append(leftList, root.Val)
	rightList := getList(root.Right)

	return mergeSortedLists(leftList, rightList)
}

func mergeSortedLists(list1, list2 []int) []int {
	length := len(list1) + len(list2)
	retVal := make([]int, length)
	iList1 := 0
	iList2 := 0
	iRetVal := 0
	for iList1 < len(list1) && iList2 < len(list2) {
		if list1[iList1] <= list2[iList2] {
			retVal[iRetVal] = list1[iList1]
			iList1++
		} else {
			retVal[iRetVal] = list2[iList2]
			iList2++
		}
		iRetVal++
	}
	for iList1 < len(list1) {
		retVal[iRetVal] = list1[iList1]
		iList1++
		iRetVal++
	}
	for iList2 < len(list2) {
		retVal[iRetVal] = list2[iList2]
		iList2++
		iRetVal++
	}
	return retVal
}
