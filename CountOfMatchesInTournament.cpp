#include <iostream>
#include <string>
#include <algorithm>
#include <vector>
#include <map>
#include <queue>
#include <math.h>
#include <charconv>
#include <sstream>
#include <set>
#include <unordered_set>
#include <unordered_map>
using namespace std;

class Solution
{
public:
    int numberOfMatches(int n)
    {
        int totalMatches = 0, numCurrentMatches = 0;
        while (n > 1)
        {
            totalMatches += (n - n % 2) / 2;
            n = (n - n % 2) / 2 + n % 2;
        }
        return totalMatches;
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
    return 0;
}
