using System;

namespace PowerOfThree {
  class Program {
    static void Main(string[] args) {
      var p = new Program();
      Console.WriteLine(p.IsPowerOfThree(27) == true);
      Console.WriteLine(p.IsPowerOfThree(0) == false);
      Console.WriteLine(p.IsPowerOfThree(9) == true);
      Console.WriteLine(p.IsPowerOfThree(45) == false);
    }

    //public bool IsPowerOfThree(int n) {
    //  while (n > 1 && n % 3 == 0) {
    //    n /= 3;
    //  }
    //  return n == 1;
    //}

    public bool IsPowerOfThree(int n) {
      return n > 0 && 1162261467 % n == 0;
    }

    //public bool IsPowerOfThree(int n) {
    //  int tmp;
    //  return n == 1 || (n % 3 == 0 && (n % 10 == 1 || n % 10 == 3 || n % 10 == 9 || n % 10 == 7) && int.TryParse(Math.Log(n, 3).ToString(), out tmp));
    //}
  }
}
