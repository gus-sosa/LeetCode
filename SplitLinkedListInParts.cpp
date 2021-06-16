#include <iostream>
#include <string>
#include <algorithm>
#include <vector>
#include <map>
#include <unordered_map>
#include <unordered_set>
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
        int count = 0;
        while (head != NULL)
        {
            ++count;
            head = head->next;
        }
        return count;
    }
    vector<ListNode *> simpleList(ListNode *head, int k)
    {
        vector<ListNode *> result{};
        for (int i = 0; i < k; i++)
        {
            if (head == NULL)
            {
                result.push_back(NULL);
            }
            else
            {
                result.push_back(head);
                auto tmp = head->next;
                head->next = NULL;
                head = tmp;
            }
        }
        return result;
    }
    vector<ListNode *> notSimpleList(ListNode *head, int k, int l)
    {
        vector<ListNode *> result{};
        result.push_back(head);
        int res = l % k;
        int div = l / k;
        int c = 0;
        ++div;
        for (int i = 0; i < res; i++)
        {
            c = 0;
            while (c < div)
            {
                if (c + 1 == div)
                {
                    auto tmp = head->next;
                    head->next = NULL;
                    head = tmp;
                    result.push_back(head);
                }
                else
                {
                    head = head->next;
                }
                ++c;
            }
        }
        --div;
        res = k - res;
        for (int i = 0; i < res; i++)
        {
            c = 0;
            while (c < div)
            {
                if (c + 1 == div)
                {
                    auto tmp = head->next;
                    head->next = NULL;
                    head = tmp;
                    result.push_back(head);
                }
                else
                {
                    head = head->next;
                }
                ++c;
            }
        }
        if (result.size() != k)
        {
            result.pop_back();
        }
        return result;
    }

public:
    vector<ListNode *> splitListToParts(ListNode *head, int k)
    {
        int l = getLength(head);
        if (l < k)
        {
            return simpleList(head, k);
        }
        else
        {
            return notSimpleList(head, k, l);
        }
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
