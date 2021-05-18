#include <iostream>
#include <string>
#include <algorithm>
#include <vector>
#include <map>
#include <queue>
#include <math.h>
#include <charconv>
#include <sstream>
#include <set>
#include <unordered_set>
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
private:
    void inOrder(TreeNode *root, vector<int> &l)
    {
        if (root == NULL)
        {
            return;
        }
        inOrder(root->left, l);
        l.push_back(root->val);
        inOrder(root->right, l);
    }

public:
    TreeNode *increasingBST(TreeNode *root)
    {
        vector<int> inOrderValues{};
        inOrder(root, inOrderValues);
        TreeNode *ans = new TreeNode(inOrderValues[0]), *c = ans;
        for (int i = 1; i < inOrderValues.size(); i++)
        {
            c->right = new TreeNode(inOrderValues[i]);
            c = c->right;
        }
        return ans;
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

    TreeNode *root = new TreeNode(5);
    root->left = new TreeNode(1);
    root->right = new TreeNode(7);

    s.increasingBST(root);
}
