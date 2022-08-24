package main

import (
	"fmt"
	"math"
)

func main() {
	m := [][]int{
		[]int{1, 3, 1},
		[]int{1, 5, 1},
		[]int{4, 2, 1},
	}
	fmt.Println(minPathSum(m))
}

func minPathSum(grid [][]int) int {
	m := make([][]int, len(grid))
	for i, _ := range m {
		m[i] = make([]int, len(grid[0]))
		for ind, _ := range m[i] {
			m[i][ind] = -1
		}
	}

	m[0][0] = grid[0][0]
	computePaths(grid, m, len(m)-1, len(m[0])-1)
	return m[len(m)-1][len(m[0])-1]
}

func computePaths(grid, maxs [][]int, row, col int) {
	if row < 0 || col < 0 || maxs[row][col] != -1 {
		return
	}
	computePaths(grid, maxs, row-1, col)
	computePaths(grid, maxs, row, col-1)
	if row == 0 {
		maxs[row][col] = maxs[row][col-1] + grid[row][col]
		return
	}
	if col == 0 {
		maxs[row][col] = maxs[row-1][col] + grid[row][col]
		return
	}
	maxs[row][col] = int(math.Min(float64(maxs[row-1][col]), float64(maxs[row][col-1]))) + grid[row][col]
}
