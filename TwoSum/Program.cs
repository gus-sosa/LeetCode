using System;
using System.Collections.Generic;

namespace TwoSum
{
    public class Solution
    {
        class PosInfo
        {
            public int Num { get; set; }
            public int Pos { get; set; }
        }

        private class SortArray : IComparer<PosInfo>
        {
            public int Compare(PosInfo x, PosInfo y) => x.Num.CompareTo(y.Num);
        }

        private PosInfo[] buildArray(int[] nums)
        {
            PosInfo[] arr = new PosInfo[nums.Length];
            for (int i = 0; i < nums.Length; i++)
                arr[i] = new PosInfo() { Num = nums[i], Pos = i };
            return arr;
        }

        public int[] TwoSum(int[] nums, int target)
        {
            PosInfo[] arr = buildArray(nums);
            Array.Sort(arr, new SortArray());
            int iStart = 0, iEnd = nums.Length - 1;
            while (iStart < iEnd)
            {
                var currentSum = arr[iStart].Num + arr[iEnd].Num;
                if (currentSum == target)
                    break;

                if (currentSum < target) iStart++;
                else iEnd--;
            }
            return new[] { arr[iStart].Pos, arr[iEnd].Pos };
        }
    }
}
