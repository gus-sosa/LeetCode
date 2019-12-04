using System;
using System.Collections.Generic;
using System.Linq;

namespace FirstUniqueCharacterInAString {
  class Program {
    public int FirstUniqChar(string s) {
      var dict = new Dictionary<char, int>();
      for (int i = 0; i < s.Length; i++) {
        char letter = s[i];
        if (dict.ContainsKey(letter)) {
          dict[letter] = -1;
        } else {
          dict[letter] = i;
        }
      }
      int index = -1;
      foreach (int indexInString in dict.Values.Where(i => i != -1)) {
        index = index == -1 ? indexInString : Math.Min(index, indexInString);
      }
      return index;
    }

    static void Main(string[] args) {
      var p = new Program();
      Console.WriteLine(p.FirstUniqChar("leetcode") == 0);
      Console.WriteLine(p.FirstUniqChar("loveleetcode") == 2);
      Console.WriteLine(p.FirstUniqChar("aaaa") == -1);
    }
  }
}
