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
private:
    int gcd(int a, int b)
    {
        if (a == 0 || b == 0)
        {
            return max(a, b);
        }
        if (a == b)
        {
            return a;
        }
        return a > b ? gcd(a - b, b) : gcd(b - a, a);
    }

public:
    bool hasGroupsSizeX(vector<int> &deck)
    {
        vector<int> map{};
        for (int i = 0; i < 10001; i++)
        {
            map.push_back(-1);
        }
        for (auto &&i : deck)
        {
            if (map[i] == -1)
            {
                ++map[i];
            }
            ++map[i];
        }
        int partitionCount = -1;
        for (auto &&i : map)
        {
            if (i == -1)
            {
                continue;
            }
            if (partitionCount == -1)
            {
                partitionCount = i;
                continue;
            }
            partitionCount = gcd(partitionCount, i);
            if (partitionCount == 1)
            {
                return false;
            }
        }

        return partitionCount > 1;
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
    vector<int> v3{1, 1, 2, 2, 2, 2};
    cout << (s.hasGroupsSizeX(v3) == true) << endl;

    vector<int> v2{1, 2, 3, 4, 4, 3, 2, 1};
    cout << (s.hasGroupsSizeX(v2) == true) << endl;

    vector<int> v1{1};
    cout << (s.hasGroupsSizeX(v1) == false) << endl;
}
