using System;
using System.Collections.Generic;

namespace FlattenNestedListIterator {
  class Program {
    static void Main(string[] args) {
      Console.WriteLine("Hello World!");
    }
  }

  /**
* // This is the interface that allows for creating nested lists.
* // You should not implement it, or speculate about its implementation*/
  public interface NestedInteger {

    // @return true if this NestedInteger holds a single integer, rather than a nested list.
    bool IsInteger();

    // @return the single integer that this NestedInteger holds, if it holds a single integer
    // Return null if this NestedInteger holds a nested list
    int GetInteger();

    // @return the nested list that this NestedInteger holds, if it holds a nested list
    // Return null if this NestedInteger holds a single integer
    IList<NestedInteger> GetList();
  }



  #region MyRegion



  public class NestedIterator {

    private Stack<NestedInteger> stack = new Stack<NestedInteger>();

    public NestedIterator(IList<NestedInteger> nestedList) {
      insertInStack(nestedList);
    }

    private void insertInStack(IList<NestedInteger> nestedList) {
      for (int i = nestedList.Count - 1; i >= 0; --i) {
        stack.Push(nestedList[i]);
      }
    }

    public bool HasNext() {
      while (stack.Count > 0 && !stack.Peek().IsInteger()) {
        insertInStack(stack.Pop().GetList());
      }

      return stack.Count > 0;
    }

    public int Next() {
      if (stack.Count == 0) {
        throw new ApplicationException();
      }
      return stack.Pop().GetInteger();
    }
  }

  /**
   * Your NestedIterator will be called like this:
   * NestedIterator i = new NestedIterator(nestedList);
   * while (i.HasNext()) v[f()] = i.Next();
   */


  #endregion
}
