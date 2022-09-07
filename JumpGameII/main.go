package main

import (
	"fmt"
	"math"
)

func main() {
	l := []int{2, 3, 1, 1, 4}
	fmt.Println(jump(l) == 2)

	l = []int{2, 3, 0, 1, 4}
	fmt.Println(jump(l) == 2)
}

func jump(nums []int) int {
	m := make([]int, len(nums), len(nums))
	for i, _ := range m {
		m[i] = -1
	}
	m[len(m)-1] = 0
	recur(nums, m, 0)
	return m[0]
}

func recur(nums, mem []int, pos int) int {
	if pos >= len(nums) {
		return 0
	}
	if mem[pos] != -1 {
		return mem[pos]
	}
	minNumSteps := math.MaxInt32
	for i := 1; i <= nums[pos]; i++ {
		minNumSteps = min(recur(nums, mem, pos+i), minNumSteps)
	}
	mem[pos] = minNumSteps + 1
	return mem[pos]
}

func min(a, b int) int {
	if a < b {
		return a
	}
	return b
}
