#include <iostream>
#include <string>
#include <algorithm>
#include <vector>
#include <string.h>
#include <sstream>
using namespace std;

class Solution
{
private:
    pair<int, int> getValues(string equation, int start, int end)
    {
        int a = 0, b = 0, currentNum = 0, sign = 1, initialStart = start;
        while (start <= end)
        {
            if (equation[start] == '+')
            {
                a += sign * currentNum;
                sign = 1;
                currentNum = 0;
            }
            else if (equation[start] == '-')
            {
                a += sign * currentNum;
                sign = -1;
                currentNum = 0;
            }
            else if (equation[start] == 'x')
            {
                if (start == initialStart || equation[start - 1] == '+' || equation[start - 1] == '-')
                {
                    currentNum = 1;
                }
                b += sign * currentNum;
                currentNum = 0;
            }
            else
            {
                string s = "";
                s += equation[start];
                currentNum = currentNum * 10 + stoi(s);
            }
            ++start;
        }
        a += sign * currentNum;
        return pair<int, int>(a, b);
    }

public:
    string solveEquation(string equation)
    {
        int equalIndex = equation.find('=');
        pair<int, int> leftSide = getValues(equation, 0, equalIndex - 1);
        pair<int, int> rightSide = getValues(equation, equalIndex + 1, equation.size() - 1);
        int a = leftSide.first;
        int b = leftSide.second;
        int c = rightSide.first;
        int d = rightSide.second;
        if (b == d && a == c)
        {
            return "Infinite solutions";
        }
        else if (b == d)
        {
            return "No solution";
        }
        else
        {
            stringstream ss{};
            ss << "x=";
            ss << (c - a) / (b - d);
            return ss.str();
        }
    }
};
//////////////////
void print(vector<int> &v)
{
    for (auto &&i : v)
    {
        cout << i << endl;
    }
}

int main()
{
    Solution s{Solution()};

    string s2 = "x=x";
    cout << (s.solveEquation(s2) == "Infinite solutions") << endl;

    string s1 = "x+5-3+x=6+x-2";
    cout << (s.solveEquation(s1) == "x=2") << endl;
}
