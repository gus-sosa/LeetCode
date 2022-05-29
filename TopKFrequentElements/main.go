package main

import (
	"container/heap"
	"fmt"
)

func main() {
	//fmt.Println(topKFrequent([]int{1, 1, 1, 2, 2, 3}, 2))
	fmt.Println(topKFrequent([]int{1, 2}, 2))
}

/////////////////////////

func topKFrequent(nums []int, k int) []int {
	numFrequencyDict := make(map[int]int)
	frequencyNumDict := make(map[int]map[int]int)
	for _, v := range nums {
		if _, ok := numFrequencyDict[v]; !ok {
			numFrequencyDict[v] = 0
		}
		if numsList, ok := frequencyNumDict[numFrequencyDict[v]]; ok {
			if _, ok1 := numsList[v]; ok1 {
				delete(numsList, v)
			}
			if len(frequencyNumDict[numFrequencyDict[v]]) == 0 {
				delete(frequencyNumDict, numFrequencyDict[v])
			}
		}
		numFrequencyDict[v]++
		if _, ok := frequencyNumDict[numFrequencyDict[v]]; !ok {
			frequencyNumDict[numFrequencyDict[v]] = make(map[int]int)
		}
		frequencyNumDict[numFrequencyDict[v]][v] = 0
	}
	minHeap := IntHeap{}
	for freq, _ := range frequencyNumDict {
		for i := 0; i < len(frequencyNumDict[freq]); i++ {
			heap.Push(&minHeap, freq)
			if len(minHeap) > k {
				heap.Pop(&minHeap)
			}
		}
	}
	retVal := make([]int, 0)
	for _, freq := range minHeap {
		value := 0
		for v, _ := range frequencyNumDict[freq] {
			value = v
			delete(frequencyNumDict[freq], v)
			break
		}
		retVal = append(retVal, value)
	}
	return retVal
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
