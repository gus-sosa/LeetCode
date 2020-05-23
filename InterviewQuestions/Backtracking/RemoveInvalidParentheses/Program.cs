using System.Text;
using System.Linq;
using System.Collections.Generic;
using System.Collections;
using System;

namespace RemoveInvalidParentheses {
  class Program {
    static void Main(string[] args) {
      var s = new Solution();
      Print(s.RemoveInvalidParentheses("()())()"));
      Print(s.RemoveInvalidParentheses("(a)())()"));
      Print(s.RemoveInvalidParentheses(")("));
      Print(s.RemoveInvalidParentheses(")(f"));
      Print(s.RemoveInvalidParentheses(")()("));
    }

    private static void Print(IList<string> lists) {
      Console.WriteLine("=====solution=======");
      foreach (var item in lists) {
        Console.WriteLine(string.IsNullOrEmpty(item) ? "empty" : item);
      }
    }
  }

  #region solution

  public class Solution {
    public string s { get; set; }
    public HashSet<string> Retval { get; set; }
    public int maxLengthString { get; set; }
    public Stack<int> stack { get; set; }
    public bool[] marked { get; set; }
    public IList<string> RemoveInvalidParentheses(string s) {
      this.s = s;
      Retval = new HashSet<string>();
      stack = new Stack<int>();
      marked = new bool[s.Length];
      maxLengthString = 0;
      removeRecur(0);
      if (Retval.Count == 0) {
        Retval.Add(removeAllParentheses());
      }
      return Retval.ToList();
    }

    private string removeAllParentheses() {
      var sb = new StringBuilder();
      foreach (var item in s) {
        if (char.IsLetter(item)) {
          sb.Append(item);
        }
      }
      return sb.ToString();
    }

    public void removeRecur(int pos) {
      if (pos == s.Length) {
        if (stack.Count == 0) {
          int newStringLength = marked.Sum(i => i ? 1 : 0);
          if (newStringLength >= maxLengthString) {
            string cad = buildString();
            if (newStringLength > maxLengthString) {
              maxLengthString = newStringLength;
              Retval.Clear();
            }
            Retval.Add(cad);
          }
        }
        return;
      }

      if (s[pos] != '(' && s[pos] != ')') {
        marked[pos] = true;
        removeRecur(pos + 1);
        marked[pos] = false;
        return;
      }

      //take parentheses
      if (s[pos] == '(') {
        stack.Push(pos);
        marked[pos] = true;
        removeRecur(pos + 1);
        marked[pos] = false;
        stack.Pop();
      } else if (stack.Count != 0) {
        stack.Pop();
        marked[pos] = true;
        removeRecur(pos + 1);
        marked[pos] = false;
        stack.Push('(');
      }

      //skip parentheses
      removeRecur(pos + 1);
    }

    public string buildString() {
      var sb = new StringBuilder();
      for (int i = 0; i < marked.Length; ++i) {
        if (marked[i]) {
          sb.Append(s[i]);
        }
      }
      return sb.ToString();
    }
  }



  #endregion
}
