using System;
using System.Collections.Generic;

namespace LRUCache
{
  class Program
  {
    static void Main(string[] args) {
      LRUCache lRUCache = new LRUCache(2);
      lRUCache.Put(1, 1); // cache is {1=1}
      lRUCache.Put(2, 2); // cache is {1=1, 2=2}
      Console.WriteLine(lRUCache.Get(1) == 1);
      lRUCache.Put(3, 3); // LRU key was 2, evicts key 2, cache is {1=1, 3=3}
      Console.WriteLine(lRUCache.Get(2) == -1);
      lRUCache.Put(4, 4); // LRU key was 1, evicts key 1, cache is {4=4, 3=3}
      Console.WriteLine(lRUCache.Get(1) == -1);
      Console.WriteLine(lRUCache.Get(3) == 3);
      Console.WriteLine(lRUCache.Get(4) == 4);
      lRUCache.Put(4, 14);  // LRU key was 1, evicts key 1, cache is {4=14, 3=3}
      Console.WriteLine(lRUCache.Get(6) == -1);
      Console.WriteLine(lRUCache.Get(3) == 3);
      Console.WriteLine(lRUCache.Get(4) == 14);
    }

    #region MyRegion

    public class LRUCache
    {
      class KeyValuePair
      {
        public int Key { get; set; }
        public int Value { get; set; }
      }

      private int capacity;
      private LinkedList<KeyValuePair> linkedList;
      private Dictionary<int, LinkedListNode<KeyValuePair>> dict;

      public LRUCache(int capacity) {
        this.capacity = capacity;
        this.linkedList = new LinkedList<KeyValuePair>();
        this.dict = new Dictionary<int, LinkedListNode<KeyValuePair>>();
      }

      public int Get(int key) {
        int value = -1;
        if (dict.ContainsKey(key)) {
          value = dict[key].Value.Value;
          updateCache(key);
        }
        return value;
      }

      private void updateCache(int key) {
        var node = dict[key];
        var newNode = new KeyValuePair() { Key = node.Value.Key, Value = node.Value.Value };
        linkedList.Remove(node);
        linkedList.AddFirst(newNode);
        dict[key] = linkedList.First;
      }

      public void Put(int key, int value) {
        if (dict.ContainsKey(key)) {
          dict[key].Value.Value = value;
          updateCache(key);
        } else {
          var node = new LinkedListNode<KeyValuePair>(new KeyValuePair() { Key = key, Value = value });
          linkedList.AddFirst(node);
          dict.Add(key, node);
          if (linkedList.Count > capacity) {
            var last = linkedList.Last.Value;
            linkedList.RemoveLast();
            dict.Remove(last.Key);
          }
        }
      }
    }

    /**
     * Your LRUCache object will be instantiated and called as such:
     * LRUCache obj = new LRUCache(capacity);
     * int param_1 = obj.Get(key);
     * obj.Put(key,value);
     */


    #endregion
  }
}
