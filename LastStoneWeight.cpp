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
    int lastStoneWeight(vector<int> &stones)
    {
        make_heap(stones.begin(), stones.end());
        int a, b;
        while (stones.size() > 1)
        {
            a = stones.front();
            pop_heap(stones.begin(), stones.end());
            stones.pop_back();
            b = stones.front();
            pop_heap(stones.begin(), stones.end());
            stones.pop_back();
            if (a != b)
            {
                stones.push_back(abs(a - b));
                push_heap(stones.begin(), stones.end());
            }
        }
        return stones.size() > 0 ? stones.front() : 0;
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

    vector<int> v1{2, 2};
    cout << (s.lastStoneWeight(v1) == 0) << endl;
}
