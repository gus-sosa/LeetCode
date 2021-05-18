#include <iostream>
#include <string>
#include <algorithm>
#include <vector>
#include <map>
#include <queue>
#include <math.h>
#include <stack>
#include <sstream>
using namespace std;

class Solution
{
public:
    int findLeastNumOfUniqueInts(vector<int> &arr, int k)
    {
        sort(arr.begin(), arr.end());
        vector<int> arrSorted{};
        int i = 0, j = 0;
        while (j < arr.size())
        {
            while (j < arr.size() && arr[i] == arr[j])
            {
                ++j;
            }
            arrSorted.push_back(j - i);
            i = j;
        }
        sort(arrSorted.begin(), arrSorted.end());
        i = 0;
        j = arrSorted.size();
        int t;
        while (k > 0)
        {
            t = min(arrSorted[i], k);
            k -= t;
            arrSorted[i] -= t;
            if (arrSorted[i] == 0)
            {
                --j;
            }
            i++;
        }
        return j;
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

    vector<int> v1{4, 3, 1, 1, 3, 3, 2};
    cout << (s.findLeastNumOfUniqueInts(v1, 3) == 2) << endl;

    vector<int> v{2, 4, 1, 8, 3, 5, 1, 3};
    cout << (s.findLeastNumOfUniqueInts(v, 3) == 3) << endl;
}
