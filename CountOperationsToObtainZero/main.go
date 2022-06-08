package main

import "fmt"

func main() {
	fmt.Println(countOperations(2, 3) == 3)
	fmt.Println(countOperations(10, 10) == 1)
	fmt.Println(countOperations(3, 2) == 3)
	fmt.Println(countOperations(7, 5) == 5)
}

///////////////////////
func countOperations(num1 int, num2 int) int {
	var (
		numOperations, count int
	)
	for num1 > 0 && num2 > 0 {
		if num1 >= num2 {
			num1, count = doSubstraction(num1, num2)
		} else {
			num2, count = doSubstraction(num2, num1)
		}
		numOperations += count
	}
	return numOperations
}

func doSubstraction(num1, num2 int) (result, count int) {
	count = num1 / num2
	result = num1 % num2
	return
}
