using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingleNumber
{
  class Program
  {
    public int SingleNumber(int[] nums) {
      int result = nums[0];
      for (int i = 1; i < nums.Length; ++i) {
        result = result ^ nums[i];
      }
      return result;
    }

    static void Main(string[] args) {
      var p = new Program();
      Console.WriteLine(p.SingleNumber(new int[] { 2, 2, 1 }) == 1 ? "OK" : "FAIL");
      Console.WriteLine(p.SingleNumber(new int[] { 4, 1, 2, 1, 2 }) == 4 ? "OK" : "FAIL");
    }
  }
}
