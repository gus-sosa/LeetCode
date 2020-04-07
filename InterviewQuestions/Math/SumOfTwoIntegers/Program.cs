using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SumOfTwoIntegers {
  class Program {
    static void Main(string[] args) {
    }

    #region MyRegion


    public class Solution {
      public int GetSum(int a, int b) {
        int carry = (a & b) << 1;
        int xor = a ^ b;
        return carry == 0 ? xor : GetSum(xor, carry);
      }
    }


    #endregion
  }
}
