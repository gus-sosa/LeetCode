using System;
using System.Collections.Generic;
using System.Linq;

namespace FirstBadVersion {
  class Program {
    private List<int> badVersions = new List<int>();

    public bool IsBadVersion(int version) => badVersions.Any(v => version >= v);

    public int FirstBadVersion(int n) {
      int i = 1, j = n, m;
      while (i < j) {
        m = i + (j - i) / 2;
        if (IsBadVersion(m)) {
          j = m;
        } else {
          i = m + 1;
        }
      }
      return i;
    }

    public void loadBadVersions(params int[] badVersions) {
      this.badVersions.Clear();
      this.badVersions.AddRange(badVersions);
    }

    static void Main(string[] args) {
      var p = new Program();
      p.loadBadVersions(4);
      Console.WriteLine(p.FirstBadVersion(5));
      p.loadBadVersions(2);
      Console.WriteLine(p.FirstBadVersion(3));
      p.loadBadVersions(1);
      Console.WriteLine(p.FirstBadVersion(1));
      p.loadBadVersions(2);
      Console.WriteLine(p.FirstBadVersion(2));
      p.loadBadVersions(3);
      Console.WriteLine(p.FirstBadVersion(3));
      Console.WriteLine("Hello World!");
    }
  }
}
