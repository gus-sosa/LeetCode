package main

import "fmt"

func main() {
	fmt.Println(maxRotateFunction([]int{4, 3, 2, 6}))
	fmt.Println(maxRotateFunction([]int{100}))
}

func maxRotateFunction(nums []int) int {
	fi, s := computeInitialValues(nums)
	max := fi
	currentIndex := len(nums) - 1
	for i := 1; i < len(nums); i, currentIndex = i+1, currentIndex-1 {
		if currentIndex == -1 {
			currentIndex = len(nums) - 1
		}
		fi = fi + s - len(nums)*nums[currentIndex]
		if fi > max {
			max = fi
		}
	}
	return max
}

func computeInitialValues(nums []int) (int, int) {
	f0, s := 0, 0
	for i := 0; i < len(nums); i++ {
		s += nums[i]
		f0 += nums[i] * i
	}
	return f0, s
}
