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

class Node
{
public:
    int data;
    Node *next;
};

class Solution
{
private:
    Node *buildLinkedList(vector<int> arr)
    {
        Node *head = new Node();
        head->data = arr[1];
        Node *current = head;
        for (int i = 2; i < arr.size(); i++)
        {
            current->next = new Node();
            current = current->next;
            current->data = arr[i];
        }
        return head;
    }
    Node *getLast(Node *head)
    {
        Node *current = head;
        Node *result = current;
        while (current != NULL)
        {
            result = current;
            current = current->next;
        }
        return result;
    }

public:
    int getWinner(vector<int> &arr, int k)
    {
        int best = max(arr[0], arr[1]);
        int maxNum = *max_element(arr.begin(), arr.end());
        int winCount = 0;
        Node *head = buildLinkedList(arr);
        Node *last = getLast(head);
        while (winCount < k && best != maxNum)
        {
            auto nn = new Node();
            if (best >= head->data)
            {
                ++winCount;
                nn->data = head->data;
            }
            else
            {
                nn->data = best;
                winCount = 1;
                best = head->data;
            }
            last->next = nn;
            last = last->next;
            auto tmp = head;
            head = tmp->next;
            delete tmp;
        }
        return best;
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

    vector<int> v1{2, 1, 3, 5, 4, 6, 7};
    cout << (s.getWinner(v1, 2) == 5) << endl;

    vector<int> v2{3, 2, 1};
    cout << (s.getWinner(v2, 10) == 3) << endl;

    vector<int> v3{1, 9, 8, 2, 3, 7, 6, 4, 5};
    cout << (s.getWinner(v3, 7) == 9) << endl;

    vector<int> v4{1, 11, 22, 33, 44, 55, 66, 77, 88, 99};
    cout << (s.getWinner(v4, 1000000000) == 99) << endl;
}
