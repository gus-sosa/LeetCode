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
    string reverseVowels(string s)
    {
        int left = 0, right = s.size() - 1;
        string vowels = "aeiouAEIOU";
        while (left < right)
        {
            if (vowels.find(s[left]) == string::npos)
            {
                ++left;
            }
            else if (vowels.find(s[right]) == string::npos)
            {
                --right;
            }
            else
            {
                swap(s[left], s[right]);
                ++left;
                --right;
            }
        }
        return s;
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
