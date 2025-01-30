package MaximumDistanceBetweenAPairOfValues;

class Solution {
    public int maxDistance(int[] nums1, int[] nums2) {
        int bestDistance = 0, index;

        for (int i = 0; i < nums2.length; ++i) {
            index = binarySearch(nums1, nums2[i], 0, Math.min(i, nums1.length - 1));
            if (index == -1) {
                continue;
            }
            bestDistance = Math.max(bestDistance, i - index);
        }

        return bestDistance;
    }

    public int binarySearch(int[] arr, int value, int start, int end) {
        if (start == end) {
            return arr[start] <= value ? start : -1;
        }

        if (start > end) {
            return -1;
        }

        if (end - start <= 3) {
            return findLargestLowerThanValue(arr, value, start, end);
        }

        int mid = (start + end) / 2;
        if (arr[mid] <= value) {
            int index = binarySearch(arr, value, start, mid);
            if (index == -1) {
                return -1;
            }
            return Math.min(index, mid);
        }

        return binarySearch(arr, value, mid, end);
    }

    private int findLargestLowerThanValue(int[] arr, int value, int start, int end) {
        for (int i = start; i <= end; ++i) {
            if (arr[i] <= value) {
                return i;
            }
        }
        return -1;
    }
}
