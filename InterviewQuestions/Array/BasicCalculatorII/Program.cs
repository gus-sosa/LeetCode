using System;
using System.Collections;
using System.Collections.Generic;

namespace BasicCalculatorII {
  class Program {
    static void Main(string[] args) {
      var s = new Solution();
      Console.WriteLine(s.Calculate("") == 0);
      Console.WriteLine(s.Calculate("42") == 42);
      Console.WriteLine(s.Calculate("3/2") == 1);
      Console.WriteLine(s.Calculate("3+5 / 2") == 5);
      Console.WriteLine(s.Calculate("3+2*2") == 7);
      Console.WriteLine(s.Calculate("1-1+1") == 1);
      Console.WriteLine(s.Calculate("1-1-1") == -1);
      Console.WriteLine(s.Calculate("2-3+4") == 3);
      Console.WriteLine(s.Calculate("1+2*5/3+6/4*2") == 6);
    }
  }

  #region MyRegion


  public class Solution {
    static Stack<int> operands = new Stack<int>();
    static Stack<char> operators = new Stack<char>();
    static int o1, o2, o3;
    static char opTemp, currentOper;
    const char FLAG = 'F';

    public int Calculate(string s) {
      if (string.IsNullOrEmpty(s)) {
        return 0;
      }
      parse(s);
      compute();
      return operands.Pop();
    }

    private void compute() {
      while (operators.Count > 0) {
        currentOper = operators.Pop();
        if (currentOper == FLAG) {
          o1 = operands.Pop();
          o2 = operands.Pop();
          operands.Push(o1);
          operands.Push(o2);
        } else if (operators.Count > 0 && hasMorePriority(operators.Peek(), currentOper)) {
          o1 = operands.Pop();
          o2 = operands.Pop();
          o3 = operands.Pop();
          operands.Push(o1);
          operands.Push(o3);
          operands.Push(o2);
          opTemp = operators.Pop();
          operators.Push(currentOper);
          operators.Push(FLAG);
          operators.Push(opTemp);
        } else {
          operands.Push(computeOperation(operands.Pop(), operands.Pop(), currentOper));
        }
      }
    }

    private int computeOperation(int v1, int v2, char currentOper) {
      switch (currentOper) {
        case '+':
          return v1 + v2;
        case '-':
          return v1 - v2;
        case '*':
          return v1 * v2;
        case '/':
          return v1 / v2;
        default:
          throw new Exception();
      }
    }

    private bool hasMorePriority(char oper1, char oper2) {
      if (oper2 == '+' || oper2 == '-') {
        return oper1 == '*' || oper1 == '/';
      }
      return false;
    }

    private static void parse(string s) {
      for (int i = 0; i < s.Length; ++i) {
        if (s[i] != ' ') {
          if (char.IsDigit(s[i])) {
            if (i == 0 || !char.IsDigit(s[i - 1])) {
              operands.Push(0);
            }
            operands.Push(operands.Pop() * 10 + (s[i] - '0'));
          } else {
            operators.Push(s[i]);
          }
        }
      }
      reverseStack(operators);
      reverseStack(operands);
    }

    private static void reverseStack<T>(Stack<T> stack) {
      var q = new Queue<T>();
      while (stack.Count > 0) {
        q.Enqueue(stack.Pop());
      }
      while (q.Count > 0) {
        stack.Push(q.Dequeue());
      }
    }
  }


  #endregion
}
