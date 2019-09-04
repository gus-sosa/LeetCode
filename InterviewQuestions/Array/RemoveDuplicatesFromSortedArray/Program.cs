using System;
using System.Diagnostics;
using System.Linq;

namespace RemoveDuplicatesFromSortedArray {
  class Program {
    public int RemoveDuplicates(int[] nums) {
      int newArrayHead = 0, arrayPointer = 0;
      while (arrayPointer < nums.Length) {
        if (nums[newArrayHead] == nums[arrayPointer]) {
          ++arrayPointer;
        } else {
          nums[++newArrayHead] = nums[arrayPointer];
        }
      }
      return nums.Length == 0 ? 0 : newArrayHead + 1;
    }

    static void Main(string[] args) {
      //Debugger.Launch();
      int[] input = getInput();
      (int newArraySize, int[] newArray) = getOutput();
      int sizeResult = new Program().RemoveDuplicates(input);
      if (newArraySize != sizeResult) {
        Console.WriteLine("ERROR: DIFFERENT ARRAY SIZE");
        Console.WriteLine($"New array size={newArraySize} ---  result={sizeResult}");
      }
      if (!SameArrays(newArray, input)) {
        Console.WriteLine("ERROR: DIFFERENT ARRAY ELEMENTS");
      }
      Console.WriteLine("OK");
    }

    private static bool SameArrays(int[] newArray, int[] input) {
      bool flag = true;
      for (int i = 0; i < newArray.Length && flag; i++) {
        flag = newArray[i] == input[i];
      }
      return flag;
    }

    private static (int, int[]) getOutput() => (int.Parse(Console.ReadLine()), getArray());

    private static int[] getArray() => Console.ReadLine().Split().Select(int.Parse).ToArray();

    private static int[] getInput() => getArray();
  }
}
