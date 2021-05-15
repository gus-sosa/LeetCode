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
    map<int, int> m{};

    int tribonnaciRecur(int n)
    {
        if (m.find(n) != m.end())
        {
            return m.at(n);
        }
        m.insert(pair<int, int>(n, tribonnaciRecur(n - 3) + tribonnaciRecur(n - 2) + tribonnaciRecur(n - 1)));
        return m.at(n);
    }

public:
    int tribonacci(int n)
    {
        m.insert(pair<int, int>(0, 0));
        m.insert(pair<int, int>(1, 1));
        m.insert(pair<int, int>(2, 1));
        return tribonnaciRecur(n);
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
