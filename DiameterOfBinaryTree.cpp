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
    tuple<int, int> recur(TreeNode *root)
    {
        if (root->left == NULL && root->right == NULL)
        {
            return make_tuple(1, 1);
        }
        tuple<int, int> left = make_tuple(0, 0), right = make_tuple(0, 0);
        if (root->left != NULL)
        {
            left = recur(root->left);
        }
        if (root->right != NULL)
        {
            right = recur(root->right);
        }
        return make_tuple(1+max(get<0>(left), get<0>(right)), max(1+get<0>(left) + get<0>(right), max(get<1>(left), get<1>(right))));
    }
public:
    int diameterOfBinaryTree(TreeNode *root)
    {
        return get<1>(recur(root))-1;
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
