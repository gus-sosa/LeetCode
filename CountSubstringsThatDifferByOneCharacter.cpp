#include <iostream>
#include <string>
#include <algorithm>
#include <vector>
#include <map>
#include <queue>
#include <math.h>
#include <stack>
#include <sstream>
#include <unordered_set>
#include <unordered_map>
using namespace std;

class Solution
{
private:
    unordered_map<string, int> getSubStrings(string t)
    {
        unordered_map<string, int> result{};
        for (int i = 0; i < t.size(); i++)
        {
            for (int j = i; j < t.size(); j++)
            {
                if (result.find(t.substr(i, j - i + 1)) == result.end())
                {
                    result.insert(pair<string, int>(t.substr(i, j - i + 1), 0));
                }
                ++result[t.substr(i, j - i + 1)];
            }
        }
        return result;
    }

public:
    int countSubstrings(string s, string t)
    {
        unordered_map<string, int> substrInT = getSubStrings(t);
        int count = 0;
        char original;
        for (int i = 0, j, k; i < s.size(); i++)
        {
            for (j = i; j < s.size(); j++)
            {
                string sb = s.substr(i, j - i + 1);
                for (k = 0; k < sb.size(); k++)
                {
                    original = sb[k];
                    for (char c = 'a'; c <= 'z'; c++)
                    {
                        if (c != original)
                        {
                            sb[k] = c;
                            if (substrInT.find(sb) != substrInT.end())
                            {
                                count += substrInT[sb];
                            }
                        }
                    }
                    sb[k] = original;
                }
            }
        }
        return count;
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

    cout << (s.countSubstrings("ab", "bb") == 3) << endl;
    cout << (s.countSubstrings("aba", "baba") == 6) << endl;
}
