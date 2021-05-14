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
private:
    int dirRows[4] = {-1, 0, 1, 0}, dirCols[4] = {0, 1, 0, -1};

private:
    void floodFillRecur(vector<vector<int>> &image, int sr, int sc, int color, int newColor, int numRows, int numCols)
    {
        if (image[sr][sc] == newColor)
        {
            return;
        }
        image[sr][sc] = newColor;
        for (int i = 0, newSr, newSc; i < 4; i++)
        {
            newSr = sr + dirRows[i];
            newSc = sc + dirCols[i];
            if (newSr >= 0 && newSc >= 0 && newSr < numRows && newSc < numCols && image[newSr][newSc] == color)
            {
                floodFillRecur(image, newSr, newSc, color, newColor, numRows, numCols);
            }
        }
    }

public:
    vector<vector<int>> floodFill(vector<vector<int>> &image, int sr, int sc, int newColor)
    {
        int numRows = image.size();
        int numCols = image[0].size();
        int color = image[sr][sc];
        if (color != newColor)
        {
            floodFillRecur(image, sr, sc, color, newColor, numRows, numCols);
        }
        return image;
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
