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
    char findTheDifference(string s, string t)
    {
        char value = 0;
        for (auto &&i : s)
        {
            value ^= i;
        }
        for (auto &&i : t)
        {
            value ^= i;
        }

        return value;
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
