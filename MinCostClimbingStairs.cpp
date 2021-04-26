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
private:
    unordered_map<int, int> map{};
    int minCostClimbingStairs(vector<int> &cost, int pos)
    {
        if (pos >= cost.size())
        {
            return 0;
        }
        if (map.find(pos) == map.end())
        {
            map.insert({pos, cost[pos] + min(minCostClimbingStairs(cost, pos + 1), minCostClimbingStairs(cost, pos + 2))});
        }
        return map.find(pos)->second;
    }

public:
    int minCostClimbingStairs(vector<int> &cost)
    {
        return min(minCostClimbingStairs(cost, 0), minCostClimbingStairs(cost, 1));
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
