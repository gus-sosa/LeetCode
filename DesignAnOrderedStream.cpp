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

class OrderedStream
{
private:
    vector<string> v{};
    int p = 0;

public:
    OrderedStream(int n)
    {
        for (int i = 0; i < n; i++)
        {
            v.push_back("");
        }
    }

    vector<string> insert(int idKey, string value)
    {
        v[idKey - 1] = value;
        vector<string> result{};
        while (p < v.size() && v[p] != "")
        {
            result.push_back(v[p++]);
        }
        return result;
    }
};

/**
 * Your OrderedStream object will be instantiated and called as such:
 * OrderedStream* obj = new OrderedStream(n);
 * vector<string> param_1 = obj->insert(idKey,value);
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
    OrderedStream *os = new OrderedStream(5);
    os->insert(3, "c");
    os->insert(1, "a");
    os->insert(2, "b");
    os->insert(5, "3");
    os->insert(4, "d");
}
