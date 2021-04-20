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
    int findKthPositive(vector<int> &arr, int k)
    {
        unordered_set<int> s{};
        for (auto &&i : arr)
        {
            s.insert({i});
        }
        for (int i = 1; i < 1000000; i++)
        {
            if (s.find(i) == s.end())
            {
                --k;
                if (k == 0)
                {
                    return i;
                }
            }
        }
        return -1;
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
    vector<int> v1{2, 3, 4, 7, 11};
    cout << (s.findKthPositive(v1, 5) == 9) << endl;
}
