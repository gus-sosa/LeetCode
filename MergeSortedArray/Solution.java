package MergeSortedArray;

class Solution {
    public void merge(int[] nums1, int m, int[] nums2, int n) {
        var retVal = new int[n + m];
        int i = 0, j = 0, k = 0;
        while (i < m && j < n) {
            if (nums1[i] <= nums2[j]) {
                retVal[k] = nums1[i];
                i++;
            } else {
                retVal[k] = nums2[j];
                j++;
            }
            k++;
        }
        while (i < m) {
            retVal[k] = nums1[i];
            i++;
            k++;
        }
        while (j < n) {
            retVal[k] = nums2[j];
            j++;
            k++;
        }
        for (i = 0; i < n + m; i++) {
            nums1[i] = retVal[i];
        }
    }
}