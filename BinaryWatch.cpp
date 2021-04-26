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
#include <unordered_map>
using namespace std;

class Solution
{
private:
    void buildAllTimeRepresentations(int turnedOn, int pos, int currentRepresentation, vector<int> &representations)
    {
        if (turnedOn == 0 || pos >= 10)
        {
            if (turnedOn == 0)
            {
                representations.push_back(currentRepresentation);
            }
            return;
        }
        buildAllTimeRepresentations(turnedOn, pos + 1, currentRepresentation, representations);
        currentRepresentation |= (1 << pos);
        buildAllTimeRepresentations(turnedOn - 1, pos + 1, currentRepresentation, representations);
    }
    string TimeRepresentationToString(int t)
    {
        int minutes = 0, hours = 0;
        for (int i = 0; i < 6; i++)
        {
            if (t & (1 << i))
            {
                minutes += 1 << i;
            }
        }
        for (int i = 0; i < 6; i++)
        {
            t >>= 1;
        }
        for (int i = 0; i < 4; i++)
        {
            if (t & (1 << i))
            {
                hours += 1 << i;
            }
        }
        if (minutes > 59 || hours > 11)
        {
            return "";
        }
        stringstream ss{};
        ss << hours << ":";
        if (minutes < 10)
        {
            ss << 0;
        }
        ss << minutes;
        return ss.str();
    }

public:
    vector<string> readBinaryWatch(int turnedOn)
    {
        vector<int> representations{};
        buildAllTimeRepresentations(turnedOn, 0, 0, representations);
        vector<string> result{};
        for (auto &&i : representations)
        {
            string r = TimeRepresentationToString(i);
            if (r != "")
            {
                result.push_back(r);
            }
        }
        return result;
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
    return 0;
}
