#include <iostream>
#include <string>
#include <algorithm>
#include <vector>
using namespace std;

class Solution {
public:
    string addBinary(string a, string b) {
        int carry=0;
        if (b.length()>a.length())
        {
            a=(b.length()-a.length(),'0')+a;
        }
        //string result=(b.length(),'0');

        return result;
    }
};
//////////////////
void print(vector<int> &v){
    for (auto &&i : v)
    {
        cout<<i<<endl;
    }
}

int main()
{
    Solution s{Solution()};
    cout<<((4-5,'0'))<<endl;
