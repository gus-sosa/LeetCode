#include <iostream>
#include <string>
#include <algorithm>
#include <vector>
#include <map>
#include <queue>
#include <math.h>
#include <charconv>
#include <sstream>
#include <regex>
using namespace std;

class Solution
{
public:
    vector<string> getFolderNames(vector<string> &names)
    {
        vector<string> result{};
        map<string, int> m{};
        for (auto &&i : names)
        {
            if (m.find(i) != m.end())
            {
                m.find(i)->second += 1;
            }
            else
            {
                m.insert(pair<string, int>(i, 0));
            }
            result.push_back(i);
            if (m.find(i)->second != 0)
            {
                while (m.find(result[result.size() - 1] + "(" + to_string(m.find(i)->second) + ")") != m.end())
                {
                    m.find(i)->second += 1;
                }
                result[result.size() - 1] = result[result.size() - 1] + "(" + to_string(m.find(i)->second) + ")";
                m.insert(pair<string, int>(result[result.size() - 1], 0));
            }
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
