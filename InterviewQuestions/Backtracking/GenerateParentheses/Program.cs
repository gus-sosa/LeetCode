using System;
using System.Collections.Generic;
using System.Text;

namespace GenerateParentheses {
  class Program {
    static void Main(string[] args) {
      var s = new Solution();
      foreach (var item in s.GenerateParenthesis(3)) {
        Console.WriteLine(item);
      }
    }
  }

  #region MyRegion

  class Node {
    public bool OpenParenthesis { get; set; }
    public Node Previous { get; set; }
    public int NumOpenParenthesis { get; set; }
    public int NumCloseParenthesis { get; set; }
    public int NumPairs { get; set; }

    public override string ToString() {
      var current = this;
      var sb = new StringBuilder();
      while (current != null) {
        sb.Insert(0, current.OpenParenthesis ? '(' : ')');
        current = current.Previous;
      }
      return sb.ToString();
    }
  }

  public class Solution {
    public IList<string> GenerateParenthesis(int n) {
      var queue = new Queue<Node>();
      queue.Enqueue(new Node() {
        NumOpenParenthesis = 1,
        OpenParenthesis = true
      });
      var result = new List<string>();
      while (queue.Count > 0) {
        var current = queue.Dequeue();
        if (current.NumPairs == n) {
          result.Add(current.ToString());
        } else if (current.NumCloseParenthesis + current.NumOpenParenthesis + 1 <= 2 * n) {
          if (current.NumOpenParenthesis < n) {
            queue.Enqueue(new Node() {
              NumOpenParenthesis = current.NumOpenParenthesis + 1,
              NumCloseParenthesis = current.NumCloseParenthesis,
              NumPairs = current.NumPairs,
              OpenParenthesis = true,
              Previous = current
            });
          }
          if (current.NumOpenParenthesis >= current.NumCloseParenthesis + 1) {
            queue.Enqueue(new Node() {
              NumCloseParenthesis = current.NumCloseParenthesis + 1,
              NumOpenParenthesis = current.NumOpenParenthesis,
              NumPairs = current.NumPairs + 1,
              Previous = current
            });
          }
        }
      }
      return result;
    }
  }

  #endregion
}
