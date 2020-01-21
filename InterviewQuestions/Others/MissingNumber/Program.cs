using System;
using System.Linq;

namespace MissingNumber {
  class Program {
    static void Main(string[] args) {
      Console.WriteLine("Hello World!");
    }

    public int MissingNumber(int[] nums) {
      int sum = nums.Length * (nums.Length + 1) / 2;
      return sum - nums.Sum();
    }
  }
}
