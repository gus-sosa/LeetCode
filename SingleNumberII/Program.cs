using System;

namespace SingleNumberII {
  class Program {
    static void Main(string[] args) {
      var s = new Solution();
      var res = s.SingleNumber(new int[] { 2, 1, 2, 3, 4, 1 });
      Console.WriteLine(res[0]);
      Console.WriteLine(res[1]);
    }

    #region MyRegion

    public class Solution {
      public int[] SingleNumber(int[] nums) {
        int allXor = 0, lastBit = 0, firstPartXor = 0, secondPartXor = 0;
        foreach (var item in nums) {
          allXor ^= item;
        }
        lastBit = allXor & -allXor;
        foreach (var item in nums) {
          if ((item & lastBit) == 0) {
            firstPartXor ^= item;
          } else {
            secondPartXor ^= item;
          }
        }
        return new int[] { firstPartXor, secondPartXor };
      }
    }


    #endregion
  }
}
