using System;
using System.Collections.Generic;

namespace FizzBuzz {
  class Program {
    static void Main(string[] args) {
      Console.WriteLine("Hello World!");
    }

    public IList<string> FizzBuzz(int n) {
      var list = new List<string>();
      bool mul3 = false, mul5 = false;
      string fizz = "Fizz", buzz = "Buzz", result = string.Empty;
      for (int i = 1; i <= n; ++i, result = string.Empty) {
        if (mul3 = (i % 3 == 0)) {
          result += fizz;
        }
        if (mul5 = (i % 5 == 0)) {
          result += buzz;
        }
        if (!mul3 && !mul5) {
          result = i.ToString();
        }
        list.Add(new string(result.ToCharArray()));
      }
      return list;
    }
  }
}
