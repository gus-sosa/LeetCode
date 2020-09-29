using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;

namespace MaxPointsOnALine
{
  class Program
  {
    static void Main(string[] args) {
      var s = new Solution();
      Console.WriteLine(s.MaxPoints(new int[][] { new int[] { 1, 1 }, new int[] { 2, 2 }, new int[] { 3, 3 } }) == 3);
      Console.WriteLine(s.MaxPoints(new int[][] { new[] { 1, 1 }, new[] { 3, 2 }, new[] { 5, 3 }, new[] { 4, 1 }, new[] { 2, 3 }, new[] { 1, 4 } }) == 4);
      Console.WriteLine(s.MaxPoints(new int[][] { new[] { 1, 1 }, new[] { 2, 1 }, new[] { 2, 2 }, new[] { 1, 4 }, new[] { 3, 3 } }) == 3);
      Console.WriteLine(s.MaxPoints(new int[][] { new[] { 1, 1 }, new[] { 1, 1 }, new[] { 0, 0 }, new[] { 3, 4 }, new[] { 4, 5 }, new[] { 5, 6 }, new[] { 7, 8 }, new[] { 8, 9 } }) == 5);
      Console.WriteLine(s.MaxPoints(new int[][] { new[] { 0, 0 }, new[] { 1, 1 }, new[] { 1, -1 } }) == 2);
    }
  }

  #region MyRegion


  public class Solution
  {
    public int MaxPoints(int[][] points) {
      if (points.Length < 3) {
        return points.Length;
      }
      int max = 0, slopMax = 0;
      var horizontals = 0;
      var verticals = 0;
      var slopes = new Dictionary<Tuple<int, int>, int>();
      var duplicates = 0;
      for (int i = points.Length - 2; i >= 0; --i) {
        horizontals = 0;
        verticals = 0;
        slopes.Clear();
        duplicates = 1;
        for (int j = i + 1; j < points.Length; ++j) {
          var x = points[i];
          var y = points[j];
          if (x[0] == y[0] && x[1] == y[1]) {
            ++duplicates;
          } else if (x[0] == y[0]) {
            ++verticals;
          } else if (x[1] == y[1]) {
            ++horizontals;
          } else {
            Tuple<int, int> slope = getSlope(x, y);
            if (!slopes.ContainsKey(slope)) {
              slopes.Add(slope, 0);
            }
            slopes[slope] += 1;
          }
        }
        slopMax = slopes.Count == 0 ? 0 : slopes.Max(i => i.Value);
        max = Math.Max(max, duplicates + Math.Max(horizontals, Math.Max(verticals, slopMax)));
      }
      return max;
    }

    private Tuple<int, int> getSlope(int[] p1, int[] p2) {
      int x = p1[0] - p2[0];
      int y = p1[1] - p2[1];
      int gcd = Gcd(x, y);
      return Tuple.Create(x / gcd, y / gcd);
    }

    private int Gcd(int x, int y) {
      if (y == 0) {
        return x;
      }
      return Gcd(y, x % y);
    }
  }


  #endregion
}
