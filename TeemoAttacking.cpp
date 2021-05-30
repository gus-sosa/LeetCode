#include <iostream>
#include <string>
#include <algorithm>
#include <vector>
#include <map>
#include <queue>
#include <math.h>
#include <stack>
#include <sstream>
using namespace std;

class Solution
{
public:
    int findPoisonedDuration(vector<int> &timeSeries, int duration)
    {
        queue<vector<int>> q{};
        for (auto &&i : timeSeries)
        {
            q.push({i, i + duration - 1});
        }
        int durationPoisoned = 0;
        while (q.size() > 0)
        {
            auto t = q.front();
            q.pop();
            while (q.size() > 0)
            {
                auto tt = q.front();
                if (t[1] >= tt[0])
                {
                    t[1] = max(t[1], tt[1]);
                    q.pop();
                }
                else
                {
                    break;
                }
            }
            durationPoisoned += t[1] - t[0] + 1;
        }
        return durationPoisoned;
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
