using System;
using System.Collections.Generic;
using System.Linq;

namespace Maximum_Length_of_a_Concatenated_String_with_Unique_Characters {
  class Program {
    static void Main(string[] args) {
      var s = new Solution();
      Console.WriteLine(s.MaxLength(new List<string>() { "un", "iq", "ue" }));
    }

    #region MyRegion


    public class Solution {
      public int MaxLength(IList<string> arr) {
        for (int i = arr.Count - 1; i >= 0; --i) {
          if (!IsUnique(arr[i])) {
            arr.RemoveAt(i);
          }
        }
        var marks = new bool[arr.Count];
        int length = 0;
        MaxLength(arr, arr.Select(x => CreateMask(x)).ToList(), marks, 0, ref length);
        return length;
      }

      private bool IsUnique(string v) {
        var map = new HashSet<char>();
        foreach (var item in v) {
          if (map.Contains(item)) {
            return false;
          }
          map.Add(item);
        }
        return true;
      }

      private int CreateMask(string x) {
        int mask = 0;
        foreach (var item in x) {
          mask |= 1 << (item - 'a');
        }
        return mask;
      }

      private void MaxLength(IList<string> arr, IList<int> masks, bool[] marks, int pos, ref int length) {
        if (marks.Length == pos) {
          int l = 0;
          int unionMask = 0;
          for (int i = 0; i < arr.Count; ++i) {
            if (marks[i]) {
              l += arr[i].Length;
              if ((unionMask & masks[i]) != 0) {
                return;
              }
              unionMask |= masks[i];
            }
          }
          length = Math.Max(l, length);
        } else {
          MaxLength(arr, masks, marks, pos + 1, ref length);
          marks[pos] = true;
          MaxLength(arr, masks, marks, pos + 1, ref length);
          marks[pos] = false;
        }
      }
    }


    #endregion
  }
}
