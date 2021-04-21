#include <iostream>
#include <string>
#include <algorithm>
#include <vector>
#include <map>
#include <queue>
#include <math.h>
using namespace std;

struct ListNode
{
    int val;
    ListNode *next;
    ListNode() : val(0), next(nullptr) {}
    ListNode(int x) : val(x), next(nullptr) {}
    ListNode(int x, ListNode *next) : val(x), next(next) {}
};

class Solution
{
private:
    int getLength(ListNode *head)
    {
        ListNode *current = head;
        int length = 0;
        while (current)
        {
            current = current->next;
            ++length;
        }
        return length;
    }

public:
    ListNode *middleNode(ListNode *head)
    {
        int length = getLength(head);
        int middleIndex = length / 2;
        ListNode *current = head;
        for (; middleIndex > 0; --middleIndex)
        {
            current = current->next;
        }

        return current;
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
    for (int i = 0; i < 100; i++)
    {
        cout << "==========" << i << "=============" << endl;
        cout << i << endl
             << i / 2 << endl;
        cout << "=======================" << endl;
    }

    cout << 5 / 2 << endl;
    cout << 4 / 2 << endl;
}
