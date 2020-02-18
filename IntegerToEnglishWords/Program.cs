using System;
using System.Collections.Generic;
using System.Text;

namespace IntegerToEnglishWords {
  class Program {
    static void Main(string[] args) {
      var s = new Solution();
      //Console.WriteLine($"123={s.NumberToWords(123)}");
      //Console.WriteLine($"1={s.NumberToWords(1)}");
      //Console.WriteLine($"11={s.NumberToWords(11)}");
      //Console.WriteLine($"12345={s.NumberToWords(12345)}");
      //Console.WriteLine($"1234567={s.NumberToWords(1234567)}");
      //Console.WriteLine($"1234567891={s.NumberToWords(1234567891)}");
      Console.WriteLine($"1000={s.NumberToWords(1000)}");
    }


    #region MyRegion

    public class Solution {
      Dictionary<int, string> digitTranslation = new Dictionary<int, string>() {
        [0] = "Zero",
        [1] = "One",
        [2] = "Two",
        [3] = "Three",
        [4] = "Four",
        [5] = "Five",
        [6] = "Six",
        [7] = "Seven",
        [8] = "Eight",
        [9] = "Nine"
      };
      Dictionary<int, string> thousandWord = new Dictionary<int, string>() {
        [0] = "",
        [1] = "Thousand",
        [2] = "Million",
        [3] = "Billion"
      };
      public string NumberToWords(int num) {
        if (num == 0) {
          return "Zero";
        }
        Stack<int> thousandGroup = GetThousandGroups(num);
        var sb = new StringBuilder();
        while (thousandGroup.Count > 0) {
          if (thousandGroup.Peek() > 0) {
            sb.Append($"{GetThousandGroupTranslation(thousandGroup.Peek())} ");
            if (thousandGroup.Count > 1) {
              sb.Append($"{thousandWord[thousandGroup.Count - 1]} ");
            }
          }
          thousandGroup.Pop();
        }
        return sb.ToString().Trim().Replace("  "," ");
      }

      private string GetThousandGroupTranslation(int v) {
        if (v < 10) {
          return digitTranslation[v];
        } else if (v < 100) {
          if (v < 20) {
            return TeenTranslation(v);
          } else {
            return TwentiesTranslation(v);
          }
        } else {
          return HundredTranslation(v);
        }
      }

      private string TwentiesTranslation(int v) {
        int twentyDigit = v / 10;
        int decimalDigit = v % 10;
        string twentyTranslation = string.Empty;
        switch (twentyDigit) {
          case 2:
            twentyTranslation = "Twenty";
            break;
          case 3:
            twentyTranslation = "Thirty";
            break;
          case 4:
            twentyTranslation = "Forty";
            break;
          case 5:
            twentyTranslation = "Fifty";
            break;
          case 6:
            twentyTranslation = "Sixty";
            break;
          case 7:
            twentyTranslation = "Seventy";
            break;
          case 8:
            twentyTranslation = "Eighty";
            break;
          case 9:
            twentyTranslation = "Ninety";
            break;
          default:
            return "-2";
        }
        string decimalTranslation = decimalDigit > 0 ? digitTranslation[decimalDigit] : string.Empty;
        return $"{twentyTranslation} {decimalTranslation}";
      }

      private string TeenTranslation(int v) {
        switch (v) {
          case 10:
            return "Ten";
          case 11:
            return "Eleven";
          case 12:
            return "Twelve";
          case 13:
            return "Thirteen";
          case 14:
            return "Fourteen";
          case 15:
            return "Fifteen";
          case 16:
            return "Sixteen";
          case 17:
            return "Seventeen";
          case 18:
            return "Eighteen";
          case 19:
            return "Nineteen";
          default:
            return "-1";
        }
      }

      private string HundredTranslation(int v) {
        int hundreadDigit = v / 100;
        int twentiesDigits = v % 100;
        string twentiesTranslation = twentiesDigits > 0 ? GetThousandGroupTranslation(twentiesDigits) : string.Empty;
        return $"{digitTranslation[hundreadDigit]} Hundred {twentiesTranslation}";
      }

      private Stack<int> GetThousandGroups(int num) {
        var stack = new Stack<int>();
        int thousandGroup = 0, i;
        while (num > 0) {
          thousandGroup = 0;
          for (i = 0; i < 3 && num > 0; ++i) {
            thousandGroup = thousandGroup + Convert.ToInt32(Math.Pow(10, i)) * (num % 10);
            num /= 10;
          }
          stack.Push(thousandGroup);
        }
        return stack;
      }
    }

    #endregion



  }
}
