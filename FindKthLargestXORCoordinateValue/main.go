package main

import (
	"container/heap"
	"fmt"
)

func main() {
	matrix := [][]int{
		[]int{5, 2},
		[]int{1, 6},
	}
	fmt.Println(kthLargestValue(matrix, 1))
}

func kthLargestValue(matrix [][]int, k int) int {
	numRows := len(matrix)
	numCols := len(matrix[0])
	mapp := make([][]int, numRows)
	for i := range mapp {
		mapp[i] = make([]int, numCols)
	}
	maxHeap := IntHeap{}
	heap.Init(&maxHeap)
	rowAcc := 0
	for i := 0; i < numRows; i++ {
		rowAcc = 0
		for j := 0; j < numCols; j++ {
			if i == 0 {
				mapp[i][j] = rowAcc
			} else {
				mapp[i][j] = rowAcc ^ mapp[i-1][j]
			}
			mapp[i][j] ^= matrix[i][j]
			rowAcc ^= matrix[i][j]
			heap.Push(&maxHeap, mapp[i][j])
			if len(maxHeap) > k {
				heap.Pop(&maxHeap)
			}
		}
	}
	return maxHeap[0]
}

type IntHeap []int

func (h IntHeap) Len() int           { return len(h) }
func (h IntHeap) Less(i, j int) bool { return h[i] < h[j] }
func (h IntHeap) Swap(i, j int)      { h[i], h[j] = h[j], h[i] }

func (h *IntHeap) Push(x interface{}) {
	// Push and Pop use pointer receivers because they modify the slice's length,
	// not just its contents.
	*h = append(*h, x.(int))
}

func (h *IntHeap) Pop() interface{} {
	old := *h
	n := len(old)
	x := old[n-1]
	*h = old[0 : n-1]
	return x
}
