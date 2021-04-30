#include <iostream>
#include <string>
#include <algorithm>
#include <vector>
#include <queue>
using namespace std;

class Solution
{
public:
    int findContentChildren(vector<int> &g, vector<int> &s)
    {
        priority_queue<int, vector<int>, greater<int>> pg{};
        for (auto &&i : g)
        {
            pg.push(i);
        }
        priority_queue<int, vector<int>, greater<int>> ps{};
        for (auto &&i : s)
        {
            ps.push(i);
        }
        int c = 0;
        while (pg.size() > 0 && ps.size() > 0)
        {
            if (pg.top() <= ps.top())
            {
                pg.pop();
                ++c;
            }
            ps.pop();
        }
        return c;
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

    vector<int> g2{1, 2};
    vector<int> s2{1, 2, 3};
    cout << (s.findContentChildren(g2, s2) == 2) << endl;

    vector<int> g1{1, 2, 3};
    vector<int> s1{1, 1};
    cout << (s.findContentChildren(g1, s1) == 1) << endl;
}
