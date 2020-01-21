using System;
using System.Collections.Generic;
using System.Linq;

namespace PascalTriangle {
  class Program {
    static void Main(string[] args) {
      Console.WriteLine("Hello World!");
    }

    public IList<IList<int>> Generate(int numRows) {
      var list = new List<IList<int>>();
      return GenerateRecur(list, numRows);
    }

    private IList<IList<int>> GenerateRecur(List<IList<int>> list, int numRows) {
      if (numRows == 1) {
        list.Add(new List<int>() { 1 });
      }
      if (numRows == 2) {
        GenerateRecur(list, 1);
        list.Add(new List<int>() { 1, 1 });
      }
      if (numRows > 2) {
        GenerateRecur(list, numRows - 1);
        var previousList = list[list.Count - 1];
        var currentList = new List<int>(numRows);
        currentList.Add(1);
        for (int i = 1; i < numRows - 1; ++i) {
          currentList.Add(previousList[i] + previousList[i - 1]);
        }
        currentList.Add(1);
        list.Add(currentList);
      }
      return list;
    }
  }
}
