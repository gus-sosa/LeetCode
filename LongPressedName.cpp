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
    bool isLongPressedName(string name, string typed)
    {
        int leftInName = 0, rightInName = 0, leftInTyped = 0, rightInTyped = 0;
        while (leftInName < name.size() && leftInTyped < typed.size())
        {
            rightInName = leftInName;
            while (rightInName < name.size() && name[leftInName] == name[rightInName])
            {
                ++rightInName;
            }
            rightInTyped = leftInTyped;
            while (rightInTyped < typed.size() && typed[leftInTyped] == typed[rightInTyped])
            {
                ++rightInTyped;
            }
            if (name[leftInName] != typed[leftInTyped] || (rightInName - leftInName) > (rightInTyped - leftInTyped))
            {
                return false;
            }
            leftInTyped = rightInTyped;
            leftInName = rightInName;
        }
        return leftInName == name.size() && leftInTyped == typed.size();
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
    cout << (s.isLongPressedName("alex", "aaleex") == true) << endl;
    cout << (s.isLongPressedName("saeed", "ssaaedd") == false) << endl;
    cout << (s.isLongPressedName("leelee", "lleeelee") == true) << endl;
    cout << (s.isLongPressedName("laiden", "laiden") == true) << endl;
}
