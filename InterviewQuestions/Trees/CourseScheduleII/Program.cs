using System;
using System.Collections.Generic;

namespace CourseScheduleII {
  class Program {
    static void Main(string[] args) {
      var s = new Solution();
      int[][] arr = new int[][] {
        new int[]{ 1,0}
      };

      Print(s.FindOrder(2, arr));

      arr = new int[][] {
        new int[]{ 1,0},
        new int[]{ 0,1},
      };


      Print(s.FindOrder(2, arr));
    }

    private static void Print(int[] v) {
      Console.WriteLine("======");
      foreach (var item in v) {
        Console.WriteLine(item);
      }
    }
  }

  #region MyRegion


  public class Solution {
    public int[] FindOrder(int numCourses, int[][] prerequisites) {
      var graph = buildGraph(numCourses, prerequisites);
      Stack<int> topologicalOrder = khansAlgorithm(graph);
      var l = new List<int>();
      while (topologicalOrder.Count > 0) {
        l.Insert(0, topologicalOrder.Pop());
      }
      return l.ToArray();
    }

    private Stack<int> khansAlgorithm(HashSet<int>[] graph) {
      var outdegreeZeros = new Queue<int>();
      for (int i = 0; i < graph.Length; ++i) {
        if (graph[i].Count == 0) {
          outdegreeZeros.Enqueue(i);
        }
      }
      var topologicalOrder = new Stack<int>();
      while (outdegreeZeros.Count > 0) {
        var current = outdegreeZeros.Dequeue();
        topologicalOrder.Push(current);
        for (int i = 0; i < graph.Length; ++i) {
          if (graph[i].Contains(current)) {
            graph[i].Remove(current);
            if (graph[i].Count == 0) {
              outdegreeZeros.Enqueue(i);
            }
          }
        }
      }
      for (int i = 0; i < graph.Length && topologicalOrder.Count > 0; ++i) {
        if (graph[i].Count > 0) {
          topologicalOrder.Clear();
        }
      }
      return topologicalOrder;
    }

    private HashSet<int>[] buildGraph(int numCourses, int[][] prerequisites) {
      var graph = new HashSet<int>[numCourses];
      for (int i = 0; i < numCourses; ++i) {
        graph[i] = new HashSet<int>();
      }
      for (int i = 0, n1, n2; i < prerequisites.Length; ++i) {
        n1 = prerequisites[i][0];
        n2 = prerequisites[i][1];
        graph[n1].Add(n2);
      }
      return graph;
    }
  }


  #endregion
}
