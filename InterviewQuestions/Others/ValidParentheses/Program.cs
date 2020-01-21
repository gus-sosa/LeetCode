using System;
using System.Collections;
using System.Collections.Generic;

namespace ValidParentheses {
  class Program {
    static void Main(string[] args) {
      var p = new Program();
      Console.WriteLine(p.IsValid("(]") == false);
    }

    public bool IsValid(string s) {
      var stack = new Stack<char>();
      char top;
      foreach (char c in s) {
        if (c == '(' || c == '{' || c == '[') {
          stack.Push(c);
        } else {
          if (stack.Count > 0) {
            top = stack.Pop();
            if ((c == ')' && top != '(') || (c == '}' && top != '{') || (c == ']' && top != '[')) {
              return false;
            }
          } else {
            return false;
          }
        }
      }
      return stack.Count == 0;
    }
  }
}
