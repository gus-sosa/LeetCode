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

struct ListNode
{
    int val;
    ListNode *next;
    ListNode() : val(0), next(nullptr) {}
    ListNode(int x) : val(x), next(nullptr) {}
    ListNode(int x, ListNode *next) : val(x), next(next) {}
};

class Solution
{
public:
    int calPoints(vector<string> &ops)
    {
        stack<int> s{};
        int v1, v2;
        for (auto &&i : ops)
        {
            if (i == "+")
            {
                v1 = s.top();
                s.pop();
                v2 = s.top();
                s.push(v1);
                s.push(v1 + v2);
            }
            else if (i == "D")
            {
                s.push(s.top() * 2);
            }
            else if (i == "C")
            {
                s.pop();
            }
            else
            {
                s.push(stoi(i));
            }
        }
        v1 = 0;
        while (s.size() > 0)
        {
            v1 += s.top();
            s.pop();
        }
        return v1;
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

    vector<string> v1{"5", "2", "C", "D", "+"};
    cout << (s.calPoints(v1) == 30) << endl;
}
