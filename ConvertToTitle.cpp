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
private:
    char getNum(int n)
    {
        return n == 0 ? 'Z' : ('A' + n - 1);
    }

public:
    string convertToTitle(int columnNumber)
    {
        stringstream ss{};
        while (columnNumber > 26)
        {
            ss << getNum(columnNumber % 26);
            if (columnNumber%26==0)
            {
                --columnNumber;
            }
            columnNumber /= 26;
        }
        ss << getNum(columnNumber);
        auto title = ss.str();
        reverse(title.begin(), title.end());
        return title;
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
    cout << (s.convertToTitle(52) == "AZ") << endl;
    cout << (s.convertToTitle(2147483647) == "FXSHRXW") << endl;
}
