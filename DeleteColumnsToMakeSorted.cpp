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
public:
    int minDeletionSize(vector<string> &strs)
    {
        int numColumnsToDelete = 0;
        for (int i = 0, j; i < strs[0].size(); i++)
        {
            for (j = 1; j < strs.size(); j++)
            {
                if (strs[j - 1][i] > strs[j][i])
                {
                    ++numColumnsToDelete;
                    break;
                }
            }
        }
        return numColumnsToDelete;
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
