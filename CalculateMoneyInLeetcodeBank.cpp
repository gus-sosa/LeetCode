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
    int totalDayWeek(int n)
    {
        return n * (n + 1) / 2;
    }

public:
    int totalMoney(int n)
    {
        int total = -56;
        int numWeeks = (n - 1) / 7 + 1;
        for (int i = 0; i < 7; i++)
        {
            total += (numWeeks + i) * (numWeeks + 1 + i) / 2;
        }
        int weekNum = (n - 1) % 7;
        int num = numWeeks + weekNum + 1;
        ++weekNum;
        while (weekNum < 7)
        {
            total -= num;
            ++num;
            ++weekNum;
        }

        return total;
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
    cout << (s.totalMoney(4) == 10) << endl;
    cout << (s.totalMoney(7) == 28) << endl;
    cout << (s.totalMoney(175) == 2800) << endl;
    cout << (s.totalMoney(10) == 37) << endl;
    cout << (s.totalMoney(20) == 96) << endl;
}
