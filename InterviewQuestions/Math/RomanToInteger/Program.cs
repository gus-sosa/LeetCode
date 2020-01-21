using System;

namespace RomanToInteger {
  class Program {
    static void Main(string[] args) {
      var p = new Program();
      Console.WriteLine(p.RomanToInt("III") == 3);
      Console.WriteLine(p.RomanToInt("IV") == 4);
      Console.WriteLine(p.RomanToInt("IX") == 9);
      Console.WriteLine(p.RomanToInt("LVIII") == 58);
      Console.WriteLine(p.RomanToInt("MCMXCIV") == 1994);
    }

    public int RomanToInt(string s) {
      int result = 0;
      for (int i = 0; i < s.Length; ++i) {
        if (i > 0 && IsLess(s[i - 1], s[i])) {
          result -= GetValue(s[i - 1]);
          result += GetValue(s[i]) - GetValue(s[i - 1]);
        } else {
          result += GetValue(s[i]);
        }
      }
      return result;
    }

    private bool IsLess(char v1, char v2) {
      return GetValue(v1) < GetValue(v2);
    }

    private int GetValue(char v) {
      switch (v) {
        case 'I':
          return 1;
        case 'V':
          return 5;
        case 'X':
          return 10;
        case 'L':
          return 50;
        case 'C':
          return 100;
        case 'D':
          return 500;
        case 'M':
          return 1000;
        default:
          throw new NotImplementedException();
      }
    }
  }
}
