using System;

namespace ReverseBits {
  class Program {
    static void Main(string[] args) {
      Console.WriteLine("Hello World!");
    }

    public uint reverseBits(uint n) {
      uint result = 0;
      for (int i = 0; i < 32; ++i, n >>= 1) {
        result <<= 1;
        result ^= (n & 1);
      }
      return result;
    }
  }
}
