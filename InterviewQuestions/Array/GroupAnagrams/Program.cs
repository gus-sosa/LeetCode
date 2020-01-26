using System;
using System.Collections.Generic;

namespace GroupAnagrams {
  class Program {
    static void Main(string[] args) {
      Console.WriteLine("Hello World!");
    }

    public IList<IList<string>> GroupAnagrams(string[] strs) {
      var dict = new Dictionary<string, List<string>>();
      foreach (var str in strs) {
        var strArr = str.ToCharArray();
        Array.Sort(strArr);
        string key = new string(strArr);
        if (!dict.ContainsKey(key)) {
          dict[key] = new List<string>();
        }
        dict[key].Add(str);
      }
      var result = new List<IList<string>>();
      foreach (string key in dict.Keys) {
        result.Add(dict[key]);
      }
      return result;
    }
  }
}
