#include <iostream>
#include <string>
#include <algorithm>
#include <vector>
#include <map>
#include <queue>
#include <math.h>
using namespace std;

class Solution
{
public:
    int maximumUnits(vector<vector<int>> &boxTypes, int truckSize)
    {
        sort(boxTypes.begin(), boxTypes.end(), [](const vector<int> v1, const vector<int> v2) {
            return v1[1] >= v2[1];
        });
        int numberOfUnits = 0, numBoxes, numUnits;
        for (auto &&i : boxTypes)
        {
            numBoxes = min(i[0], truckSize);
            numUnits = i[1];
            numberOfUnits += numUnits * numBoxes;
            truckSize -= numBoxes;
        }
        return numberOfUnits;
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
