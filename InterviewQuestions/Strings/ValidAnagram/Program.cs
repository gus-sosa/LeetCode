using System;
using System.Linq;

namespace ValidAnagram {
  class Program {
    public bool IsAnagram(string s, string t) {
      int alphabetLength = 256;
      int[] map = new int[alphabetLength];
      foreach (var letter in s) {
        ++map[letter];
      }
      foreach (var letter in t) {
        --map[letter];
      }
      return map.All(i => i == 0);
    }

    static void Main(string[] args) {
      var p = new Program();
      Console.WriteLine(p.IsAnagram("anagram", "nagaram") == true);
      Console.WriteLine(p.IsAnagram("rat", "car") == false);
    }
  }
}
