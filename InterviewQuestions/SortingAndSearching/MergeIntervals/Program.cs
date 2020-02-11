using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace MergeIntervals {
  class Program {

    public static IEnumerable<Tuple<int[][], int[][]>> inputOutput() {
      return new Tuple<int[][], int[][]>[] {
        Tuple.Create(new int[][]{
          new int[]{ 1,3},new int[]{ 2,6},new int[]{ 8,10},new int[]{ 15,18}
        },new int[][]{
          new int[]{ 1,6},new int[]{ 8,10},new int[]{ 15,18}
        }),
        Tuple.Create(new int[][]{
          new int[]{ 1,4},new int[]{ 0,1}
        },new int[][]{
          new int[]{ 0,4}
        }),
        Tuple.Create(new int[][]{
          new int[]{ 1,4},new int[]{ 2,3}
        },new int[][]{
          new int[]{ 1,4}
        })
      };
    }

    static void Main(string[] args) {
      var s = new Solution();
      foreach (var pair in inputOutput()) {
        var expectedOutput = pair.Item2;
        var output = s.Merge(pair.Item1);
        Console.WriteLine(AreSame(output, expectedOutput) == true);
      }
    }

    private static bool AreSame(int[][] arr1, int[][] arr2) => arr1.Length == arr2.Length && Enumerable.Zip(arr1, arr2).All(i => i.First[0] == i.Second[0] && i.First[1] == i.Second[1]);


    #region MyRegion


    public class Solution {
      public int[][] Merge(int[][] intervals) {
        Array.Sort(intervals, new IntervalComparer());
        var result = new List<int[]>();
        if (intervals.Length > 0) {
          result.Add(new int[] { intervals[0][0], intervals[0][1] });
          foreach (var item in intervals.Skip(1)) {
            var last = result[result.Count - 1];
            if (last[1] >= item[0]) {
              last[1] = Math.Max(item[1], last[1]);
            } else {
              result.Add(new int[] { item[0], item[1] });
            }
          }
        }
        return result.ToArray();
      }

      private class IntervalComparer : Comparer<int[]> {
        public override int Compare(int[] x, int[] y) {
          return x[0].CompareTo(y[0]);
        }
      }
    }


    #endregion

  }
}
