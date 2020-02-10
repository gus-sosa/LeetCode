using System;
using System.Collections.Generic;

namespace TopKFrequentElements {
  static class MyClass {
    public static void PrintList<T>(this IList<T> list) {
      foreach (var item in list) {
        Console.WriteLine($"{item}    ");
      }
      Console.WriteLine();
    }
  }

  class Program {
    static void Main(string[] args) {
      var s = new Solution();
      var r = s.TopKFrequent(new int[] { 1, 1, 1, 2, 2, 3 }, 2);
      r.PrintList();
    }

    #region MyRegion


    public class Solution {
      public IList<int> TopKFrequent(int[] nums, int k) {
        var frequencies = new Dictionary<int, int>();
        foreach (var item in nums) {
          if (frequencies.ContainsKey(item)) {
            ++frequencies[item];
          } else {
            frequencies[item] = 1;
          }
        }

        var mostFrequent = new SortedDictionary<int, LinkedList<int>>();
        foreach (KeyValuePair<int, int> item in frequencies) {
          if (!mostFrequent.ContainsKey(item.Value)) {
            mostFrequent.Add(item.Value, new LinkedList<int>());
          }
          mostFrequent[item.Value].AddLast(item.Key);
        }
        var result = new LinkedList<int>(); ;
        foreach (var item in mostFrequent) {
          foreach (var num in mostFrequent[item.Key]) {
            if (result.Count >= k) {
              result.RemoveLast();
            }
            result.AddFirst(num);
          }
        }
        return new List<int>(result);
      }
    }

    #endregion

  }
}
