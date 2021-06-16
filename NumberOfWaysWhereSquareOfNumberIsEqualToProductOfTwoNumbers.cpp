#include <iostream>
#include <string>
#include <algorithm>
#include <vector>
#include <map>
#include <unordered_map>
#include <unordered_set>
using namespace std;

class Solution
{
private:
    int numTriplets1(vector<int> &nums1, vector<int> &nums2)
    {
        unordered_map<unsigned long long, unordered_set<int>> m{};
        for (int i = 0; i < nums2.size(); i++)
        {
            if (m.find(nums2[i]) == m.end())
            {
                m.insert(pair<unsigned long long, unordered_set<int>>(nums2[i], unordered_set<int>()));
            }
            m[nums2[i]].insert(i);
        }
        int c, count = 0;
        unsigned long long n1, n2;
        for (int iNum1 = 0, iNum2; iNum1 < nums1.size(); iNum1++)
        {
            n1 = (unsigned long long)nums1[iNum1] * (unsigned long long)nums1[iNum1];
            for (iNum2 = 0, c = 0; iNum2 < nums2.size(); iNum2++)
            {
                if (n1 % nums2[iNum2] == 0)
                {
                    n2 = n1 / nums2[iNum2];
                    if (m.find(n2) != m.end())
                    {
                        c += m[n2].size();
                        if (m[n2].find(iNum2) != m[n2].end())
                        {
                            --c;
                        }
                    }
                }
            }
            c >>= 1;
            count += c;
        }
        return count;
    }

public:
    int numTriplets(vector<int> &nums1, vector<int> &nums2)
    {
        return numTriplets1(nums1, nums2) + numTriplets1(nums2, nums1);
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

    vector<int> n1_1{7, 4};
    vector<int> n2_1{5, 2, 8, 9};
    cout << (s.numTriplets(n1_1, n2_1) == 1) << endl;
}
