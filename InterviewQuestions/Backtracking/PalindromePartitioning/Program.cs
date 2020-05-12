using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PalindromePartitioning {
  class Program {
    static void Main(string[] args) {
      var s = new Solution();
      Print(s.Partition("abbab"));
      Print(s.Partition("aab"));
      Print(s.Partition("abbab"));
      Print(s.Partition("seeslaveidemonstrateyetartsnomedievalsees"));
    }

    private static void Print(IList<IList<string>> l) {
      Console.WriteLine("============result=================");
      foreach (var set in l) {
        Console.WriteLine("====set===");
        foreach (var item in set) {
          Console.WriteLine(item);
        }
      }
    }
  }

  #region MyRegion


  public class Solution {
    bool[,] palindromeMap;
    int[] maxPalindromeInPos;
    IList<IList<string>> retval;
    List<int> currentPartition;
    string s;
    public IList<IList<string>> Partition(string s) {
      this.s = s;
      palindromeMap = getPalidromeMap(s);
      maxPalindromeInPos = computeMaxPalindromes();
      retval = new List<IList<string>>();
      currentPartition = new List<int>();
      partition(0);
      return retval;
    }

    private void partition(int index) {
      if (index == s.Length) {
        currentPartition.Add(index);
        addCurrentPartitionToRetval();
        currentPartition.RemoveAt(currentPartition.Count - 1);
        return;
      }

      for (int i = index; i <= maxPalindromeInPos[index]; ++i) {
        if (palindromeMap[index, i]) {
          currentPartition.Add(index);
          partition(i + 1);
          currentPartition.RemoveAt(currentPartition.Count - 1);
        }
      }
    }

    private void addCurrentPartitionToRetval() {
      var list = new List<string>();
      for (int i = 1, iStart, iEnd, l; i < currentPartition.Count; ++i) {
        iStart = currentPartition[i - 1];
        iEnd = currentPartition[i] - 1;
        l = iEnd - iStart + 1;
        list.Add(s.Substring(iStart, l));
      }
      retval.Add(list);
    }

    private int[] computeMaxPalindromes() {
      int[] maxs = new int[palindromeMap.GetLength(0)];
      for (int i = 0; i < maxs.Length; ++i) {
        for (int j = maxs.Length - 1; j >= i && maxs[i] == 0; --j) {
          if (palindromeMap[i, j]) {
            maxs[i] = j;
          }
        }
      }
      return maxs;
    }

    private bool[,] getPalidromeMap(string s) {
      var palindromeMap = new bool[s.Length, s.Length];
      for (int l = 1, j; l <= s.Length; ++l) {
        for (int i = 0; i <= s.Length - l; ++i) {
          j = i + l - 1;
          palindromeMap[i, j] = s[i] == s[j];
          if (i + 1 < j && palindromeMap[i, j]) {
            palindromeMap[i, j] = palindromeMap[i + 1, j - 1];
          }
        }
      }
      return palindromeMap;
    }
  }


  #endregion
}
