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
    vector<int> sortedSquares(vector<int> &nums)
    {
        vector<int> result{};
        int left = -1, right;
        for (auto &&i : nums)
        {
            ++left;
            if (i > 0)
            {
                break;
            }
        }
        right = left--;
        int sqLeft, sqRight;
        while (left >= 0 && right < nums.size())
        {
            sqLeft = nums[left] * nums[left];
            sqRight = nums[right] * nums[right];
            if (sqLeft <= sqRight)
            {
                result.push_back(sqLeft);
                --left;
            }
            else
            {
                result.push_back(sqRight);
                ++right;
            }
        }
        while (left >= 0)
        {
            result.push_back(nums[left] * nums[left]);
            --left;
        }
        while (right < nums.size())
        {
            result.push_back(nums[right] * nums[right]);
            ++right;
        }
        return result;
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

    vector<int> v1{-4, -1, 0, 3, 10};
    s.sortedSquares(v1);
}
