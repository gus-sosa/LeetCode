using System;

namespace ReverseInteger {
  class Program {
    public int Reverse(int x) {
      int mul = x < 0 ? -1 : 1;
      int reverse = 0;
      x *= mul;
      while (x > 0) {
        try {
          checked {
            reverse = reverse * 10 + x % 10;
          }
        } catch (Exception) {
          return 0;
        }
        x /= 10;
      }
      return reverse * mul;
    }

    static void Main(string[] args) {
      var p = new Program();
      Console.WriteLine(p.Reverse(123) == 321);
      Console.WriteLine(p.Reverse(120) == 21);
      Console.WriteLine(p.Reverse(-123) == -321);
      Console.WriteLine(p.Reverse(1534236469) == 0);
    }
  }
}
