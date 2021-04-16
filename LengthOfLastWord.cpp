#include <iostream>
#include <string>
#include <algorithm>
using namespace std;

class Solution
{
public:
    int lengthOfLastWord(string s)
    {
        int length = 0, cLength = 0, gettingWord = 0;
        for (int i = 0; i < s.length(); ++i)
        {
            for (; i < s.length() && s[i] != ' '; ++i)
            {
                gettingWord = 1;
                ++cLength;
            }
            if (gettingWord == 1)
            {
                gettingWord = 0;
                length = cLength;
                cLength = 0;
            }
        }
        return length;
    }
};
//////////////////
int main()
{
    Solution s{Solution()};
    cout << (s.lengthOfLastWord("locura") == 6) << endl;
    cout << (s.lengthOfLastWord("locura pal gao") == 3) << endl;
    cout << (s.lengthOfLastWord("Hello World") == 5) << endl;
    cout << (s.lengthOfLastWord(" ") == 0) << endl;
}
