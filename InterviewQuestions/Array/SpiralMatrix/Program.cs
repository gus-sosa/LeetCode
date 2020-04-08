using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpiralMatrix {
  class Program {
    static void Main(string[] args) {
    }
  }

  #region MyRegion


  public class Solution {
    public IList<int> SpiralOrder(int[][] matrix) {
      var retval = new List<int>();
      if (matrix.Length > 0 && matrix[0].Length > 0) {
        int rowCornerTop = 0, colCornerTop = 0, rowCornerBottom = matrix.Length - 1, colCornerBottom = matrix[0].Length - 1, i = 0;
        while (rowCornerTop <= rowCornerBottom && colCornerTop <= colCornerBottom) {
          for (i = colCornerTop; i <= colCornerBottom; ++i) {
            retval.Add(matrix[rowCornerTop][i]);
          }
          if (rowCornerBottom - rowCornerTop > 0) {
            for (i = rowCornerTop + 1; i <= rowCornerBottom; ++i) {
              retval.Add(matrix[i][colCornerBottom]);
            }
          }
          if (colCornerBottom - colCornerTop > 0 && rowCornerTop != rowCornerBottom) {
            for (i = colCornerBottom - 1; i >= colCornerTop; --i) {
              retval.Add(matrix[rowCornerBottom][i]);
            }
          }
          if (rowCornerBottom - rowCornerTop > 0 && colCornerTop != colCornerBottom) {
            for (i = rowCornerBottom - 1; i > rowCornerTop; --i) {
              retval.Add(matrix[i][colCornerTop]);
            }
          }
          ++rowCornerTop; ++colCornerTop; --rowCornerBottom; --colCornerBottom;
        }
      }
      return retval;
    }
  }


  #endregion
}
