#include <iostream>
#include <string>
#include <algorithm>
#include <vector>
#include <map>
#include <queue>
#include <math.h>
#include <charconv>
#include <sstream>
#include <unordered_map>
#include <unordered_set>
using namespace std;

class Solution
{
private:
    vector<int> getKthFriends(vector<vector<int>> &friends, int id, int level)
    {
        queue<pair<int, int>> q{};
        q.push(pair<int, int>(0, id));
        vector<int> result{};
        unordered_set<int> s{};
        unordered_set<int> inResult{};
        s.insert(id);
        while (q.size() > 0)
        {
            auto top = q.front();
            q.pop();
            if (top.first == level)
            {
                if (inResult.find(top.second) == inResult.end())
                {
                    result.push_back(top.second);
                    inResult.insert(top.second);
                }
            }
            else
            {
                for (auto &&i : friends[top.second])
                {
                    if (s.find(i) == s.end())
                    {
                        q.push(pair<int, int>(top.first + 1, i));
                        s.insert(i);
                    }
                }
            }
        }
        return result;
    }
    unordered_map<string, int> getMoviesFrequencies(vector<vector<string>> &watchedVideos, vector<int> friends)
    {
        unordered_map<string, int> m{};
        for (auto &&i : friends)
        {
            auto videos = watchedVideos[i];
            for (auto &&ii : videos)
            {
                if (m.find(ii) == m.end())
                {
                    m.insert(pair<string, int>(ii, 0));
                }
                ++m[ii];
            }
        }
        return m;
    }
    vector<string> getMoviesSortedByFrequency(unordered_map<string, int> m)
    {
        vector<string> result{};
        for (auto &&i : m)
        {
            result.push_back(i.first);
        }
        sort(result.begin(), result.end(), [&](const string &a, const string &b) -> bool
             { return m[a] == m[b] ? (a.compare(b) < 0) : (m[a] < m[b]); });
        return result;
    }

public:
    vector<string> watchedVideosByFriends(vector<vector<string>> &watchedVideos, vector<vector<int>> &friends, int id, int level)
    {
        vector<int> friendInPosK = getKthFriends(friends, id, level);
        unordered_map<string, int> moviesFrequencies = getMoviesFrequencies(watchedVideos, friendInPosK);
        return getMoviesSortedByFrequency(moviesFrequencies);
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
    //[["bjwtssmu"],["aygr","mqls"],["vrtxa","zxqzeqy","nbpl","qnpl"],["r","otazhu","rsf"],["bvcca","ayyihidz","ljc","fiq","viu"]]
    //[[3,2,1,4],[0,4],[4,0],[0,4],[2,3,1,0]]
    //3
    //1

    Solution s{};

    vector<vector<string>> v1{vector<string>{"bjwtssmu"}, vector<string>{"aygr", "mqls"}, vector<string>{"vrtxa", "zxqzeqy", "nbpl", "qnpl"}, vector<string>{"r", "otazhu", "rsf"}, vector<string>{"bvcca", "ayyihidz", "ljc", "fiq", "viu"}};
    vector<vector<int>> f1{vector<int>{3, 2, 1, 4}, vector<int>{0, 4}, vector<int>{4, 0}, vector<int>{0, 4}, vector<int>{2, 3, 1, 0}};
    s.watchedVideosByFriends(v1, f1, 3, 1);

    vector<vector<string>> v2{vector<string>{"xk", "qvgjjsp", "sbphxzm"}, vector<string>{"rwyvxl", "ov"}};
    vector<vector<int>> f2{vector<int>{1}, vector<int>{0}};
    s.watchedVideosByFriends(v2, f2, 0, 1);

    return 0;
}
