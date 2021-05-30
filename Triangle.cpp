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
    int minimumTotal(vector<vector<int>> &triangle)
    {
        vector<int> prev(triangle[triangle.size() - 1].size());
        prev[0] = triangle[0][0];
        vector<int> next(triangle[triangle.size() - 1].size());
        for (int i = 1, j; i < triangle.size(); i++)
        {
            for (j = 0; j < triangle[i].size(); j++)
            {
                if (j == 0)
                {
                    next[j] = triangle[i][j] + prev[j];
                }
                else if (j == triangle[i].size() - 1)
                {
                    next[j] = triangle[i][j] + prev[j - 1];
                }
                else
                {
                    next[j] = min(triangle[i][j] + prev[j], triangle[i][j] + prev[j - 1]);
                }
            }
            vector<int> tmp = prev;
            prev = next;
            next = tmp;
        }
        return *min_element(prev.begin(), prev.end());
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
    v.push_back({2});
    v.push_back({3, 4});
    v.push_back({6, 5, 7});
    v.push_back({4, 1, 8, 3});
    cout << (s.minimumTotal(v) == 11) << endl;
}
