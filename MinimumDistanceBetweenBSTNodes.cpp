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
private:
    TreeNode *getLeftMost(TreeNode *root)
    {
        while (root != NULL && root->left != NULL)
        {
            root = root->left;
        }
        return root;
    }
    TreeNode *getRightMost(TreeNode *root)
    {
        while (root != NULL && root->right != NULL)
        {
            root = root->right;
        }
        return root;
    }
public:
    int minDiffInBST(TreeNode *root)
    {
        if (root == NULL)
        {
            return INT32_MAX;
        }
        int leftMin = minDiffInBST(root->left);
        int rightMin = minDiffInBST(root->right);
        TreeNode *leftMost, *rightMost;
        leftMost = getLeftMost(root->right);
        rightMost = getRightMost(root->left);
        int diffRootWithLeft = leftMost != NULL ? abs(root->val - leftMost->val) : INT32_MAX;
        int diffRootWithRight = rightMost != NULL ? abs(root->val - rightMost->val) : INT32_MAX;
        return min(min(diffRootWithLeft, diffRootWithRight), min(leftMin, rightMin));
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
