using System;
using System.Collections.Generic;

namespace CountAndSay {
  class Program {
    public string CountAndSay(int n) {
      string num = "1";
      for (int i = 1; i < n; ++i) {
        num = CountAndSay(num);
      }
      return num;
    }

    private string CountAndSay(string num) {
      var groups = new List<Tuple<char, int>>();
      int count = 1;
      for (int i = 1; i <= num.Length; ++i) {
        if (i == num.Length) {
          groups.Add(Tuple.Create(num[i - 1], count));
        } else if (num[i] == num[i - 1]) {
          ++count;
        } else {
          groups.Add(Tuple.Create(num[i - 1], count));
          count = 1;
        }
      }
      string newNum = "";
      foreach (var group in groups) {
        newNum += group.Item2.ToString() + group.Item1;
      }
      return newNum;
    }

    static void Main(string[] args) {
      var p = new Program();
      Console.WriteLine("===========testing countandsay integer=========");
      Console.WriteLine(p.CountAndSay(1) == "1");
      Console.WriteLine(p.CountAndSay(2) == "11");
      Console.WriteLine(p.CountAndSay(3) == "21");
      Console.WriteLine(p.CountAndSay(4) == "1211");
      Console.WriteLine(p.CountAndSay(5) == "111221");
      Console.WriteLine("===========testing countandsay string=========");
      Console.WriteLine(p.CountAndSay("1") == "11");
      Console.WriteLine(p.CountAndSay("11") == "21");
      Console.WriteLine(p.CountAndSay("21") == "1211");
      Console.WriteLine(p.CountAndSay("1211") == "111221");
    }
  }
}
