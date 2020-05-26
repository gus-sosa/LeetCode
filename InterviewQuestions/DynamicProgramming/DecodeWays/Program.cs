using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace DecodeWays {
  class Program {
    static void Main(string[] args) {
      var s = new Solution();
      Console.WriteLine(s.NumDecodings("12") == 2);
      Console.WriteLine(s.NumDecodings("226") == 3);
      Console.WriteLine(s.NumDecodings("0") == 0);
      Console.WriteLine(s.NumDecodings("10") == 1);
      Console.WriteLine(s.NumDecodings("20") == 1);
    }
  }

  #region MyRegion


  public class Solution {
    Dictionary<int, int> dict;
    string s;
    public int NumDecodings(string s) {
      dict = new Dictionary<int, int>();
      this.s = s;
      dict[s.Length] = 1;
      return NumDecodings(0);
    }

    private int NumDecodings(int pos) {
      if (dict.ContainsKey(pos)) {
        return dict[pos];
      }

      if (s[pos] == '0') {
        return 0;
      }

      int total = NumDecodings(pos + 1);
      if (pos != s.Length - 1 && int.Parse(s.Substring(pos, 2)) < 27) {
        total += NumDecodings(pos + 2);
      }
      return total;
    }
  }


  #endregion
}
