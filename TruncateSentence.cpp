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
    vector<int> getEndWords(string s)
    {
        vector<int> indexes{};
        for (int i = 0; i < s.size(); i++)
        {
            if (s[i] == ' ')
            {
                indexes.push_back(i - 1);
            }
        }
        indexes.push_back(s.size() - 1);
        return indexes;
    }

public:
    string truncateSentence(string s, int k)
    {
        vector<int> indexesEndWords = getEndWords(s);
        if (k >= indexesEndWords.size())
        {
            return s;
        }
        int end = indexesEndWords[k - 1] + 1;
        string result = "";
        for (int i = 0; i < end; i++)
        {
            result.push_back(s[i]);
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
