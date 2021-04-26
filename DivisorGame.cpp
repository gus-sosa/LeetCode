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
private:
    unordered_map<int, bool> aliceSet{};
    unordered_map<int, bool> notAliceSet{};
    bool divisorGame(int n, bool isAlice)
    {
        if (n <= 1)
        {
            return false;
        }
        if (isAlice)
        {
            if (aliceSet.find(n) != aliceSet.end())
            {
                return aliceSet.find(n)->second;
            }
        }
        else
        {
            if (notAliceSet.find(n) != notAliceSet.end())
            {
                return notAliceSet.find(n)->second;
            }
        }
        for (int i = 1; i < n; i++)
        {
            if (n % i == 0 && !divisorGame(n - i, !isAlice))
            {
                if (isAlice)
                {
                    aliceSet.insert({n, true});
                }
                else
                {
                    notAliceSet.insert({n, true});
                }
                return true;
            }
        }
        if (isAlice)
        {
            aliceSet.insert({n, false});
        }
        else
        {
            notAliceSet.insert({n, false});
        }
        return false;
    }

public:
    bool divisorGame(int n)
    {
        return divisorGame(n, true);
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

    cout << (s.divisorGame(2) == true) << endl;
    cout << (s.divisorGame(3) == false) << endl;
}
