using System;

namespace HammingDistance {
  class Program {
    static void Main(string[] args) {
      var p = new Program();
      Console.WriteLine(p.HammingDistance(1, 4) == 2);
    }

    public int HammingDistance(int x, int y) {
      int result = 0;
      for (int i = 0; i < 32; ++i, x >>= 1, y >>= 1) {
        if ((x & 1) != (y & 1)) {
          ++result;
        }
      }
      return result;
    }
  }
}
