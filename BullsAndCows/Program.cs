using System;
using System.Collections.Generic;
using System.Linq;

namespace BullsAndCows {
  class Program {
    static void Main(string[] args) {
      var s = new Solution();
      Console.WriteLine(s.GetHint("1807", "7810") == "1A3B");
      Console.WriteLine(s.GetHint("1123", "0111") == "1A1B");
      Console.WriteLine(s.GetHint("1", "0") == "0A0B");
      Console.WriteLine(s.GetHint("1", "1") == "1A0B");
    }
  }

  #region MyRegion

  public class Solution {
    public string GetHint(string secret, string guess) {
      HashSet<int>[] map = buildMap(secret);
      bool[] bullMarks = secret.Select((i, pos) => i == guess[pos]).ToArray();
      var cowMarks = new Dictionary<int, HashSet<int>>();
      for (int pos = 0, num; pos < guess.Length; ++pos) {
        if (!bullMarks[pos]) {
          num = guess[pos] - '0';
          foreach (var index in map[num]) {
            if (!bullMarks[index] && !contains(cowMarks, num, index)) {
              add(cowMarks, num, index);
              break;
            }
          }
        }
      }
      return $"{bullMarks.Count(i => i)}A{cowMarks.Sum(i => i.Value.Count)}B";
    }

    private void add(Dictionary<int, HashSet<int>> cowMarks, int num, int index) {
      if (!cowMarks.ContainsKey(num)) {
        cowMarks.Add(num, new HashSet<int>());
      }
      cowMarks[num].Add(index);
    }

    private bool contains(Dictionary<int, HashSet<int>> cowMarks, int num, int index) {
      return cowMarks.ContainsKey(num) && cowMarks[num].Contains(index);
    }

    private static HashSet<int>[] buildMap(string secret) {
      var map = Enumerable.Range(0, 10).Select(i => new HashSet<int>()).ToArray();
      for (int pos = 0, num; pos < secret.Length; ++pos) {
        num = secret[pos] - '0';
        map[num].Add(pos);
      }
      return map;
    }
  }

  #endregion
}
