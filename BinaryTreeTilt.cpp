#include <iostream>
#include <string>
#include <algorithm>
#include <vector>
#include <map>
#include <queue>
#include <math.h>
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
    tuple<int, int> findTilt1(TreeNode *node)
    {
        if (node == NULL)
        {
            return make_tuple(0, 0);
        }
        auto left = findTilt1(node->left);
        auto right = findTilt1(node->right);
        auto tilteRoot = abs(get<0>(left) - get<0>(right));
        return make_tuple(node->val + get<0>(left) + get<0>(right), get<1>(left) + get<1>(right) + tilteRoot);
    }

public:
    int findTilt(TreeNode *root)
    {
        return get<1>(findTilt1(root));
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

    TreeNode *t1 = new TreeNode(1);
    t1->left = new TreeNode(2);
    t1->right = new TreeNode(3);
    s.findTilt(t1);
}
