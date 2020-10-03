using System;

namespace RegularExpressionMatching {
  class Program {
    static void Main(string[] args) {
      var s = new Solution();
      Console.WriteLine(s.IsMatch("aa", "a") == false);
      Console.WriteLine(s.IsMatch("aa", "a*") == true);
      Console.WriteLine(s.IsMatch("ab", ".*") == true);
      Console.WriteLine(s.IsMatch("aab", "c*a*b") == true);
      Console.WriteLine(s.IsMatch("mississippi", "mis*is*p*.") == false);
      Console.WriteLine(s.IsMatch("a", "ab*") == true);
    }
  }

  #region MyRegion


  public class Solution {
    private const char ASTERISK = '*';
    private const char SINGLE_MATCH = '.';

    public bool IsMatch(string s, string p) {
      return isMatch(s, 0, p, 0);
    }

    private bool isMatch(string s, int posS, string p, int posP) {
      if (s.Length == posS && p.Length == posP) {
        return true;
      }
      if (posS >= s.Length || posP >= p.Length) {
        while (posP < p.Length) {
          if (p[posP] != ASTERISK && (posP + 1 >= p.Length || p[posP + 1] != ASTERISK)) {
            return false;
          }
          ++posP;
        }
        return posS == s.Length;
      }
      if (posP + 1 < p.Length && p[posP + 1] == ASTERISK) {
        return isMatch_Asterisk(s, posS, p, posP);
      } else {
        return (p[posP] == SINGLE_MATCH || s[posS] == p[posP]) && isMatch(s, posS + 1, p, posP + 1);
      }
    }

    private bool isMatch_Asterisk(string s, int posS, string p, int posP) {
      if (isMatch(s, posS, p, posP + 2)) {
        return true;
      }
      char c = p[posP];
      var flag = false;
      while (!flag && posS < s.Length && (c == SINGLE_MATCH || s[posS] == c)) {
        if (isMatch(s, posS + 1, p, posP + 2)) {
          flag = true;
        }
        ++posS;
      }
      return flag;
    }
  }


  #endregion
}
