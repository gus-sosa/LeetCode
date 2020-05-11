using System;
using System.Collections.Generic;
using System.ComponentModel.Design;

namespace CourseSchedule {
  class Program {
    static void Main(string[] args) {
      var s = new Solution();
      int[][] arr = new int[][] {
        new int[]{ 1,0}
      };

      Console.WriteLine(s.CanFinish(2, arr) == true);

      arr = new int[][] {
        new int[]{ 1,0},
        new int[]{ 0,1},
      };


      Console.WriteLine(s.CanFinish(2, arr) == false);
    }
  }

  #region MyRegion


  public class Solution {
    public bool CanFinish(int numCourses, int[][] prerequisites) {
      var adjList = buildGraph(numCourses, prerequisites);
      bool[] marked = new bool[numCourses + 1];
      return dfs(0, adjList, marked);
    }

    private bool dfs(int node, HashSet<int>[] adjList, bool[] marked) {
      marked[node] = true;
      foreach (var item in adjList[node]) {
        if (marked[item]) {
          return false;
        }
        if (!dfs(item, adjList, marked)) {
          return false;
        }
      }
      marked[node] = false;
      return true;
    }

    private HashSet<int>[] buildGraph(int numCourses, int[][] prerequisites) {
      var graph = new HashSet<int>[numCourses + 1];
      for (int i = 0; i <= numCourses; ++i) {
        graph[i] = new HashSet<int>();
      }
      for (int i = 0, n1, n2; i < prerequisites.Length; ++i) {
        n1 = prerequisites[i][0] + 1;
        n2 = prerequisites[i][1] + 1;
        graph[n1].Add(n2);
      }
      for (int i = 1; i <= numCourses; ++i) {
        graph[0].Add(i);
      }
      return graph;
    }
  }


  #endregion
}
