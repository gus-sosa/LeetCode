#include <iostream>
#include <string>
#include <algorithm>
#include <vector>
#include <map>
using namespace std;

class Solution
{
public:
    int surfaceArea(vector<vector<int>> &grid)
    {
        int area = 0;
        int n = grid.size();
        int m = grid[0].size();
        int c = 0;
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                if (grid[i][j] == 0)
                {
                    continue;
                }

                area += grid[i][j] * 4 + 2;
                if (i > 0)
                {
                    c = min(grid[i][j], grid[i - 1][j]);
                    area -= 2 * c;
                }
                if (j > 0)
                {
                    c = min(grid[i][j - 1], grid[i][j]);
                    area -= 2 * c;
                }
            }
        }
        return area;
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
    v.push_back({1, 0});
    v.push_back({0, 2});

    cout << (s.surfaceArea(v) == 16) << endl;
}
