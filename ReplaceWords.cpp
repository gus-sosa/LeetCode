#include <iostream>
#include <string>
#include <algorithm>
#include <vector>
#include <queue>
#include <unordered_set>
using namespace std;

class Solution
{
private:
    string getBestPrefix(unordered_set<string> &s, string word)
    {
        for (int i = 0; i < word.size(); i++)
        {
            if (s.find(word.substr(0, i + 1)) != s.end())
            {
                return word.substr(0, i + 1);
            }
        }
        return word;
    }

public:
    string replaceWords(vector<string> &dictionary, string sentence)
    {
        int pos = 0, previousPos = 0;
        string result{};
        unordered_set<string> s{dictionary.begin(), dictionary.end()};
        do
        {
            previousPos = pos;
            pos = sentence.find(' ', pos);
            if (pos != -1)
            {
                --pos;
                string word = sentence.substr(previousPos, pos - previousPos + 1);
                word = getBestPrefix(s, word);
                result += " " + word;
                pos += 2;
            }
        } while (pos != -1);
        result += " " + getBestPrefix(s, sentence.substr(previousPos, sentence.size() - previousPos));
        result.erase(result.begin());
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
    Solution s{Solution()};

    vector<string> d1{"cat", "bat", "rat"};
    cout << (s.replaceWords(d1, "the cattle was rattled by the battery") == "the cat was rat by the bat") << endl;
}
