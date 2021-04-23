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
    string modifyString(string s)
    {
        stringstream ss{};
        string set = "ahifyweklnv";
        char c;
        for (int i = 0; i < s.size(); i++)
        {
            if (s[i] == '?')
            {
                for (auto &&cc : set)
                {
                    if (i > 0 && (s[i - 1] == cc || ss.str()[i - 1] == cc))
                    {
                        continue;
                    }
                    if (i < s.size() - 1 && s[i + 1] == cc)
                    {
                        continue;
                    }
                    c = cc;
                    break;
                }
                ss << c;
            }
            else
            {
                ss << s[i];
            }
        }

        return ss.str();
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

    cout << s.modifyString("?zs") << endl;
    cout << s.modifyString("ubv?w") << endl;
    cout << s.modifyString("j?qg??b") << endl;
    cout << s.modifyString("??yw?ipkj?") << endl;
}
