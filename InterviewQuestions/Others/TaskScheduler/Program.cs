using System;
using System.Collections.Generic;
using System.Linq;

namespace TaskScheduler {
  class Program {
    static void Main(string[] args) {
      var s = new Solution();
      Console.WriteLine(s.LeastInterval(new char[] { 'A', 'A', 'A', 'B', 'B', 'B' }, 0) == 6);
    }

    #region MyRegion


    public class Solution {
      public int LeastInterval(char[] tasks, int n) {
        int[] map = new int[26];
        foreach (var c in tasks) {
          map[c - 'A']++;
        }
        Array.Sort(map);
        int maxVal = map[25] - 1, idleSlots = maxVal * n;
        for (int i = 24; i >= 0 && map[i] > 0; i--) {
          idleSlots -= Math.Min(map[i], maxVal);
        }
        return tasks.Length + Math.Max(idleSlots, 0);
      }
    }


    #endregion
  }
}
