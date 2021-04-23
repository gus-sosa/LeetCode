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
public:
    char nextGreatestLetter(vector<char> &letters, char target)
    {
        int left = 0, right = letters.size() - 1, middle = 0;
        while (left < right)
        {
            middle = (left + right) / 2;
            if (letters[middle] <= target)
            {
                left = middle + 1;
            }
            else
            {
                right = middle;
            }
        }
        return letters[left] <= target ? letters[0] : letters[left];
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

    vector<char> v1{'c', 'f', 'j'};
    cout << (s.nextGreatestLetter(v1, 'a') == 'c') << endl;

    vector<char> v2{'c', 'f', 'j'};
    cout << (s.nextGreatestLetter(v2, 'c') == 'f') << endl;

    vector<char> v3{'c', 'f', 'j'};
    cout << (s.nextGreatestLetter(v3, 'd') == 'f') << endl;

    vector<char> v4{'c', 'f', 'j'};
    cout << (s.nextGreatestLetter(v4, 'g') == 'j') << endl;

    vector<char> v5{'c', 'f', 'j'};
    cout << (s.nextGreatestLetter(v5, 'j') == 'c') << endl;

    vector<char> v6{'c', 'f', 'j'};
    cout << (s.nextGreatestLetter(v1, 'k') == 'c') << endl;

    vector<char> v7{'c', 'f', 'j'};
    cout << (s.nextGreatestLetter(v1, 'z') == 'c') << endl;
}
