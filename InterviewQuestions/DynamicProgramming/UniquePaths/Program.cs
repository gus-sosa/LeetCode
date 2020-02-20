using System;
using System.Collections.Generic;

namespace UniquePaths {
  class Program {
    static void Main(string[] args) {
      var s = new Solution();
      Console.WriteLine(s.UniquePaths(7, 3) == 28);
      Console.WriteLine(s.UniquePaths(3, 7) == 28);
      Console.WriteLine(s.UniquePaths(3, 2) == 3);
      Console.WriteLine(s.UniquePaths(2, 3) == 3);
    }

    #region MyRegion


    public class Solution {
      Dictionary<int, Dictionary<int, int>> dict = new Dictionary<int, Dictionary<int, int>>() {
        [1] = new Dictionary<int, int>() { [1] = 1 }
      };
      public int UniquePaths(int m, int n) {
        if (m > n) {
          return UniquePaths(n, m);
        }
        if (m == 1 && n == 1) {
          return dict[m][n];
        }
        if (dict.ContainsKey(m) && dict[m].ContainsKey(n)) {
          return dict[m][n];
        }
        int result = -1;
        if (m == 1) {
          result = UniquePaths(m, n - 1);
        }
        if (n == 1) {
          result = UniquePaths(m - 1, n);
        }
        if (result == -1) {
          result = UniquePaths(m, n - 1) + UniquePaths(m - 1, n);
        }
        AddToDictionary(m, n, result);
        return result;
      }

      private int AddToDictionary(int m, int n, int v) {
        if (!dict.ContainsKey(m)) {
          dict[m] = new Dictionary<int, int>();
        }
        dict[m][n] = v;
        return v;
      }
    }


    #endregion


  }
}
