using System;

namespace ContainsDuplicate {
  class Program {
    public bool ContainsDuplicate(int[] nums) {
      Array.Sort(nums);
      bool flag = true;
      for (int i = 1; i < nums.Length && flag; ++i) {
        flag = nums[i] != nums[i - 1];
      }
      return !flag;
    }

    static void Main(string[] args) {
      var p = new Program();
      Console.WriteLine(p.ContainsDuplicate(new int[] { 1, 2, 3, 1 }) == true);
    }
  }
}
