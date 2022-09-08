package main

import (
	"fmt"
	"sort"
)

func main() {
	l := []int{1, 2, 3, 4}
	fmt.Println(rangeSum(l, 4, 1, 5))
}

func rangeSum(nums []int, n int, left int, right int) int {
	sums := make([]int, 0)
	for i, _ := range nums {
		currentSum := 0
		for j := i; j < len(nums); j++ {
			currentSum += nums[j]
			sums = append(sums, currentSum)
		}
	}
	sort.Ints(sums)
	left, right, retVal := left-1, right-1, 0
	for left <= right {
		retVal = (retVal + sums[left]) % 1000000007
		left++
	}
	return retVal
}
