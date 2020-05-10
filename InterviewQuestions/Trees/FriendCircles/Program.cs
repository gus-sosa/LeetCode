using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace FriendCircles {
  class Program {
    static void Main(string[] args) {
      var s = new Solution();
      var arr = new int[][] {
        new int[]{ 1,1,0},
        new int[]{ 1,1,0},
        new int[]{ 0,0,1}
      };
      Console.WriteLine(s.FindCircleNum(arr) == 2);
    }
  }

  #region MyRegion


  public class Solution {
    public int FindCircleNum(int[][] M) {
      int numFriends = M.Length, groups = 0;
      bool[] marked = new bool[numFriends];
      for (int i = 0; i < numFriends; ++i) {
        if (!marked[i]) {
          ++groups;
          bfs(M, marked, i, numFriends);
        }
      }
      return groups;
    }

    private void bfs(int[][] m, bool[] marked, int index, int numFriends) {
      var q = new Queue<int>();
      marked[index] = true;
      q.Enqueue(index);
      while (q.Count > 0) {
        index = q.Dequeue();
        for (int i = 0; i < numFriends; ++i) {
          if (i != index && m[index][i] == 1 && !marked[i]) {
            marked[i] = true;
            q.Enqueue(i);
          }
        }
      }
    }
  }


  #endregion
}
