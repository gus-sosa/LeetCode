public class BinarySearch {
    public static void main(String[] args) {
        Solution s = new Solution();
        System.out.println(s.search(new int[]{1}, 3) == -1);
        System.out.println(s.search(new int[]{1}, 1) == 0);
        System.out.println(s.search(new int[]{1, 2}, 3) == -1);
        System.out.println(s.search(new int[]{1, 2}, 2) == 1);
        System.out.println(s.search(new int[]{1, 2}, 1) == 0);
        System.out.println(s.search(new int[]{1, 2, 3}, 4) == -1);
        System.out.println(s.search(new int[]{1, 2, 3}, 1) == 0);
        System.out.println(s.search(new int[]{1, 2, 3}, 2) == 1);
        System.out.println(s.search(new int[]{1, 2, 3}, 3) == 2);
        System.out.println(s.search(new int[]{1, 2, 3, 4}, 5) == -1);
        System.out.println(s.search(new int[]{1, 2, 3, 4}, 1) == 0);
        System.out.println(s.search(new int[]{1, 2, 3, 4}, 2) == 1);
        System.out.println(s.search(new int[]{1, 2, 3, 4}, 3) == 2);
        System.out.println(s.search(new int[]{1, 2, 3, 4}, 4) == 3);
    }
}

class Solution {
    public int search(int[] nums, int target) {
        int middle = 0;
        int start = 0;
        int end = nums.length - 1;

        do {
            middle = (start + end) / 2;
            if (nums[middle] == target) {
                return middle;
            }
            if (nums[middle] < target) {
                start = middle + 1;
            } else {
                end = middle - 1;
            }
        } while (start <= end);

        return -1;
    }
}
