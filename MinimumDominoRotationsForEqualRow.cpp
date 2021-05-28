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
private:
    int getMin(vector<int> &tops, vector<int> &bottoms, int commonNum)
    {
        int numCommonNumInTop = 0, numCommonNumInBottom = 0, numCommonNumInBoth = 0;
        for (int i = 0; i < tops.size(); i++)
        {
            if (tops[i] == bottoms[i] && tops[i] == commonNum)
            {
                ++numCommonNumInBoth;
            }
            else if (tops[i] == commonNum)
            {
                ++numCommonNumInTop;
            }
            else if (bottoms[i] == commonNum)
            {
                ++numCommonNumInBottom;
            }
        }
        if (numCommonNumInTop + numCommonNumInBottom + numCommonNumInBoth != tops.size())
        {
            return -1;
        }
        return min(numCommonNumInTop, numCommonNumInBottom);
    }

public:
    int minDominoRotations(vector<int> &tops, vector<int> &bottoms)
    {
        int minRotations = -1;
        if (tops[0] == bottoms[1] || tops[0] == tops[1])
        {
            minRotations = getMin(tops, bottoms, tops[0]);
        }
        if (bottoms[0] == tops[1] || bottoms[0] == bottoms[1])
        {
            int t = getMin(tops, bottoms, bottoms[0]);
            if (minRotations == -1)
            {
                minRotations = t;
            }
            else if (t != -1)
            {
                minRotations = std::min(minRotations, t);
            }
        }
        return minRotations;
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

    vector<int> vt1{1, 2, 1, 1, 1, 2, 2, 2};
    vector<int> vb1{2, 1, 2, 2, 2, 2, 2, 2};
    cout << (s.minDominoRotations(vt1, vb1) == 1) << endl;
}
