using System;

namespace HouseRobber {
  class Program {
    static void Main(string[] args) {
      var p = new Program();
      Console.WriteLine(p.Rob(new int[] { 1, 2, 3, 1 }) == 4);
      Console.WriteLine(p.Rob(new int[] { 2, 7, 9, 3, 1 }) == 12);
    }

    public int Rob(int[] nums) {
      throw new NotImplementedException();
    }
  }
}
