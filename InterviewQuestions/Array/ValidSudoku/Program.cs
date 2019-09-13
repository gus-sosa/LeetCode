using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidSudoku {
  class Program {
    public bool IsValidSudoku(char[][] board) {
      //Debugger.Launch();
      for (int i = 0; i < board.Length; ++i) {
        if (!ValidRow(board[i])) {
          return false;
        }
      }

      var row = new char[board.Length];
      for (int i = 0; i < board.Length; ++i) {
        for (int j = 0; j < board.Length; ++j) {
          row[j] = board[j][i];
        }
        if (!ValidRow(row)) {
          return false;
        }
      }


      for (int i = 0; i < 9; i += 3) {
        for (int j = 0; j < 9; j += 3) {
          BuildSquare(i, j, row, board);
          if (!ValidRow(row)) {
            return false;
          }
        }
      }

      return true;
    }

    private void BuildSquare(int row, int col, char[] nums, char[][] board) {
      for (int i = row, pos = 0; i < row + 3; ++i) {
        for (int j = col; j < col + 3; ++j, ++pos) {
          nums[pos] = board[i][j];
        }
      }
    }

    private bool ValidRow(char[] row) {
      var hash = new HashSet<int>();
      foreach (var item in row) {
        if (item != '.' && hash.Contains(item)) {
          return false;
        }
        hash.Add(item);
      }
      return true;
    }

    static void Main(string[] args) {
      var p = new Program();
      var result = p.IsValidSudoku(BuildBoard());
      var expectedResult = Console.ReadLine();
      Console.WriteLine(result.ToString() == expectedResult);
    }

    private static char[][] BuildBoard() {
      var board = new char[9][];
      for (int i = 0; i < 9; i++) {
        board[i] = Console.ReadLine().Split().Select(item => Convert.ToChar(item)).ToArray();
      }
      return board;
    }
  }
}
