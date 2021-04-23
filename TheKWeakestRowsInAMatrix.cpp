#include <iostream>
#include <string>
#include <algorithm>
#include <vector>
#include <map>
#include <queue>
#include <math.h>
#include <charconv>
#include <sstream>
using namespace std;

class Solution
{
private:
    tuple<int, int> *getRowsInfo(vector<vector<int>> mat)
    {
        tuple<int, int> *rows = new tuple<int, int>[mat.size()];
        for (int i = 0, soldierCount = 0, j; i < mat.size(); i++, soldierCount = 0)
        {
            for (j = 0; j < mat[0].size() && mat[i][j] == 1; j++)
            {
                ++soldierCount;
            }
            rows[i] = make_tuple(i, soldierCount);
        }
        return rows;
    }
    void sortRows(tuple<int, int> *rows, int left, int right)
    {
        if (left >= right)
        {
            return;
        }
        int middle = (left + right) / 2;
        sortRows(rows, left, middle);
        sortRows(rows, middle + 1, right);
        vector<tuple<int, int>> v;
        int i = left, j = middle + 1;
        while (i <= middle && j <= right)
        {
            v.push_back(get<1>(rows[i]) <= get<1>(rows[j]) ? rows[i++] : rows[j++]);
        }
        while (i <= middle)
        {
            v.push_back(rows[i++]);
        }
        while (j <= right)
        {
            v.push_back(rows[j++]);
        }
        for (auto &&i : v)
        {
            rows[left++] = i;
        }
    }

public:
    vector<int> kWeakestRows(vector<vector<int>> &mat, int k)
    {
        tuple<int, int> *rows = getRowsInfo(mat);
        sortRows(rows, 0, mat.size() - 1);
        vector<int> result{};
        for (int i = 0; i < k; i++)
        {
            result.push_back(get<0>(rows[i]));
        }
        delete[] rows;
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
}
