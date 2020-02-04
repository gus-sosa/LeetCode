using System;
using System.Collections.Generic;
using System.Linq;

namespace LetterCombinationsOfPhoneNumber {
  class Program {
    static void Main(string[] args) {
      var s = new Solution();
      Console.WriteLine(s.LetterCombinations("23").ToArray());
    }
    #region solution

    public class Solution {
      Dictionary<char, IList<char>> map = new Dictionary<char, IList<char>>() {
        ['2'] = new List<char>() { 'a', 'b', 'c' },
        ['3'] = new List<char>() { 'd', 'e', 'f' },
        ['4'] = new List<char>() { 'g', 'h', 'i' },
        ['5'] = new List<char>() { 'j', 'k', 'l' },
        ['6'] = new List<char>() { 'm', 'n', 'o' },
        ['7'] = new List<char>() { 'p', 'q', 'r', 's' },
        ['8'] = new List<char>() { 't', 'u', 'v' },
        ['9'] = new List<char>() { 'w', 'x', 'y', 'z' },
      };

      public IList<string> LetterCombinations(string digits) {
        if (digits == null || digits.Length == 0) {
          return new List<string>();
        }
        var list = new List<string>();
        foreach (var item in LetterCombinations(digits, 0)) {
          list.Add(item);
        }
        return list;
      }

      private IEnumerable<string> LetterCombinations(string digits, int pos) {
        if (pos >= digits.Length) {
          yield return string.Empty;
        } else {
          foreach (var combination in LetterCombinations(digits, pos + 1)) {
            foreach (var item in map[digits[pos]]) {
              yield return $"{item}{combination}";
            }
          }
        }
      }
    }

    #endregion
  }
}
