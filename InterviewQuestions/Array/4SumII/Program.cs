using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4SumII {
  class Program {
    static void Main(string[] args) {
    }
  }

  #region MyRegion


  public class Solution {
    public int FourSumCount(int[] A, int[] B, int[] C, int[] D) {
      var map = new Dictionary<int, int>();
      int sum, i, j, count = 0;
      for (i = 0; i < A.Length; ++i) {
        for (j = 0; j < B.Length; ++j) {
          sum = A[i] + B[j];
          if (map.ContainsKey(sum)) {
            map[sum] = map[sum] + 1;
          } else {
            map[sum] = 1;
          }
        }
      }
      for (i = 0; i < C.Length; ++i) {
        for (j = 0; j < D.Length; ++j) {
          sum = -(C[i] + D[j]);
          if (map.ContainsKey(sum)) {
            count += map[sum];
          }
        }
      }
      return count;
    }
  }


  #endregion
}
