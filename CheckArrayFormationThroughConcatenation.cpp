#include <iostream>
#include <string>
#include <algorithm>
#include <vector>
#include <map>
using namespace std;

class Solution
{
public:
    bool canFormArray(vector<int> &arr, vector<vector<int>> &pieces)
    {
        map<int, int> dict{};
        for (int i = 0; i < arr.size(); i++)
        {
            dict.insert({arr[i], i});
        }
        int ii, index;
        for (auto &&i : pieces)
        {
            auto it = dict.find(i[0]);
            if (it == dict.end())
            {
                return false;
            }
            index = it->second;
            for (ii = 0; ii < i.size(); ii++, index++)
            {
                if (i[ii] != arr[index])
                {
                    return false;
                }
            }
        }
        return true;
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
    vector<int> v1{85};
    vector<vector<int>> p1{{85}};
    cout << (s.canFormArray(v1, p1) == true) << endl;

    vector<int> v2{15, 88};
    vector<vector<int>> p2{{88}, {15}};
    cout << (s.canFormArray(v2, p2) == true) << endl;

    vector<int> v3{49, 18, 16};
    vector<vector<int>> p3{{16, 18, 49}};
    cout << (s.canFormArray(v3, p3) == false) << endl;

    vector<int> v4{91, 4, 64, 78};
    vector<vector<int>> p4{{78}, {4, 64}, {91}};
    cout << (s.canFormArray(v4, p4) == true) << endl;

    vector<int> v5{1, 3, 5, 7};
    vector<vector<int>> p5{{2, 4, 6, 8}};
    cout << (s.canFormArray(v5, p5) == false) << endl;
}
