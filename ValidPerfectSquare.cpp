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
    bool isPerfectSquare(int num)
    {
        unsigned long long left = 1, right = num / 2, middle,sq;
        while (left < right)
        {
            middle = (left + right) / 2;
            sq = middle * middle;
            if (sq == num)
            {
                return true;
            }
            else if (sq < num)
            {
                left = middle + 1;
            }
            else
            {
                right = middle;
            }
        }
        return num == 1 || left * left == num;
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
    cout << (s.isPerfectSquare(16) == true) << endl;
    cout << (s.isPerfectSquare(4) == true) << endl;
    cout << (s.isPerfectSquare(9) == true) << endl;
    cout << (s.isPerfectSquare(1) == true) << endl;
    cout << (s.isPerfectSquare(7) == false) << endl;
    cout << (s.isPerfectSquare(10) == false) << endl;
    cout << (s.isPerfectSquare(INT_MAX) == false) << endl;
}
