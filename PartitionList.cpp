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
public:
    ListNode *partition(ListNode *head, int x)
    {
        vector<ListNode *> lessThanX{};
        vector<ListNode *> greaterThanX{};
        ListNode *current = head;
        while (current != NULL)
        {
            if (current->val < x)
            {
                lessThanX.push_back(current);
            }
            else
            {
                greaterThanX.push_back(current);
            }
            current = current->next;
        }
        if (lessThanX.size() > 0)
        {
            head = lessThanX[0];
            if (greaterThanX.size() > 0)
            {
                lessThanX[lessThanX.size() - 1]->next = greaterThanX[0];
                greaterThanX[greaterThanX.size() - 1]->next = NULL;
            }
            else
            {
                lessThanX[lessThanX.size() - 1]->next = NULL;
            }
        }
        else
        {
            head = greaterThanX[0];
            greaterThanX[greaterThanX.size() - 1]->next = NULL;
        }
        for (int i = 1; i < lessThanX.size(); i++)
        {
            lessThanX[i - 1]->next = lessThanX[i];
        }
        for (int i = 1; i < greaterThanX.size(); i++)
        {
            greaterThanX[i - 1]->next = greaterThanX[i];
        }
        return head;
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

    ListNode l(1);
    l.next = new ListNode(4);
    l.next->next = new ListNode(3);
    l.next->next->next = new ListNode(2);

    s.partition(&l, 3);
}
