#include <iostream>
#include <string>
#include <algorithm>
#include <vector>
#include <map>
#include <queue>
#include <unordered_set>
using namespace std;

class Solution
{
public:
    int numberOfSteps(int num)
    {
        int steps = 0;
        while (num > 0)
        {
            if (num % 2 == 0)
            {
                num >>= 1;
            }
            else
            {
                num -= 1;
            }
            ++steps;
        }
        return steps;
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
