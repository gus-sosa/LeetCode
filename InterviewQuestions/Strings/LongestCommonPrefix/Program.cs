using System;

namespace LongestCommonPrefix {
  class Program {
    public string LongestCommonPrefix(string[] strs) {
      int index = 0;
      bool flag = true;
      while (flag) {
        foreach (string s in strs) {
          if (index >= s.Length || s[index] != strs[0][index]) {
            flag = false;
            break;
          }
        }
        if (flag) {
          ++index;
        }
      }
      return strs[0].Substring(0, index);
    }

    static void Main(string[] args) {
      var p = new Program();
      Console.WriteLine(p.LongestCommonPrefix(new[] { "flower", "flow", "flight" }) == "fl");
      Console.WriteLine(p.LongestCommonPrefix(new[] { "dog", "racecar", "car" }) == "");
    }
  }
}
