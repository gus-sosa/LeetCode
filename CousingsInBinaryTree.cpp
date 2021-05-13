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

struct TreeNode
{
    int val;
    TreeNode *left;
    TreeNode *right;
    TreeNode() : val(0), left(nullptr), right(nullptr) {}
    TreeNode(int x) : val(x), left(nullptr), right(nullptr) {}
    TreeNode(int x, TreeNode *left, TreeNode *right) : val(x), left(left), right(right) {}
};

class Solution
{
public:
    bool isCousins(TreeNode *root, int x, int y)
    {
        queue<tuple<TreeNode *, TreeNode *, int>> q{};
        int levelX = -1, levelY = -1, level;
        TreeNode *t, *p, *parentX, *parentY;
        tuple<TreeNode *, TreeNode *, int> c{root, NULL, 0};
        q.push(c);
        while (!q.empty() && (levelX == -1 || levelY == -1))
        {
            c = q.front();
            q.pop();
            t = get<0>(c);
            p = get<1>(c);
            level = get<2>(c);
            if (t->val == x)
            {
                parentX = p;
                levelX = level;
            }
            if (t->val == y)
            {
                parentY = p;
                levelY = level;
            }
            if (t->left != NULL)
            {
                c = {t->left, t, level + 1};
                q.push(c);
            }
            if (t->right != NULL)
            {
                c = {t->right, t, level + 1};
                q.push(c);
            }
        }
        return levelX == levelY && parentX != parentY;
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
    TreeNode *root;
    root = new TreeNode(1);
    root->left = new TreeNode(2);
    root->right = new TreeNode(3);
    cout << (s.isCousins(root, 2, 3) == false) << endl;
}
