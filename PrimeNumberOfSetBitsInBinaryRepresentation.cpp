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
    vector<bool> primes;
    int getNumBits(int n)
    {
        int count = 0;
        for (int i = 0; i < 100 && n > 0; i++)
        {
            count += n & 1;
            n >>= 1;
        }
        return count;
    }
    bool isPrime(int x)
    {
        return (x == 2 || x == 3 || x == 5 || x == 7 ||
                x == 11 || x == 13 || x == 17 || x == 19);
    }

public:
    int countPrimeSetBits(int L, int R)
    {
        int count = 0, numBits;
        while (L <= R)
        {
            numBits = getNumBits(L);
            if (isPrime(numBits))
            {
                ++count;
            }
            ++L;
        }
        return count;
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
