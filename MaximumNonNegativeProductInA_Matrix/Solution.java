package MaximumNonNegativeProductInA_Matrix;

class Solution {
    private int MODULE = 1000000007;
    private int MAX_MAP_LENGTH = 20;
    private Long[][] mapMax;
    private Long[][] mapMin;
    private int[][] grid;
    private boolean[][] mapMaxValueExist;
    private boolean[][] mapMinValueExist;

    public int maxProductPath(int[][] grid) {
        this.grid = grid;
        initializeMaps();
        maxProductPath(grid.length - 1, grid[0].length - 1);
        Long result = mapMax[grid.length - 1][grid[0].length - 1];
        return result < 0 ? -1 : (int) (result % MODULE);
    }

    private void maxProductPath(int rowIndex, int colIndex) {
        if (rowIndex < 0 || colIndex < 0) {
            return;
        }

        if (mapMaxValueExist[rowIndex][colIndex]) {
            return;
        }

        mapMaxValueExist[rowIndex][colIndex] = true;
        if (grid[rowIndex][colIndex] == 0) {
            mapMax[rowIndex][colIndex] = mapMin[rowIndex][colIndex] = 0L;
            return;
        }

        maxProductPath(rowIndex - 1, colIndex);
        maxProductPath(rowIndex, colIndex - 1);

        if (rowIndex == 0) {
            mapMax[rowIndex][colIndex] = grid[0][colIndex] * mapMax[0][colIndex - 1];
            mapMin[rowIndex][colIndex] = grid[0][colIndex] * mapMin[0][colIndex - 1];
            return;
        }

        if (colIndex == 0) {
            mapMax[rowIndex][colIndex] = grid[rowIndex][0] * mapMax[rowIndex - 1][0];
            mapMin[rowIndex][colIndex] = grid[rowIndex][0] * mapMin[rowIndex - 1][0];
            return;
        }

        if (grid[rowIndex][colIndex] > 0) {
            mapMax[rowIndex][colIndex] = grid[rowIndex][colIndex]
                    * Math.max(mapMax[rowIndex - 1][colIndex], mapMax[rowIndex][colIndex - 1]);
            mapMin[rowIndex][colIndex] = grid[rowIndex][colIndex]
                    * Math.min(mapMin[rowIndex - 1][colIndex], mapMin[rowIndex][colIndex - 1]);
        } else {
            mapMax[rowIndex][colIndex] = grid[rowIndex][colIndex]
                    * Math.min(mapMin[rowIndex - 1][colIndex], mapMin[rowIndex][colIndex - 1]);
            mapMin[rowIndex][colIndex] = grid[rowIndex][colIndex]
                    * Math.max(mapMax[rowIndex - 1][colIndex], mapMax[rowIndex][colIndex - 1]);
        }
    }

    private void initializeMaps() {
        mapMax = new Long[MAX_MAP_LENGTH][];
        mapMin = new Long[MAX_MAP_LENGTH][];
        mapMaxValueExist = new boolean[MAX_MAP_LENGTH][];
        mapMinValueExist = new boolean[MAX_MAP_LENGTH][];
        for (int i = 0; i < MAX_MAP_LENGTH; i++) {
            mapMax[i] = new Long[MAX_MAP_LENGTH];
            mapMin[i] = new Long[MAX_MAP_LENGTH];
            mapMaxValueExist[i] = new boolean[MAX_MAP_LENGTH];
            mapMinValueExist[i] = new boolean[MAX_MAP_LENGTH];
        }
        mapMin[0][0] = mapMax[0][0] = grid[0][0] * 1L;
        mapMaxValueExist[0][0] = true;
        mapMinValueExist[0][0] = true;
    }
}
