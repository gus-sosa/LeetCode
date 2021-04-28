#include <iostream>
#include <string>
#include <algorithm>
#include <vector>
#include <queue>
using namespace std;

class Solution
{
public:
    bool lemonadeChange(vector<int> &bills)
    {
        int fives = 0, tens = 0;
        for (auto &&i : bills)
        {
            if (i == 5)
            {
                ++fives;
            }
            else if (i == 10)
            {
                if (fives == 0)
                {
                    return false;
                }
                --fives;
                ++tens;
            }
            else
            { //i==20
                if (tens >= 1 && fives >= 1)
                {
                    --fives;
                    --tens;
                }
                else if (fives >= 3)
                {
                    fives -= 3;
                }
                else
                {
                    return false;
                }
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
}
