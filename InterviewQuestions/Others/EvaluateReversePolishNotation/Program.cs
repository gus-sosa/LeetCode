using System;
using System.Collections;
using System.Collections.Generic;

namespace EvaluateReversePolishNotation {
  class Program {
    static void Main(string[] args) {
      Console.WriteLine("Hello World!");
    }

    #region MyRegion


    public class Solution {
      public int EvalRPN(string[] tokens) {
        var stack = new Stack<int>();
        int operand1, operand2;
        foreach (var item in tokens) {
          if (item.Length == 1 && !char.IsDigit(item[0])) {
            operand2 = stack.Pop();
            operand1 = stack.Pop();
            stack.Push(executeOperation(operand1, operand2, item[0]));
          } else {
            stack.Push(int.Parse(item));
          }
        }
        return stack.Pop();
      }

      private int executeOperation(int operand1, int operand2, char operation) {
        switch (operation) {
          case '*':
            return operand1 * operand2;
          default:
          case '/':
            return operand1 / operand2;
          case '+':
            return operand1 + operand2;
          case '-':
            return operand1 - operand2;
            throw new NotImplementedException();
        }
      }
    }


    #endregion
  }
}
