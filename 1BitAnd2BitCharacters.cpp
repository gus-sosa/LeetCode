#include <iostream>
#include <string>
#include <algorithm>
#include <vector>
using namespace std;

class Solution
{
public:
    bool isOneBitCharacter(vector<int> &bits)
    {
        for (int i = 0; i < bits.size(); ++i)
        {
            if (i==bits.size()-1)
            {
                return true;
            }
            if (bits[i]==1)
            {
                ++i;
            }
        }
        return false;
    }
};
//////////////////
int main()
{
    Solution s{Solution()};
    vector<int> v1{1, 0, 0};
    cout << (s.isOneBitCharacter(v1) == true) << endl;

    vector<int> v2{1, 1, 1, 0};
    cout << (s.isOneBitCharacter(v2) == false) << endl;

    vector<int> v3{1, 1, 0, 0};
    cout << (s.isOneBitCharacter(v3) == true) << endl;

    vector<int> v4{1, 1, 0};
    cout << (s.isOneBitCharacter(v4) == true) << endl;
}
