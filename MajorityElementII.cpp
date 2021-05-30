#include <iostream>
#include <string>
#include <algorithm>
#include <vector>
#include <map>
#include <queue>
#include <math.h>
#include <charconv>
#include <sstream>
#include <map>
#include <unordered_map>
using namespace std;

class Solution
{
public:
    vector<int> majorityElement(vector<int> &nums)
    {
        unordered_map<int, int> m{};
        for (auto &&i : nums)
        {
            if (m.find(i) == m.end())
            {
                m.insert(pair<int, int>(i, 0));
            }
            m.find(i)->second += 1;
        }
        double n3 = floor(nums.size() / 3.0);
        vector<int> result{};
        for (auto &&i : m)
        {
            if (i.second > n3)
            {
                result.push_back(i.first);
            }
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
