using System;
using System.Linq;

namespace RotateArray {
  class Program {
    public void Rotate(int[] nums, int k) {
      if (nums.Length >= 2) {
        k = k % nums.Length;
        if (k > 0) {
          int initialPos = 0, numSwaps = 0, currentPos, nextNumber, nextPos, currentNum;
          while (numSwaps < nums.Length) {
            currentPos = initialPos;
            currentNum = nums[currentPos];
            do {
              nextPos = (currentPos + k) % nums.Length;
              nextNumber = nums[nextPos];
              nums[nextPos] = currentNum;
              currentNum = nextNumber;
              currentPos = nextPos;
              ++numSwaps;
            } while (currentPos != initialPos);
            ++initialPos;
          }
        }
      }
    }

    static void Main(string[] args) {
      var p = new Program();
      int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();
      p.Rotate(array, int.Parse(Console.ReadLine()));
      int[] expectedResult = Console.ReadLine().Split().Select(int.Parse).ToArray();
      bool same = Enumerable.Zip(array, expectedResult, (o, r) => o == r).All(t => t);
      Console.WriteLine(same ? "OK" : "FAIL");
    }
  }
}
