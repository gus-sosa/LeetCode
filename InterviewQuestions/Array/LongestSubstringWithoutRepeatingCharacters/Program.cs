using System;
using System.Collections.Generic;

namespace LongestSubstringWithoutRepeatingCharacters {
  class Program {
    static void Main(string[] args) {
      var p = new Program();
      Console.WriteLine(p.LengthOfLongestSubstring("pwwkew") == 3);
    }

    public int LengthOfLongestSubstring(string s) {
      var dict = new Dictionary<char, int>();
      int max = 0, start = 0;
      for (int i = 0; i < s.Length; ++i) {
        char c = s[i];
        if (dict.ContainsKey(c)) {
          max = Math.Max(max, dict.Count);
          int index = dict[c];
          int newStart = index + 1;
          while (index >= start) {
            dict.Remove(s[index--]);
          }
          start = newStart;
        }
        dict[c] = i;
      }
      return Math.Max(max, dict.Count);
    }
  }
}
