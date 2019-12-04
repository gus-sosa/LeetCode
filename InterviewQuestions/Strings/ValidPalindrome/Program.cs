using System;

namespace ValidPalindrome {
  class Program {
    public bool IsPalindrome(string s) {
      int i = 0, j = s.Length - 1;
      while (i < j) {
        if (!char.IsDigit(s[i]) && !char.IsLetter(s[i])) {
          ++i; continue;
        }
        if (!char.IsDigit(s[j]) && !char.IsLetter(s[j])) {
          --j; continue;
        }
        if (char.ToLower(s[i]) != char.ToLower(s[j])) {
          return false;
        }
        ++i; --j;
      }
      return true;
    }

    static void Main(string[] args) {
      var p = new Program();
      Console.WriteLine(p.IsPalindrome("race a car") == false);
      Console.WriteLine(p.IsPalindrome("A man, a plan, a canal: Panama") == true);
      Console.WriteLine(p.IsPalindrome("") == true);
      Console.WriteLine(p.IsPalindrome("0P") == false);
    }
  }
}
