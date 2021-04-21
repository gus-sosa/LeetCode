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
        int l = 0;
        while (current)
        {
            ++l;
            current = current->next;
        }

        return l;
    }

public:
    int getDecimalValue(ListNode *head)
    {
        int l = getLength(head) - 1, num = 0;
        ListNode *current = head;
        for (; l >= 0; --l)
        {
            num += current->val * pow(2, l);
            current = current->next;
        }
        return num;
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
