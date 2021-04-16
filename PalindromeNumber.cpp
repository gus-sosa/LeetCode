#include <iostream>
#include <stack>
#include <queue>
using namespace std;

class Solution {
public:
    bool isPalindrome(int x) {
        if (x<0)
        {
            return false;
        }
        stack<int> s;
        queue<int> q;
        int c;
        while (x>0)
        {
            c=x%10;
            x/=10;
            s.push(c);
            q.push(c);
        }
        while (s.size()>0)
        {
            if (s.top()!=q.front())
            {
                return false;
            }
            s.pop();
            q.pop();
        }
        return true;
    }
};
//////////////////
int main()
{
    Solution s{Solution()};
    cout<<(s.isPalindrome(123)==false)<<endl;
    cout<<(s.isPalindrome(121)==true)<<endl;
    cout<<(s.isPalindrome(1)==true)<<endl;
    cout<<(s.isPalindrome(0)==true)<<endl;
    cout<<(s.isPalindrome(-1234)==false)<<endl;
}