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
      Console.WriteLine(s.NumDecodings("2611") == 4);
      Console.WriteLine(s.NumDecodings("01") == 0);
    }
  }

  #region MyRegion


  public class Solution {
    int[] dec;
    string s;
    public int NumDecodings(string s) {
      dec = new int[s.Length + 1];
      Array.Fill(dec, -1);
      this.s = s + " ";
      return NumDecodings(0);
    }

    private int NumDecodings(int pos) {
      if (pos >= s.Length - 1) {
        return 1;
      }
      if (dec[pos] != -1) {
        return dec[pos];
      }

      int num = Convert.ToInt32(s[pos].ToString()), count = 0;
      if (num > 0 && num < 27) {
        count += NumDecodings(pos + 1);
        num = Convert.ToInt32(s[pos].ToString() + s[pos + 1].ToString());
        if (num > 0 && num < 27 && pos + 2 < s.Length) {
          count += NumDecodings(pos + 2);
        }
      }

      return dec[pos] = count;
    }
  }


  #endregion
}
