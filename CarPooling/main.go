package main

import (
	"container/heap"
	"fmt"
	"sort"
)

func main() {
	//test 1
	trips := [][]int{
		{2, 1, 5},
		{3, 3, 7},
	}
	fmt.Println(carPooling(trips, 4) == false)
	//test 2
	trips = [][]int{
		{2, 1, 5},
		{3, 3, 7},
	}
	fmt.Println(carPooling(trips, 5) == true)
	//test 3
	trips = [][]int{
		{2, 1, 5},
		{3, 5, 7},
	}
	fmt.Println(carPooling(trips, 4) == true)
	//test 4
	trips = [][]int{
		{2, 1, 5},
		{5, 5, 7},
	}
	fmt.Println(carPooling(trips, 4) == false)
	//test 5
	trips = [][]int{
		{9, 3, 4},
		{9, 1, 7},
		{4, 2, 4},
		{7, 4, 5},
	}
	fmt.Println(carPooling(trips, 23) == true)
}

///////////////
func carPooling(trips [][]int, capacity int) bool {
	nextArrivals := Heap{}
	numPassengers := 0
	sort.Slice(trips, func(i, j int) bool {
		return trips[i][1] < trips[j][1]
	})
	for _, v := range trips {
		for len(nextArrivals) > 0 && nextArrivals[0].destinationPos <= v[1] {
			numPassengers -= nextArrivals[0].numPassengers
			heap.Pop(&nextArrivals)
		}
		numPassengers += v[0]
		heap.Push(&nextArrivals, Info{numPassengers: v[0], destinationPos: v[2]})
		if numPassengers > capacity {
			return false
		}
	}
	return true
}

type Info struct {
	numPassengers  int
	destinationPos int
}

type Heap []Info

func (h Heap) Len() int           { return len(h) }
func (h Heap) Less(i, j int) bool { return h[i].destinationPos < h[j].destinationPos }
func (h Heap) Swap(i, j int)      { h[i], h[j] = h[j], h[i] }

func (h *Heap) Push(x interface{}) {
	// Push and Pop use pointer receivers because they modify the slice's length,
	// not just its contents.
	*h = append(*h, x.(Info))
}

func (h *Heap) Pop() interface{} {
	old := *h
	n := len(old)
	x := old[n-1]
	*h = old[0 : n-1]
	return x
}
