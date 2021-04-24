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

class NumArray
{
private:
    int matrix[10001][10001];
    int l;

public:
    NumArray(vector<int> &nums)
    {
        l = nums.size();
        for (int i = 0, j; i < l; i++)
        {
            matrix[i][i] = nums[i];
            for (j = i + 1; j < l; j++)
            {
                matrix[i][j] = matrix[i][j - 1] + nums[j];
            }
        }
    }

    int sumRange(int left, int right)
    {
        return matrix[left][right];
    }
};

/**
 * Your NumArray object will be instantiated and called as such:
 * NumArray* obj = new NumArray(nums);
 * int param_1 = obj->sumRange(left,right);
 */
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
