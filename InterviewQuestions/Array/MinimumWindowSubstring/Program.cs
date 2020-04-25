using System;
using System.Collections.Generic;

namespace MinimumWindowSubstring
{
  class Program
  {
    static void Main(string[] args) {
      var s = new Solution();
      Console.WriteLine(s.MinWindow("ADOBECODEBANC", "ABC"));
      Console.WriteLine(s.MinWindow("a", "a"));
      Console.WriteLine(s.MinWindow("aa", "aa"));
    }
  }

  #region MyRegion


  public class Solution
  {
    private static Dictionary<char, int> maxCharacters;
    private static Dictionary<char, int> foundSoFar = new Dictionary<char, int>();
    private static int minStartPos = 0;
    private static int minLength = int.MaxValue;
    private static int numCharactersFound = 0;
    private static int numExtraCharacters = 0;

    public string MinWindow(string s, string t) {
      maxCharacters = buildMaxs(t);
      foreach (var key in maxCharacters.Keys) {
        foundSoFar[key] = 0;
      }
      for (int left = 0, right = -1; right < s.Length;) {
        contract(s, t, ref left, ref right);
        expandByOneCharacter(s, ref right);
      }
      return s.Substring(minStartPos, minLength);
    }

    private static void expandByOneCharacter(string s, ref int right) {
      if (++right < s.Length && maxCharacters.ContainsKey(s[right])) {
        if (foundSoFar[s[right]] + 1 > maxCharacters[s[right]]) {
          ++numExtraCharacters;
        }
        ++numCharactersFound;
        foundSoFar[s[right]] += 1;
      }
    }

    private static void contract(string s, string t, ref int left, ref int right) {
      while (numCharactersFound - numExtraCharacters >= t.Length) {
        if (right - left + 1 < minLength) {
          minStartPos = left;
          minLength = right - left + 1;
        }
        if (maxCharacters.ContainsKey(s[left])) {
          if (foundSoFar[s[left]] > maxCharacters[s[left]]) {
            --numExtraCharacters;
          }
          foundSoFar[s[left]] -= 1;
          if (foundSoFar[s[left]] < maxCharacters[s[left]]) {
            --numCharactersFound;
            ++left;
            break;
          }
        }
        ++left;
      }
    }

    private Dictionary<char, int> buildMaxs(string s) {
      var dict = new Dictionary<char, int>();
      foreach (var c in s) {
        if (dict.ContainsKey(c)) {
          dict[c] += 1;
        } else {
          dict[c] = 1;
        }
      }
      return dict;
    }
  }


  #endregion
}
