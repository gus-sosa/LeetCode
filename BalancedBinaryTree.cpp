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
    int getHeight(TreeNode *root)
    {
        if (root == NULL)
        {
            return 0;
        }
        return 1 + max(getHeight(root->left), getHeight(root->right));
    }

public:
    bool isBalanced(TreeNode *root)
    {
        if (root == NULL)
        {
            return true;
        }
        if (!isBalanced(root->left) || !isBalanced(root->right))
        {
            return false;
        }
        int leftHeight = getHeight(root->left);
        int rightHeight = getHeight(root->right);
        return abs(leftHeight - rightHeight) < 2;
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
