using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinimumWindowsSubstring {
  class Program {
    static void Main(string[] args) {
      Solution s;
      s = new Solution();
      Console.WriteLine(s.MinWindow("ADOBECODEBANC", "ABC") == "BANC");
      s = new Solution();
      Console.WriteLine(s.MinWindow("aa", "a") == "a");
      s = new Solution();
      Console.WriteLine(s.MinWindow("a", "aa") == "");
      s = new Solution();
      Console.WriteLine(s.MinWindow("ab", "b") == "b");
    }
  }

  #region MyRegion


  public class Solution {
    const int ALPHABET_LENGTH = 100;
    const char FIRST_LETTER_IN_ALPHABET = 'A';
    int p1 = 0, p2 = 0, bestp = 0, bestL = -1;
    int[] tcount, ccount = new int[ALPHABET_LENGTH];
    string s, t;
    public string MinWindow(string s, string t) {
      this.s = s;
      tcount = getCount(t);
      while (p2 < s.Length) {
        expand();
        contract();
      }
      return bestL == -1 ? string.Empty : s.Substring(bestp, bestL);
    }

    private void contract() {
      while (p1 < p2 && isValid()) {
        if (bestL == -1 || p2 - p1 < bestL) {
          bestL = p2 - p1;
          bestp = p1;
        }
        --ccount[s[p1++] - FIRST_LETTER_IN_ALPHABET];
      }
    }

    private void expand() {
      while (p2 < s.Length && !isValid()) {
        ++ccount[s[p2++] - FIRST_LETTER_IN_ALPHABET];
      }
    }

    private bool isValid() {
      for (int i = 0; i < ALPHABET_LENGTH; ++i) {
        if (ccount[i] < tcount[i]) {
          return false;
        }
      }
      return true;
    }

    private int[] getCount(string t) {
      var retval = new int[ALPHABET_LENGTH];
      foreach (var item in t) {
        ++retval[item - FIRST_LETTER_IN_ALPHABET];
      }
      return retval;
    }
  }


  #endregion
}
