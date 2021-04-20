#include <iostream>
#include <string>
#include <algorithm>
#include <vector>
using namespace std;

class Solution
{
public:
    vector<int> addToArrayForm(vector<int> &num, int k)
    {
        vector<int> result{};
        int carry = 0;
        for (int i = num.size() - 1; i >= 0; i--)
        {
            result.push_back(carry + num[i] + k % 10);
            carry = result[result.size() - 1] / 10;
            result[result.size() - 1] %= 10;
            k /= 10;
        }
        while (carry + k > 0)
        {
            result.push_back(carry + k % 10);
            carry = result[result.size() - 1] / 10;
            result[result.size() - 1] %= 10;
            k /= 10;
        }
        std::reverse(result.begin(), result.end());
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
    vector<int> v1{1, 2, 0, 0};
    vector<int> r1{1, 2, 3, 4};
    vector<int> rr1 = s.addToArrayForm(v1, 34);
    //printArray(rr1);
    cout << AreEqual(rr1, r1) << endl;

    vector<int> v2{2, 7, 4};
    vector<int> r2{4, 5, 5};
    vector<int> rr2 = s.addToArrayForm(v2, 181);
    cout << AreEqual(rr2, r2) << endl;

    vector<int> v3{2, 1, 5};
    vector<int> r3{1, 0, 2, 1};
    cout << AreEqual(s.addToArrayForm(v3, 806), r3) << endl;

    vector<int> v4{9, 9, 9, 9, 9, 9, 9, 9, 9, 9};
    vector<int> r4{1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0};
    cout << AreEqual(s.addToArrayForm(v4, 1), r4) << endl;

    vector<int> v5{7};
    vector<int> r5{1, 0, 0, 0};
    cout << AreEqual(s.addToArrayForm(v5, 993), r5) << endl;
}
