#include <iostream>
#include <string>
#include <algorithm>
#include <vector>
#include <map>
#include <queue>
using namespace std;

class Employee
{
public:
    int id;
    int importance;
    vector<int> subordinates;
};

class Solution
{
public:
    int getImportance(vector<Employee *> employees, int id)
    {
        map<int, Employee *> m{};
        for (auto &&i : employees)
        {
            m.insert({i->id, i});
        }
        queue<int> q{};
        q.push(id);
        int sum = 0;
        while (!q.empty())
        {
            sum += m[q.front()]->importance;
            for (auto &&i : m[q.front()]->subordinates)
            {
                q.push(i);
            }
            q.pop();
        }
        return sum;
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
