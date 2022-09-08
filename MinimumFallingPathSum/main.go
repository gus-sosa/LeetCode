package main

func main() {

}

func minFallingPathSum(matrix [][]int) int {
	computeMinPaths(matrix)
	return getMax(matrix[0])
}

func computeMinPaths(matrix [][]int) {
	for i := len(matrix) - 2; i >= 0; i-- {
		currentRow := matrix[i]
		for j, v := range currentRow {
			bestValue := matrix[i+1][j]
			if j > 0 && matrix[i+1][j-1] < bestValue {
				bestValue = matrix[i+1][j-1]
			}
			if j < len(matrix[0])-1 && matrix[i+1][j+1] < bestValue {
				bestValue = matrix[i+1][j+1]
			}
			matrix[i][j] = v + bestValue
		}
	}
}

func getMax(arr []int) int {
	retVal := arr[0]
	for _, v := range arr {
		if v < retVal {
			retVal = v
		}
	}
	return retVal
}
