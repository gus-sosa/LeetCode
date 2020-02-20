using System;

namespace ExcelSheetColumnNumber {
  class Program {
    static void Main(string[] args) {
      var s = new Solution();
      Console.WriteLine(s.TitleToNumber("A") == 1);
      Console.WriteLine(s.TitleToNumber("AA") == 27);
      Console.WriteLine(s.TitleToNumber("Z") == 26);
      Console.WriteLine(s.TitleToNumber("C") == 3);
      Console.WriteLine(s.TitleToNumber("AB") == 28);
      Console.WriteLine(s.TitleToNumber("ZY") == 701);
    }

    #region MyRegion


    public class Solution {
      public int TitleToNumber(string s) {
        int result = 0;
        for (int i = s.Length - 1, v; i >= 0; i--) {
          v = s[i] - 'A' + 1;
          result += v * Convert.ToInt32(Math.Pow(26, s.Length - 1 - i));
        }
        return result;
      }
    }


    #endregion
  }
}
