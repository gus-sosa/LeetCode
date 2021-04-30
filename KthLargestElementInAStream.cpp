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

class KthLargest
{
private:
    int _k;
    priority_queue<int, vector<int>, greater<int>> pq{};

public:
    KthLargest(int k, vector<int> &nums)
    {
        _k = k;
        for (auto &&i : nums)
        {
            pq.push(i);
            if (pq.size() > k)
            {
                pq.pop();
            }
        }
    }

    int add(int val)
    {
        pq.push(val);
        if (pq.size() > _k)
        {
            pq.pop();
        }
        return pq.top();
    }
};

/**
 * Your KthLargest object will be instantiated and called as such:
 * KthLargest* obj = new KthLargest(k, nums);
 * int param_1 = obj->add(val);
 */
////////
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
    vector<int> nums{4, 5, 8, 2};
    KthLargest *obj = new KthLargest(3, nums);
    cout << (obj->add(3) == 4) << endl;
    cout << (obj->add(5) == 5) << endl;
    cout << (obj->add(10) == 5) << endl;
    cout << (obj->add(9) == 8) << endl;
    cout << (obj->add(4) == 8) << endl;
}
