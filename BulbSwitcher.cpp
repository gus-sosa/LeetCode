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
private:
    unordered_map<int, int> divs{};
    int getNumDivisors(int n)
    {
        if (divs.find(n) != divs.end())
        {
            return divs[n];
        }
        int c = 2;
        for (int i = 2; i < n; i++)
        {
            if (n % i == 0)
            {
                ++c;
            }
        }
        divs.insert(pair<int, int>(n, c));
        return c;
    }

public:
    int bulbSwitch(int n)
    {
        int c = 0, d;
        divs.insert(pair<int, int>(1, 1));
        divs.insert(pair<int, int>(2, 2));
        for (int i = 1; i <= n; i++)
        {
            d = getNumDivisors(i);
            if (d % 2 != 0)
            {
                ++c;
            }
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
}
