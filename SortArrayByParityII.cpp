#include <iostream>
#include <string>
#include <algorithm>
#include <vector>
#include <map>
#include <queue>
#include <math.h>
#include <charconv>
#include <sstream>
#include <set>
#include <unordered_set>
#include <unordered_map>
using namespace std;

class Solution
{
public:
    vector<int> sortArrayByParityII(vector<int> &nums)
    {
        for (int i = 0, j = 1, t; i < nums.size(); i += 2)
        {
            if (nums[i] % 2 != 0)
            {
                while (nums[j] % 2 == 1)
                {
                    j += 2;
                }
                swap(nums[i], nums[j]);
            }
        }
        return nums;
    }
};
//////////////////

// vector<int> odds{}, evens{};
// for (auto &&i : nums)
// {
//     if (i % 2 == 0)
//     {
//         evens.push_back(i);
//     }
//     else
//     {
//         odds.push_back(i);
//     }
// }
// for (int i = 0, o = 0, e = 0; i < nums.size(); i++)
// {
//     nums[i] = i % 2 == 0 ? evens[e++] : odds[o++];
// }
// return nums;

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
}
