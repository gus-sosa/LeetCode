using System;

namespace NumberOf1Bits {
  class Program {
    static void Main(string[] args) {
      Console.WriteLine("Hello World!");
    }

    public int HammingWeight(uint n) {
      int result = 0;
      for (int i = 0; i < 32; ++i) {
        if ((n & 1) == 1) {
          ++result;
        }
        n >>= 1;
      }
      return result;
    }
  }
}
