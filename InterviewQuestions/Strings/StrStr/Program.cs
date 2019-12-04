using System;
using System.Text.RegularExpressions;

namespace StrStr
{
  class Program
  {
    public int StrStr(string haystack, string needle) {

    }

    static void Main(string[] args) {
      var p = new Program();
      Console.WriteLine(p.StrStr("gus", "") == 0);
      Console.WriteLine(p.StrStr("gus", "g") == 0);
      Console.WriteLine(p.StrStr("gus", "gu") == 0);
      Console.WriteLine(p.StrStr("gus", "us") == 1);
      Console.WriteLine(p.StrStr("gus", "s") == 2);
    }
  }
}
