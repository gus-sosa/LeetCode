#include <iostream>
#include <string>
#include <algorithm>
#include <vector>
using namespace std;

class Solution
{
public:
    int removeElement(vector<int> &nums, int val)
    {
        int left{0}, right{0};
        for (auto &&c : nums)
        {
            if (c != val)
            {
                nums[left] = c;
                ++left;
            }
            ++right;
        }
        return left;
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
    
    vector<int> v1{1, 2, 3, 4};
    cout<<(s.removeElement(v1, 2)==3)<<endl;

    vector<int> v2{3,2,2,3};
    cout<<(s.removeElement(v2, 3)==2)<<endl;

    vector<int> v3{0,1,2,2,3,0,4,2};
    cout<<(s.removeElement(v3, 2)==5)<<endl;
}
