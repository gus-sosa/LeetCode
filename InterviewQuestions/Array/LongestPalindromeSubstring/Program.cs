using System;

namespace LongestPalindromeSubstring {
  class Program {
    static void Main(string[] args) {
      var p = new Program();
      Console.WriteLine(p.LongestPalindrome("babad") == "bab");
      Console.WriteLine(p.LongestPalindrome("abcba") == "abcba");
    }

    public string LongestPalindrome(string s) {
      if (s == null || s.Length == 0) {
        return "";
      }
      var palindromesMatrix = new bool[s.Length, s.Length];
      for (int i = 0; i < s.Length; i++) {
        palindromesMatrix[i, i] = true;
        if (i < s.Length - 1) {
          palindromesMatrix[i, i + 1] = s[i] == s[i + 1];
        }
      }
      for (int len = 3; len <= s.Length; ++len) {
        for (int i = 0; i <= s.Length - len; ++i) {
          palindromesMatrix[i, i + len - 1] = s[i] == s[i + len - 1] && palindromesMatrix[i + 1, i + len - 2];
        }
      }
      int maxStartIndex = 0, maxEndIndex = 0;
      for (int i = 0; i < s.Length; ++i) {
        for (int j = s.Length - 1; j >= i; --j) {
          if (palindromesMatrix[i, j] && j - i > maxEndIndex - maxStartIndex) {
            maxStartIndex = i; maxEndIndex = j;
            break;
          }
        }
      }
      return s.Substring(maxStartIndex, maxEndIndex - maxStartIndex + 1);
    }
  }
}
