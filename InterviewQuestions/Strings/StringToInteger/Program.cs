using System;

namespace StringToInteger {
  class Program {
    public int MyAtoi(string str) {
      str = str.TrimStart();
      if (string.IsNullOrEmpty(str) || !(char.IsDigit(str[0]) || str[0] == '+' || str[0] == '-')) {
        return 0;
      }
      int mul = str[0] == '-' ? -1 : 1;
      int index = str[0] == '+' || str[0] == '-' ? 1 : 0;
      int integer = 0;
      while (index < str.Length && char.IsDigit(str[index])) {
        try {
          checked {
            integer = integer * 10 + (str[index] - '0');
          }
        } catch (Exception) {
          return mul > 0 ? int.MaxValue : int.MinValue;
        }
        ++index;
      }
      return integer * mul;
    }

    static void Main(string[] args) {
      var p = new Program();
      Console.WriteLine(p.MyAtoi("42") == 42);
      Console.WriteLine(p.MyAtoi("      -42") == -42);
      Console.WriteLine(p.MyAtoi("4193   with words") == 4193);
      Console.WriteLine(p.MyAtoi("words and 987") == 0);
      Console.WriteLine(p.MyAtoi("-91283472332") == -2147483648);
    }
  }
}
