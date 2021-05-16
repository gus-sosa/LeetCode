#include <iostream>
#include <string>
#include <algorithm>
#include <vector>
#include <map>
using namespace std;

class Solution
{
public:
    bool checkStraightLine(vector<vector<int>> &coordinates)
    {
        if (coordinates[0][0] == coordinates[1][0])
        {
            for (int i = 2; i < coordinates.size(); i++)
            {
                if (coordinates[0][0] != coordinates[i][0])
                {
                    return false;
                }
            }
            return true;
        }
        if (coordinates[0][1] == coordinates[1][1])
        {
            for (int i = 0; i < coordinates.size(); i++)
            {
                if (coordinates[0][1] != coordinates[i][1])
                {
                    return false;
                }
            }
            return true;
        }
        double m = (1.0 * coordinates[0][1] - 1.0 * coordinates[1][1]) / (1.0 * coordinates[0][0] - 1.0 * coordinates[1][0]);
        double n = 1.0 * coordinates[0][1] - m * coordinates[0][0];
        for (int i = 2; i < coordinates.size(); i++)
        {
            if (coordinates[i][1] - m * coordinates[i][0] - n != 0)
            {
                return false;
            }
        }
        return true;
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
    v.push_back({2, 1});
    v.push_back({4, 2});
    v.push_back({6, 3});

    cout << (s.checkStraightLine(v) == true) << endl;
}
