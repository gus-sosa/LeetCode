using System;
using System.Collections.Generic;
using System.Linq;

namespace WildcardMatching {
  class Program {
    static void Main(string[] args) {
      var s = new Solution();
      Console.WriteLine(s.IsMatch("aa", "a") == false);
      Console.WriteLine(s.IsMatch("aa", "*") == true);
      Console.WriteLine(s.IsMatch("cb", "?a") == false);
      Console.WriteLine(s.IsMatch("adceb", "*a*b") == true);
      Console.WriteLine(s.IsMatch("acdcb", "a*c?b") == false);
      Console.WriteLine(s.IsMatch("ho", "ho**") == true);
    }
  }

  #region MyRegion


  public class Solution {
    Dictionary<int, Dictionary<int, bool>> map;
    public bool IsMatch(string s, string p) {
      map = new Dictionary<int, Dictionary<int, bool>>();
      if (string.IsNullOrEmpty(p)) {
        return string.IsNullOrEmpty(s);
      }

      if (string.IsNullOrEmpty(s)) {
        return p.All(i => i == '*');
      }

      return IsMatch(s, p, 0, 0);
    }

    private bool IsMatch(string s, string p, int posS, int posP) {
      if (map.ContainsKey(posS) && map[posS].ContainsKey(posP)) {
        return map[posS][posP];
      }

      if (!map.ContainsKey(posS)) {
        map[posS] = new Dictionary<int, bool>();
      }

      if (posS == s.Length) {
        return map[posS][posP] = (posP == p.Length || p.Where((_, i) => i >= posP).All(i => i == '*'));
      }

      if (posP == p.Length) {
        return map[posS][posP] = false;
      }

      if (p[posP] == '?') {
        return map[posS][posP] = IsMatch(s, p, posS + 1, posP + 1);
      }

      if (p[posP] == '*') {
        return map[posS][posP] = IsMatch(s, p, posS + 1, posP) || IsMatch(s, p, posS, posP + 1);
      }

      return map[posS][posP] = s[posS] == p[posP] && IsMatch(s, p, posS + 1, posP + 1);
    }
  }


  #endregion
}
