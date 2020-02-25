using System;

namespace JumpGame {
  class Program {
    static void Main(string[] args) {
      var s = new Solution();
      Console.WriteLine(s.CanJump(new int[] { 2, 3, 1, 1, 4 }) == true);
      Console.WriteLine(s.CanJump(new int[] { 3, 2, 1, 0, 4 }) == false);
    }

    #region MyRegion


    public class Solution {
      public bool CanJump(int[] nums) {
        for (int i = nums.Length - 1; i >= 0; --i) {
          CanJump(nums, i);
        }

        return nums[0] == 0;
      }

      private void CanJump(int[] nums, int pos) {
        if (nums.Length - pos > 0) {
          if (pos == nums.Length - 1) {
            nums[pos] = 0;
          } else {
            nums[pos] = Math.Min(nums[pos], nums.Length - pos - 1);
            bool flag = false;
            while (nums[pos] > 0 && !flag) {
              if (nums[pos + nums[pos]] == 0) {
                flag = true;
                nums[pos] = 0;
              } else if (nums[pos + nums[pos]] == -1) {
                --nums[pos];
              } else {
                CanJump(nums, pos + nums[pos]);
              }
            }
            nums[pos] = flag ? 0 : -1;
          }
        }
      }
    }


    #endregion
  }
}
