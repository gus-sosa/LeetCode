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
    int getNum(char c)
    {
        return c - '0';
    }

public:
    string addBinary(string a, string b)
    {
        stringstream result{};
        int carry = 0, indexA = a.size() - 1, indexB = b.size() - 1, na = 0, nb = 0, r = 0;
        while (indexA >= 0 && indexB >= 0)
        {
            na = getNum(a[indexA--]);
            nb = getNum(b[indexB--]);
            r = na + nb + carry;
            result << r % 2;
            carry = r / 2;
        }
        if (indexA < 0)
        {
            indexA = indexB;
            a = b;
        }
        while (indexA >= 0)
        {
            na = getNum(a[indexA--]);
            r = na + carry;
            result << r % 2;
            carry = r / 2;
        }
        while (carry > 0)
        {
            result << carry % 2;
            carry /= 2;
        }
        string rr = result.str();
        reverse(rr.begin(), rr.end());
        return rr;
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
    cout << s.addBinary("11", "1") << endl;
    cout << (s.addBinary("11", "1") == "100") << endl;
    cout << (s.addBinary("1010", "1011") == "10101") << endl;
}
