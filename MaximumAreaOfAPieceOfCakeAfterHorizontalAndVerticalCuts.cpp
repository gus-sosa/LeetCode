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
    int maxArea(int h, int w, vector<int> &horizontalCuts, vector<int> &verticalCuts)
    {
        sort(horizontalCuts.begin(), horizontalCuts.end());
        sort(verticalCuts.begin(), verticalCuts.end());
        horizontalCuts.push_back(h);
        verticalCuts.push_back(w);
        int maxH = horizontalCuts[0], maxW = verticalCuts[0];
        for (int i = i + 1; i < horizontalCuts.size(); i++)
        {
            maxH = max(maxH, abs(horizontalCuts[i] - horizontalCuts[i - 1]));
        }
        for (int i = 0; i < verticalCuts.size(); i++)
        {
            maxW = max(maxW, abs(verticalCuts[i] - verticalCuts[i - 1]));
        }
        return (long long)maxH * (long long)maxW * (long long)(pow(10, 9) + 7);
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

    vector<int> hcuts{3, 1};
    vector<int> vcuts{1};
    cout << (s.maxArea(5, 4, hcuts, vcuts) == 6) << endl;
}
