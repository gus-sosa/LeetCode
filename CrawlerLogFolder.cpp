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
    int minOperations(vector<string> &logs)
    {
        int depth = 0;
        for (auto &&i : logs)
        {
            if (i == "./")
            {
                continue;
            }
            if (i == "../")
            {
                if (depth > 0)
                {
                    --depth;
                }
            }
            else
            {
                ++depth;
            }
        }
        return depth;
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
