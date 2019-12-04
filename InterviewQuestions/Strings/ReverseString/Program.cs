using System;
using System.Linq;

namespace ReverseString {
  class Program {
    public void ReverseString(char[] s) {
      for (int i = 0, j = s.Length - 1; i < j; ++i, --j) {
        char tmp = s[i];
        s[i] = s[j];
        s[j] = tmp;
      }
    }

    static void Main(string[] args) {
      var p = new Program();
      char[] input = new char[] { 'a', 'b', 'c' };
      p.ReverseString(input);
      CompareArray(input, new char[] { 'c', 'b', 'a' });
    }

    private static void CompareArray(char[] v, char[] result) {
      Console.WriteLine(Enumerable.Zip(v, result, (i1, i2) => i1 == i2).All(i => i));
    }
  }
}
