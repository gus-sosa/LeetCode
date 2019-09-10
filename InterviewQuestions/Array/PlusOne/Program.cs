using System;
using System.Collections.Generic;
using System.Linq;

namespace PlusOne
{
  class Program
  {
    public int[] PlusOne(int[] digits) {
      int carry = 1;
      var list = new List<int>();

      for (int i = digits.Length - 1; i >= 0; --i) {
        var result = digits[i] + carry;
        var newDigit = result % 10;
        carry = result / 10;
        list.Add(newDigit);
      }

      if (carry != 0) {
        list.Add(carry);
      }

      list.Reverse();
      return list.ToArray();
    }

    static void Main(string[] args) {
      var p = new Program();
      Console.WriteLine(CompareArrays(p.PlusOne(new[] { 1, 2, 3 }), new[] { 1, 2, 4 }) ? "OK" : "FAIL");
      Console.WriteLine(CompareArrays(p.PlusOne(new[] { 4, 3, 2, 1 }), new[] { 4, 3, 2, 2 }) ? "OK" : "FAIL");
      Console.WriteLine(CompareArrays(p.PlusOne(new[] { 9 }), new[] { 1, 0 }) ? "OK" : "FAIL");
    }

    private static bool CompareArrays(int[] arr1, int[] arr2) {
      return Enumerable.Zip(arr1, arr2, (i1, i2) => i1 == i2).All(t => t);
    }
  }
}
