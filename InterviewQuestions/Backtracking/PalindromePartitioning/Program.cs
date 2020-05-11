using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PalindromePartitioning
{
  class Program
  {
    static void Main(string[] args) {
      var s = new Solution();
      var l = s.Partition("aab");
      //Print(l);
      l = s.Partition("abbab");
      Print(l);
      l = s.Partition("seeslaveidemonstrateyetartsnomedievalsees");
      Print(l);
    }

    private static void Print(IList<IList<string>> l) {
      foreach (var set in l) {
        Console.WriteLine("====set===");
        foreach (var item in set) {
          Console.WriteLine(item);
        }
      }
    }
  }

  #region MyRegion


  public class Solution
  {
    private static Dictionary<string, bool> map;

    public IList<IList<string>> Partition(string s) {
      var l = new List<IList<string>>();
      map = new Dictionary<string, bool>();
      var currentParition = new List<StringBuilder>();
      Partition(0, s, currentParition, l);
      return l;
    }

    private void Partition(int pos, string s, List<StringBuilder> currentParition, List<IList<string>> partitions) {
      if (pos == s.Length) {
        foreach (var item in currentParition) {
          if (!isPalindrome(item.ToString())) {
            return;
          }
        }
        partitions.Add(new List<string>(currentParition.Select(i => i.ToString())));
        return;
      }
      currentParition.Add(new StringBuilder(s[pos].ToString())); ;
      Partition(pos + 1, s, currentParition, partitions);
      currentParition.RemoveAt(currentParition.Count - 1);
      if (currentParition.Count > 0) {
        currentParition[currentParition.Count - 1].Append(s[pos].ToString());
        Partition(pos + 1, s, currentParition, partitions);
        currentParition[currentParition.Count - 1].Remove(currentParition[currentParition.Count - 1].Length - 1, 1);
      }
    }

    private bool isPalindrome(string s) {
      if (map.ContainsKey(s)) {
        return map[s];
      }
      int iStart = 0, iEnd = s.Length - 1;
      bool flag = true;
      while (iStart <= iEnd && flag) {
        if (s[iStart] != s[iEnd]) {
          flag = false;
        }
        ++iStart;
        --iEnd;
      }
      return map[s] = flag;
    }
  }


  #endregion
}
