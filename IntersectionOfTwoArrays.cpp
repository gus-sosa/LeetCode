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
using namespace std;

class Solution
{
public:
    vector<int> intersection(vector<int> &nums1, vector<int> &nums2)
    {
        unordered_set<int> set{};
        unordered_set<int> intersection{};
        for (auto &&i : nums2)
        {
            set.insert(i);
        }
        for (auto &&i : nums1)
        {
            if (set.find(i) != set.end())
            {
                intersection.insert(i);
            }
        }
        vector<int> result{};
        for (auto &&i : intersection)
        {
            result.push_back(i);
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
}
