package main

func main() {
}

/////////////////////
func getNoZeroIntegers(n int) []int {
	a := 1
	b := n - 1
	for !isNoZeroInteger(a) || !isNoZeroInteger(b) || a+b != n {
		a += 1
		b -= 1
	}
	return []int{a, b}
}

func isNoZeroInteger(num int) bool {
	for num > 1 {
		if num%10 == 0 {
			return false
		}
		num /= 10
	}
	return true
}
