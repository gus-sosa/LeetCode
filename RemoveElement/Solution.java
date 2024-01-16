package RemoveElement;

class Solution {
    public int removeElement(int[] nums, int val) {
        int i = 0, j = nums.length - 1;

        if (nums.length == 0) {
            return 0;
        }
        if (nums.length == 1) {
            return nums[0] == val ? 0 : 1;
        }
        if (nums.length == 2) {
            if (nums[0] == val && nums[1] == val) {
                return 0;
            }
            if (nums[0] != val && nums[1] != val) {
                return 2;
            }
            if (nums[0] == val) {
                swap(nums, 0, 1);
            }
            return 1;
        }

        while (i < j) {
            if (nums[i] == val) {
                swap(nums, i, j);
                j--;
            } else {
                i++;
            }
        }

        return nums[j] == val ? j : j + 1;
    }

    private void swap(int[] arr, int i, int j) {
        int tmp = arr[i];
        arr[i] = arr[j];
        arr[j] = tmp;
    }
}