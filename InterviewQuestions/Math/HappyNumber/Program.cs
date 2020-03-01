using System;
using System.Collections.Generic;
using System.Linq;

namespace HappyNumber {
  class Program {
    static void Main(string[] args) {
      var s = new Solution();
      Console.WriteLine(s.IsHappy(19) == true);
      Console.WriteLine(s.IsHappy(3));
    }


    #region MyRegion

    public class Solution {
      Dictionary<int, bool?> map = new Dictionary<int, bool?>() {
        [1] = true
      };
      public bool IsHappy(int n) {
        int[] arr = GetArrNums(n);
        int num = BuildNum(arr);
        return IsHappy(arr, num);
      }

      private bool IsHappy(int[] arr, int num) {
        if (map.ContainsKey(num)) {
          if (!map[num].HasValue) {
            map[num] = false;
          }
          return map[num].Value;
        }
        map[num] = null;
        int sum = Sum(arr);
        int[] arrSum = GetArrNums(sum);
        map[num] = IsHappy(arrSum, BuildNum(arrSum));
        return map[num].Value;
      }

      private int Sum(int[] arr) {
        int sum = 0;
        foreach (var item in arr) {
          sum += item * item;
        }
        return sum;
      }

      private int BuildNum(int[] arr) {
        int num = 0;
        foreach (var item in arr) {
          num *= 10;
          num += item;
        }
        return num;
      }

      private int[] GetArrNums(int n) {
        var list = new List<int>();
        while (n > 0) {
          list.Add(n % 10);
          n /= 10;
        }
        var result = list.ToArray();
        Array.Sort(result);
        return result;
      }
    }

    #endregion


  }
}
