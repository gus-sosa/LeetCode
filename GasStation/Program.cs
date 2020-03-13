using System;
using System.Collections.Generic;

namespace GasStation {
  class Program {
    static void Main(string[] args) {
      var s = new Solution();
      Console.WriteLine(s.CanCompleteCircuit(new int[] { 1, 2, 3, 4, 5 }, new int[] { 3, 4, 5, 1, 2 }));
      Console.WriteLine(s.CanCompleteCircuit(new int[] { 2, 3, 4 }, new int[] { 3, 4, 3 }));
      Console.WriteLine(s.CanCompleteCircuit(new int[] { 1, 2, 1 }, new int[] { 2, 1, 1 }));
    }

    #region MyRegion

    public class Solution {
      public int CanCompleteCircuit(int[] gas, int[] cost) {
        int finalCost = 0;
        var segments = new LinkedList<Tuple<int, int>>();
        for (int i = 0, segmentCost; i < gas.Length; ++i) {
          segmentCost = gas[i] - cost[i];
          finalCost += segmentCost;
          segments.AddLast(new LinkedListNode<Tuple<int, int>>(Tuple.Create(i, segmentCost)));
        }
        if (finalCost < 0) {
          return -1;
        }
        for (int i = 0, sumSegmentsCost = 0; i < gas.Length; ++i) {
          var current = segments.First;
          sumSegmentsCost = 0;
          while (sumSegmentsCost >= 0 && i < gas.Length) {
            sumSegmentsCost += current.Value.Item2;
            current = current.Next;
            ++i;
          }
          while (sumSegmentsCost < 0 && i-- > 0) {
            var head = segments.First;
            segments.RemoveFirst();
            segments.AddLast(head);
          }
        }
        return segments.First.Value.Item1;
      }
    }


    #endregion
  }
}
