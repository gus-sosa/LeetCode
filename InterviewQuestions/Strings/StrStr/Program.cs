using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace StrStr {
  class Program {
    public int[] computeLps(string pat) {
      int[] lps = new int[pat.Length];
      int i = 1, l = 0;
      while (i < pat.Length) {
        if (pat[i] == pat[l]) {
          lps[i++] = ++l;
        } else {
          if (l == 0) {
            lps[i++] = 0;
          } else {
            l = lps[l - 1];
          }
        }
      }
      return lps;
    }

    public int StrStr(string haystack, string needle) {
      if (needle.Length == 0) {
        return 0;
      }
      int[] lps = computeLps(needle);
      for (int i = 0, j = 0; i < haystack.Length;) {
        if (haystack[i] == needle[j]) {
          ++i; ++j;
          if (j == needle.Length) {
            return i - j;//pattern found
            //j = lps[j - 1];//I would do this in case I want to continue searching matches
          }
        } else {
          if (j == 0) {
            ++i;
          } else {
            j = lps[j - 1];
          }
        }
      }
      return -1;
    }

    static void Main(string[] args) {
      var p = new Program();
      Console.WriteLine("=====testing strstr=====");
      Console.WriteLine(p.StrStr("gus", "") == 0);
      Console.WriteLine(p.StrStr("gus", "g") == 0);
      Console.WriteLine(p.StrStr("gus", "gu") == 0);
      Console.WriteLine(p.StrStr("gus", "us") == 1);
      Console.WriteLine(p.StrStr("gus", "s") == 2);
      Console.WriteLine(p.StrStr("gus", "d") == -1);
      Console.WriteLine(p.StrStr("aaaaa", "bba") == -1);
      Console.WriteLine(p.StrStr("", "bba") == -1);
      Console.WriteLine("=====testing computelps=====");
      Console.WriteLine(AreSameArray(p.computeLps("aaba"), new[] { 0, 1, 0, 1 }) == true);
      Console.WriteLine(AreSameArray(p.computeLps("babaacaabaa"), new[] { 0, 0, 1, 2, 0, 0, 0, 0, 1, 2, 0 }) == true);
    }

    private static bool AreSameArray(int[] arr1, int[] arr2) {
      return arr1.Length == arr2.Length && Enumerable.Zip(arr1, arr2, (i, j) => i == j).All(i => i == true);
    }
  }
}
