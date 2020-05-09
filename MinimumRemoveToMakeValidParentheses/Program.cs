using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualBasic;

namespace MinimumRemoveToMakeValidParentheses {
  class Program {
    static void Main(string[] args) {
      var s = new Solution();
      Console.WriteLine(s.MinRemoveToMakeValid("lee(t(c)o)de)") == "lee(t(c)o)de");
      Console.WriteLine(s.MinRemoveToMakeValid("a)b(c)d") == "ab(c)d");
      Console.WriteLine(s.MinRemoveToMakeValid("))((") == "");
      Console.WriteLine(s.MinRemoveToMakeValid("(a(b(c)d)") == "a(b(c)d)");
    }
  }

  #region MyRegion


  public class Solution {
    const char OPEN = '(';
    const char CLOSE = ')';
    public string MinRemoveToMakeValid(string s) {
      var openParentheses = new Stack<int>();
      var retval = new StringBuilder();
      for (int i = 0; i < s.Length; ++i) {
        if (s[i] == OPEN) {
          openParentheses.Push(retval.Length);
          retval.Append(OPEN);
        } else if (s[i] == CLOSE) {
          if (openParentheses.Count > 0) {
            openParentheses.Pop();
            retval.Append(CLOSE);
          }
        } else {
          retval.Append(s[i]);
        }
      }
      while (openParentheses.Count > 0 && retval.Length > 0) {
        retval = retval.Remove(openParentheses.Pop(), 1);
      }
      return retval.ToString();
    }
  }


  #endregion
}
