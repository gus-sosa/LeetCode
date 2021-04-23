#include <iostream>
#include <string>
#include <algorithm>
#include <vector>
#include <map>
#include <queue>
#include <math.h>
#include <charconv>
#include <sstream>
#include <unordered_map>
using namespace std;

class Solution
{
private:
    unordered_map<char, vector<int>> getMap(string t)
    {
        unordered_map<char, vector<int>> m{};
        for (int i = 0; i < t.size(); i++)
        {
            auto v = m.find(t[i]);
            if (v == m.end())
            {
                m.insert({t[i], vector<int>{}});
                v = m.find(t[i]);
            }
            v->second.push_back(i);
        }
        return m;
    }
    int getSmallestGreaterThan(vector<int> v, int target)
    {
        int left = 0, right = v.size() - 1, middle;
        while (left < right)
        {
            middle = (left + right) / 2;
            if (v[middle] <= target)
            {
                left = middle + 1;
            }
            else
            {
                right = middle;
            }
        }
        return v[left] <= target ? -1 : v[left];
    }

public:
    bool isSubsequence(string s, string t)
    {
        unordered_map<char, vector<int>> map = getMap(t);
        unordered_map<char, int> maxs{};
        unordered_map<char, int> count{};
        for (int i = 0; i < s.size(); i++)
        {
            if (maxs.find(s[i]) == maxs.end())
            {
                maxs.insert({s[i], -1});
                count.insert({s[i], 0});
            }
            count[s[i]] += 1;
            auto vector_i = map.find(s[i]);
            if (vector_i == map.end())
            {
                return false;
            }
            maxs[s[i]] = i == 0 ? vector_i->second.front() : getSmallestGreaterThan(vector_i->second, max(maxs[s[i]], maxs[s[i - 1]]));
            if (maxs[s[i]] == -1)
            {
                return false;
            }
        }
        for (auto &&i : count)
        {
            if (i.second > map[i.first].size())
            {
                return false;
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

    cout << (s.isSubsequence("acb", "ahbgdc") == false) << endl;
    cout << (s.isSubsequence("abc", "ahbgdc") == true) << endl;
    cout << (s.isSubsequence("axc", "ahbgdc") == false) << endl;
    cout << (s.isSubsequence("xc", "ahbgdc") == false) << endl;
    cout << (s.isSubsequence("gxc", "ahbgdc") == false) << endl;
}
