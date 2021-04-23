#include <iostream>
#include <string>
#include <algorithm>
#include <vector>
#include <map>
#include <queue>
#include <math.h>
#include <charconv>
#include <sstream>
using namespace std;

class Solution
{
public:
    string thousandSeparator(int n)
    {
        if (n == 0)
        {
            return "0";
        }
        stringstream ss{};
        int pos = 0;
        while (n > 0)
        {
            ++pos;
            ss << n % 10;
            n /= 10;
            if (pos % 3 == 0)
            {
                ss << ".";
            }
        }
        auto result = ss.str();
        std::reverse(result.begin(), result.end());
        if (result[0] == '.')
        {
            result = result.substr(1);
        }
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
