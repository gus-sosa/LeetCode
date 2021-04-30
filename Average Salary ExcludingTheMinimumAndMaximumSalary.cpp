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
    double average(vector<int> &salary)
    {
        double min = salary[0], max = salary[0];
        double sum = 0, c;
        for (auto &&i : salary)
        {
            auto ii=(double)i;
            min = std::min(min, ii);
            max = std::max(max, ii);
            sum += i;
            ++c;
        }
        return (sum - min - max) / (c - 2);
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

    vector<int> v1{48000, 59000, 99000, 13000, 78000, 45000, 31000, 17000, 39000, 37000, 93000, 77000, 33000, 28000, 4000, 54000, 67000, 6000, 1000, 11000};
    cout << (s.average(v1)) << endl;
    //cout << (s.average(v1) == 41111.11111) << endl;
}
