#include <iostream>
#include <string>
#include <algorithm>
#include <vector>
#include <map>
#include <queue>
#include <math.h>
#include <charconv>
#include <sstream>
using namespace std;

class Solution
{
public:
    int maxAscendingSum(vector<int> &nums)
    {
        int left = 0, right = 0;
        int maxSum = nums[0], currentSum = nums[0];
        for (int i = 1; i < nums.size(); i++)
        {
            if (nums[i] > nums[i - 1])
            {
                currentSum += nums[i];
            }
            else
            {
                maxSum = max(maxSum, currentSum);
                currentSum = nums[i];
            }
        }
        return max(maxSum, currentSum);
    }
};
//////////////////
bool AreEqual(vector<int> v1, vector<int> v2)
{
    if (v1.size() != v2.size())
    {
        return false;
    }
    for (int i = 0; i < v1.size(); i++)
    {
        if (v1[i] != v2[i])
        {
            return false;
        }
    }
    return true;
}
void printArray(vector<int> arr)
{
    for (int i = 0; i < arr.size(); i++)
    {
        cout << arr[i] << endl;
    }
}

int main()
{
    Solution s{Solution()};

    vector<int> v5{3, 6, 10, 1, 8, 9, 9, 8, 9};
    cout << (s.maxAscendingSum(v5) == 19) << endl;

    vector<int> v2{10, 20, 30, 40, 50};
    cout << (s.maxAscendingSum(v2) == 150) << endl;

    vector<int> v1{10, 20, 30, 5, 10, 50};
    cout << (s.maxAscendingSum(v1) == 65) << endl;

    vector<int> v3{12, 17, 15, 13, 10, 11, 12};
    cout << (s.maxAscendingSum(v3) == 33) << endl;

    vector<int> v4{100, 10, 1};
    cout << (s.maxAscendingSum(v4) == 100) << endl;
}
