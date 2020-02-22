using System;
using System.Collections.Generic;

namespace TaskScheduler {
  class Program {
    static void Main(string[] args) {
      var s = new Solution();
      Console.WriteLine(s.LeastInterval(new char[] { 'A', 'A', 'A', 'B', 'B', 'B' }, 0) == 8);
    }

    #region MyRegion


    public class Solution {
      class ElementInfo {
        public char Element { get; set; }
        public int Count { get; set; }
      }

      public int LeastInterval(char[] tasks, int n) {
        Queue<ElementInfo> taskInfos = BuildTasks(tasks);
        int intervals = 0, i;
        while (taskInfos.Count > 0) {
          for (i = 0; i < n && taskInfos.Count > 0; ++i) {
            ++intervals;
            var current = taskInfos.Dequeue();
            --current.Count;
            if (current.Count > 0) {
              taskInfos.Enqueue(current);
            }
          }
          if (taskInfos.Count > 0) {
            ++intervals;
          }
        }
        return intervals;
      }

      private Queue<ElementInfo> BuildTasks(char[] tasks) {
        var dict = new Dictionary<char, int>();
        foreach (var item in tasks) {
          if (!dict.ContainsKey(item)) {
            dict[item] = 0;
          }
          ++dict[item];
        }
        var result = new Queue<ElementInfo>();
        foreach (var item in dict) {
          result.Enqueue(new ElementInfo() { Count = item.Value, Element = item.Key });
        }
        return result;
      }
    }


    #endregion


  }
}
