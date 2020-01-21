using System;
using System.Linq;

namespace CountPrimes {
  class Program {
    static void Main(string[] args) {
      var p = new Program();
      Console.WriteLine(p.CountPrimes(10) == 4);
    }

    public int CountPrimes(int n) {
      bool[] map = new bool[n];
      for (int i = 2; i < map.Length; ++i) {
        map[i] = true;
      }
      for (int i = 2, j, nonPrimePos; i < map.Length; ++i) {
        j = 2;
        nonPrimePos = i * j;
        while (nonPrimePos < n) {
          map[nonPrimePos] = false;
          nonPrimePos = i * ++j;
        }
      }
      return map.Count(i => i);
    }
  }
}
