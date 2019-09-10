using System.Collections.Generic;
using System.Linq;

namespace Utility
{
  public static class ArrayExtension
  {
    public static bool SameArrays<T>(this IEnumerable<T> list, IEnumerable<T> otherList) {
      return Enumerable.Zip(list, otherList, (i1, i2) => object.Equals(i1, i2)).All(t => t);
    }
  }
}
