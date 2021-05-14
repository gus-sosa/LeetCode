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

// Definition for a Node.
class Node
{
public:
    int val;
    vector<Node *> children;

    Node() {}

    Node(int _val)
    {
        val = _val;
    }

    Node(int _val, vector<Node *> _children)
    {
        val = _val;
        children = _children;
    }
};

class Solution
{
public:
    int maxDepth(Node *root)
    {
        queue<pair<Node *, int>> q{};
        q.push(make_pair(root, 1));
        int depth = 0;
        pair<Node *, int> p;
        Node *c;
        int cl;
        while (!q.empty())
        {
            p = q.front();
            q.pop();
            cl = p.second;
            c = p.first;
            if (c == NULL)
            {
                continue;
            }
            depth = max(cl, depth);
            for (auto &&i : c->children)
            {
                q.push(make_pair(i, cl + 1));
            }
        }
        return depth;
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
