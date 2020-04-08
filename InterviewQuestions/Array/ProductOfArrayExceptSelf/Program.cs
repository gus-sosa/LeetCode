using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductOfArrayExceptSelf {
  class Program {
    static void Main(string[] args) {
      var s = new Solution();
      var arr = new int[] { 1, 2, 3, 4 };
      PrintArr(s.ProductExceptSelf(arr));
    }

    private static void PrintArr(int[] v) {
      foreach (var item in v) {
        Console.Write($"{item}  ");
      }
      Console.WriteLine();
    }

    #region MyRegion


    public class Solution {
      public int[] ProductExceptSelf(int[] nums) {
        var retval = new int[nums.Length];
        retval[0] = nums[0];
        for (int i = 1; i < nums.Length; ++i) {
          retval[i] = retval[i - 1] * nums[i];
        }
        retval[retval.Length - 1] = retval[retval.Length - 2];
        int productRight = nums[nums.Length - 1];
        for (int i = retval.Length - 2; i >= 0; --i) {
          retval[i] = productRight * (i > 0 ? retval[i - 1] : 1);
          productRight *= nums[i];
        }
        return retval;
      }
    }


    #endregion
  }
}
