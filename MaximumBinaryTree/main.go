package main

func main() {

}

////////////////////

type TreeNode struct {
	Val   int
	Left  *TreeNode
	Right *TreeNode
}

//////////////////
func constructMaximumBinaryTree(nums []int) *TreeNode {
	maxs, maxsIndexes := preComputeMaximums(nums)
	return buildMaximumBT(nums, 0, len(nums)-1, maxs, maxsIndexes)
}

func buildMaximumBT(nums []int, start int, end int, maxs [][]int, maxsIndexes [][]int) *TreeNode {
	if start > end {
		return nil
	}
	if start == end {
		return &TreeNode{Val: nums[start]}
	}
	return &TreeNode{
		Val:   maxs[start][end],
		Left:  buildMaximumBT(nums, start, maxsIndexes[start][end]-1, maxs, maxsIndexes),
		Right: buildMaximumBT(nums, maxsIndexes[start][end]+1, end, maxs, maxsIndexes),
	}
}

func preComputeMaximums(nums []int) ([][]int, [][]int) {
	numsLength := len(nums)
	maxs := make([][]int, numsLength)
	maxsIndexes := make([][]int, numsLength)
	for i, _ := range nums {
		maxs[i] = make([]int, numsLength)
		maxsIndexes[i] = make([]int, numsLength)
	}
	for i, _ := range maxs {
		for j := i; j < numsLength; j++ {
			if i == j {
				maxs[i][j] = nums[i]
				maxsIndexes[i][j] = i
				continue
			}
			if maxs[i][j-1] <= nums[j] {
				maxs[i][j] = nums[j]
				maxsIndexes[i][j] = j
			} else {
				maxs[i][j] = maxs[i][j-1]
				maxsIndexes[i][j] = maxsIndexes[i][j-1]
			}
		}
	}
	return maxs, maxsIndexes
}
