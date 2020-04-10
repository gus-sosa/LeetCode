using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife {
  class Program {
    static void Main(string[] args) {
      var s = new Solution();
      var m = new int[][] {
        new int[]{ 0,1,0},
        new int[]{ 0,0,1},
        new int[]{ 1,1,1},
        new int[]{ 0,0,0}
      };
      PrintMatrix(m);
      s.GameOfLife(m);
      Console.WriteLine();
      PrintMatrix(m);
    }

    private static void PrintMatrix(int[][] m) {
      for (int i = 0; i < m.Length; ++i) {
        for (int j = 0; j < m[0].Length; ++j) {
          Console.Write($"{m[i][j]}  ");
        }
        Console.WriteLine();
      }
    }
  }

  #region MyRegion


  public class Solution {
    const int ALIVE = 1;
    const int LIVE_CELL_LIVES_NEXT_GEN = -3;
    const int LIVE_CELL_DIES_NEXT_GEN = -4;
    const int DIED_CELL_DIES_NEXT_GEN = -2;
    const int DIED_CELL_LIVES_NEXT_GEN = -1;
    static int[] rowDir = new int[] { -1, -1, 0, 1, 1, 1, 0, -1 };
    static int[] colDir = new int[] { 0, 1, 1, 1, 0, -1, -1, -1 };
    static int[] aliveCellsAlongGen = new int[] { ALIVE, LIVE_CELL_DIES_NEXT_GEN, LIVE_CELL_LIVES_NEXT_GEN };

    public void GameOfLife(int[][] board) {
      for (int i = 0; i < board.Length; ++i) {
        for (int j = 0; j < board[0].Length; ++j) {
          int aliveNeighborsCount = CountAlive(GetNeighbors(i, j, board), board);
          if (board[i][j] == ALIVE) {
            board[i][j] = aliveNeighborsCount == 2 || aliveNeighborsCount == 3 ? LIVE_CELL_LIVES_NEXT_GEN : LIVE_CELL_DIES_NEXT_GEN;
          } else {
            board[i][j] = aliveNeighborsCount == 3 ? DIED_CELL_LIVES_NEXT_GEN : DIED_CELL_DIES_NEXT_GEN;
          }
        }
      }
      for (int i = 0; i < board.Length; ++i) {
        for (int j = 0; j < board[0].Length; ++j) {
          board[i][j] = -(board[i][j] % 2);
        }
      }
    }

    private int CountAlive(Tuple<int, int>[] tuples, int[][] board) {
      return tuples.Count(i => aliveCellsAlongGen.Contains(board[i.Item1][i.Item2]));
    }

    private Tuple<int, int>[] GetNeighbors(int i, int j, int[][] board) {
      var retval = new List<Tuple<int, int>>();
      for (int d = 0, iNext, jNext; d < rowDir.Length; ++d) {
        iNext = rowDir[d] + i;
        jNext = colDir[d] + j;
        if (iNext >= 0 && jNext >= 0 && iNext < board.Length && jNext < board[0].Length) {
          retval.Add(Tuple.Create(iNext, jNext));
        }
      }
      return retval.ToArray();
    }
  }


  #endregion
}
