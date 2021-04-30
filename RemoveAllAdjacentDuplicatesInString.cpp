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
    string removeDuplicates(string S)
    {
        stack<char> s{};
        for (auto &&i : S)
        {
            if (s.size() > 0 && s.top() == i)
            {
                s.pop();
            }
            else
            {
                s.push(i);
            }
        }
        stringstream ss{};
        while (s.size() > 0)
        {
            ss << s.top();
            s.pop();
        }
        string result = ss.str();
        std::reverse(result.begin(), result.end());
        return result;
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
