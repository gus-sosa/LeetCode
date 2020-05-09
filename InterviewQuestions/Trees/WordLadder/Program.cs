using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace WordLadder {
  class Program {
    static void Main(string[] args) {
      var s = new Solution();
      var wordList = new List<string>() { "hot", "dog", "dot", "lot", "log", "cog" };
      Console.WriteLine(s.LadderLength("hit", "cog", wordList) == 5);
      wordList.Remove("cog");
      Console.WriteLine(s.LadderLength("hit", "cog", wordList) == 0);
    }
  }

  #region MyRegion


  public class Solution {
    public int LadderLength(string beginWord, string endWord, IList<string> wordList) {
      var map = buildMap(beginWord, wordList);
      if (!map.ContainsKey(endWord)) {
        return 0;
      }
      return bfs(beginWord, endWord, map);
    }

    private int bfs(string beginWord, string endWord, Dictionary<string, List<string>> map) {
      var q = new Queue<Tuple<string, int>>();
      var v = new Dictionary<string, int>();
      v[beginWord] = 1;
      q.Enqueue(Tuple.Create(beginWord, 1));
      while (q.Count > 0) {
        var t = q.Dequeue();
        var w = t.Item1;
        var l = t.Item2;
        if (string.Equals(w, endWord)) {
          return l;
        }
        foreach (var tranformation in map[w]) {
          if (!v.ContainsKey(tranformation) || v[tranformation] > l + 1) {
            q.Enqueue(Tuple.Create(tranformation, l + 1));
            v[tranformation] = l + 1;
          }
        }
      }
      return 0;
    }

    private Dictionary<string, List<string>> buildMap(string beginWord, IList<string> wordList) {
      int l = beginWord.Length;
      Dictionary<string, List<string>> map = new Dictionary<string, List<string>>();
      HashSet<char>[] arr = new HashSet<char>[l];
      for (int i = 0; i < l; ++i) {
        arr[i] = new HashSet<char>();
      }
      foreach (var item in wordList) {
        map[item] = new List<string>();
        for (int i = 0; i < l; ++i) {
          arr[i].Add(item[i]);
        }
      }
      foreach (var key in map.Keys) {
        foreach (var item in getTransformations(key, arr)) {
          if (map.ContainsKey(item)) {
            map[key].Add(item);
          }
        }
      }

      if (!wordList.Contains(beginWord)) {
        var transformations = new List<string>();
        foreach (var item in getTransformations(beginWord, arr)) {
          if (map.ContainsKey(item)) {
            transformations.Add(item);
          }
        }
        map[beginWord] = transformations;
      }

      return map;
    }

    private IEnumerable<string> getTransformations(string word, HashSet<char>[] letters) {
      for (int i = 0; i < word.Length; ++i) {
        var set = letters[i];
        foreach (var c in set) {
          if (c != word[i]) {
            yield return word.Substring(0, i) + c + word.Substring(i + 1);
          }
        }
      }
    }
  }


  #endregion
}
