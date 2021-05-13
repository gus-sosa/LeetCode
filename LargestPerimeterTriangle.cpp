#include <iostream>
#include <string>
#include <algorithm>
#include <vector>
#include <map>
#include <queue>
#include <unordered_set>
using namespace std;

class Solution
{
public:
    int largestPerimeter(vector<int> &nums)
    {
        sort(nums.begin(), nums.end());
        for (int i = nums.size() - 3; i >= 0; i--)
        {
            if (nums[i] + nums[i + 1] > nums[i + 2])
            {
                return nums[i] + nums[i + 1] + nums[i + 2];
            }
        }
        return 0;
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

    vector<int> v1{3, 2, 3, 4};
    cout << (s.largestPerimeter(v1) == 10) << endl;
}
