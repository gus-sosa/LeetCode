package main

func main() {

}

/////////////////
func findDifference(nums1 []int, nums2 []int) [][]int {
	answer0 := getDifference(nums1, nums2)
	answer1 := getDifference(nums2, nums1)
	return [][]int{answer0, answer1}
}

func getDifference(nums1 []int, nums2 []int) []int {
	var flag bool
	retVal := make([]int, 0)
	elements := make(map[int]int)
	for _, v := range nums1 {
		if _, ok := elements[v]; ok {
			continue
		}
		elements[v] = 0
		flag = false
		for _, v1 := range nums2 {
			if v == v1 {
				flag = true
				break
			}
		}
		if !flag {
			retVal = append(retVal, v)
		}
	}
	return retVal
}
