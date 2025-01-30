package MaximumDistanceBetweenAPairOfValues;

import java.util.Arrays;
import java.nio.file.Files;
import java.nio.file.Paths;
import java.io.IOException;

public class MaximumDistanceBetweenAPairOfValues {
    public static void main(String[] args) {
        var s = new Solution();
        System.out.println("######START: TESTING BINARY SEARCH####");
        runTestForBinarySearch(s, new int[] { 20, 10, 5, 2, 1 }, 6, 2);
        System.out.println("######END: TESTING BINARY SEARCH####");
        System.out.println("######START: TESTING SOLUTION####");
        runTestForSolution(s, new int[] { 55, 30, 5, 4, 2 }, new int[] { 100, 20, 10, 10, 5 }, 2);
        runTestForSolution(s, new int[] { 2, 2, 2 }, new int[] { 10, 10, 1 }, 1);
        runTestForSolution(s, new int[] { 30, 29, 19, 5 }, new int[] { 25, 25, 25, 25, 25 }, 2);
        runTestForSolution(s, new int[] { 2, 2, 2 }, new int[] { 1, 1, 1 }, 0);
        runTestForSolution(s, readTestFile("test1521_arr1.txt"), readTestFile("test1521_arr2.txt"), 7163);
        System.out.println("######END: TESTING SOLUTION####");
    }

    private static int[] readTestFile(String fileName) {
        try {
            return Files.lines(Paths.get("MaximumDistanceBetweenAPairOfValues", fileName))
                    .mapToInt(Integer::parseInt)
                    .toArray();
        } catch (IOException e) {
            e.printStackTrace();
            return new int[0];
        }
    }

    private static void runTestForBinarySearch(Solution s, int[] arr, int value, int expectedResult) {
        System.out.println("======START======");
        System.out.println(String.format("-- Testing with arr=[%s] and value=[%d]", Arrays.toString(arr), value));
        try {
            var result = s.binarySearch(arr, value, 0, arr.length - 1);
            if (result == expectedResult) {
                System.out.println("PASSED");
            } else {
                System.out.println(String.format("FAILED: expecting %d but got %d", expectedResult, result));
            }
        } catch (Exception e) {
            System.out.println(String.format("FAILED (exception): %s", e.getMessage()));
        }
        System.out.println("======END======");
    }

    private static void runTestForSolution(Solution s, int[] arr1, int[] arr2, int expectedValue) {
        System.out.println("======START======");
        System.out.println(
                String.format("Testing with arr1=[%s] and arr2=[%s]", Arrays.toString(arr1), Arrays.toString(arr2)));
        try {
            var result = s.maxDistance(arr1, arr2);
            if (result == expectedValue) {
                System.out.println("PASSED");
            } else {
                System.out.println(String.format("FAILED: expecting %d but got %d", expectedValue, result));
            }
        } catch (Exception e) {
            System.out.println(String.format("FAILED (exception): %s", e.getMessage()));
        }
        System.out.println("======END======");
    }
}