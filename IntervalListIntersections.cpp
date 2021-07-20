#include <iostream>
#include <string>
#include <algorithm>
#include <vector>
#include <map>
#include <queue>
#include <math.h>
#include <stack>
#include <sstream>
#include <set>
using namespace std;

class Solution
{
public:
    vector<vector<int>> intervalIntersection(vector<vector<int>> &firstList, vector<vector<int>> &secondList)
    {
        vector<vector<int>> result{};
        queue<vector<int>> q{};
        set<pair<int, int>> h{};
        q.push({0, 0});
        while (q.size() > 0)
        {
            auto currentPair = q.front();
            q.pop();
            if (currentPair[0] >= firstList.size() || currentPair[1] >= secondList.size() || h.find(pair<int, int>(currentPair[0], currentPair[1])) != h.end())
            {
                continue;
            }
            h.insert(pair<int, int>(currentPair[0], currentPair[1]));
            auto seg1 = firstList[currentPair[0]];
            auto seg2 = secondList[currentPair[1]];

            if (seg1[1] < seg2[0])
            {
                q.push({currentPair[0] + 1, currentPair[1]});
            }
            else if (seg1[0] > seg2[1])
            {
                q.push({currentPair[0], currentPair[1] + 1});
            }
            else
            {
                int left = max(seg1[0], seg2[0]);
                int right = min(seg1[1], seg2[1]);
                result.push_back(vector<int>{left, right});
                q.push({currentPair[0] + 1, currentPair[1]});
                q.push({currentPair[0], currentPair[1] + 1});
            }
        }
        return result;
    }
};
////////
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
    Solution s{};
    vector<vector<int>> l1{{0, 2}, {5, 10}, {13, 23}, {24, 25}};
    vector<vector<int>> l2{{1, 5}, {8, 12}, {15, 24}, {25, 26}};
    s.intervalIntersection(l1, l2);
}
