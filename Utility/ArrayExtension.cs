using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Utility {
  public static class ArrayExtension {
    public static bool SameArrays<T>(this IEnumerable<T> list, IEnumerable<T> otherList) {
      return list.Count() == otherList.Count() && Enumerable.Zip(list, otherList, (i1, i2) => object.Equals(i1, i2)).All(t => t);
    }

    public static string GetStringToPrint<T>(this IEnumerable<T> list) {
      StringBuilder sb = new StringBuilder();
      foreach (var item in list) {
        sb.Append($"{item} ");
      }
      return sb.ToString();
    }
  }
}
