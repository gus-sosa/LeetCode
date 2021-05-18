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
public:
    int findJudge(int n, vector<vector<int>> &trust)
    {
        int map[n][n];
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                map[i][j] = 0;
            }
        }
        for (auto &&i : trust)
        {
            map[i[0] - 1][i[1] - 1] = 1;
        }

        bool flag = false;
        for (int c = 0; c < n; c++)
        {
            flag = true;
            for (int i = 0; i < n && flag; i++)
            {
                if (i != c)
                {
                    flag = map[c][i] == 0 && map[i][c] == 1;
                }
            }
            if (flag)
            {
                return c + 1;
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

    vector<vector<int>> v{};
    v.push_back({1, 2});
    cout << (s.findJudge(2, v) == 2) << endl;
}
