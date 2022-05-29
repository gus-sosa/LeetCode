package main

func main() {

}

////////////////

func findCenter(edges [][]int) int {
	counter := countNodeLinks(&edges)
	return getCenter(&counter)
}

func countNodeLinks(edges *[][]int) map[int]int {
	counter := make(map[int]int)
	for _, v := range *edges {
		n1 := v[0]
		n2 := v[1]
		if _, ok := counter[n1]; !ok {
			counter[n1] = 0
		}
		if _, ok := counter[n2]; !ok {
			counter[n2] = 0
		}
		counter[n1] += 1
		counter[n2] += 1
	}
	return counter
}

func getCenter(counter *map[int]int) int {
	numNodes := len(*counter)
	for node, v := range *counter {
		if v == numNodes-1 {
			return node
		}
	}
	return -1
}
