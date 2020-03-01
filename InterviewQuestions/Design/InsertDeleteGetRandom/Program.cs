using System;
using System.Collections.Generic;

namespace InsertDeleteGetRandom {
  class Program {
    static void Main(string[] args) {
      RandomizedSet obj = new RandomizedSet();
      Console.WriteLine(obj.Insert(0));
      Console.WriteLine(obj.Insert(1));
      Console.WriteLine(obj.Remove(0));
      Console.WriteLine(obj.Insert(2));
      Console.WriteLine(obj.Remove(1));
      Console.WriteLine(obj.GetRandom());
      //Console.WriteLine(obj.Remove(1));
      //Console.WriteLine(obj.Insert(2));
      //Console.WriteLine(obj.Remove(1));
      //Console.WriteLine(obj.Insert(1));
      //Console.WriteLine(obj.Insert(1));
      //Console.WriteLine(obj.GetRandom());
      //Console.WriteLine(obj.GetRandom());
    }

    #region MyRegion


    public class RandomizedSet {

      private LinkedList<int> _elements;
      private Dictionary<int, int> _numPosition;
      private Dictionary<int, LinkedListNode<int>> _positionNode;
      private Random _random;

      /** Initialize your data structure here. */
      public RandomizedSet() {
        this._elements = new LinkedList<int>();
        this._numPosition = new Dictionary<int, int>();
        this._positionNode = new Dictionary<int, LinkedListNode<int>>();
        this._random = new Random();
      }

      /** Inserts a value to the set. Returns true if the set did not already contain the specified element. */
      public bool Insert(int val) {
        if (_numPosition.ContainsKey(val)) {
          return false;
        } else {
          _elements.AddLast(val);
          _positionNode[_elements.Count] = _elements.Last;
          _numPosition[val] = _elements.Count;
          return true;
        }
      }

      /** Removes a value from the set. Returns true if the set contained the specified element. */
      public bool Remove(int val) {
        if (_numPosition.ContainsKey(val)) {
          int position = _numPosition[val];
          _numPosition.Remove(val);
          if (position != _elements.Count) {
            LinkedListNode<int> valNode = _positionNode[position];
            _elements.AddAfter(valNode, _elements.Last.Value);
            _positionNode[position] = valNode.Next;
            _numPosition[valNode.Next.Value] = position;
            _elements.Remove(valNode);
          }
          _positionNode.Remove(_elements.Count);
          _elements.RemoveLast();
          return true;
        } else {
          return false;
        }
      }

      /** Get a random element from the set. */
      public int GetRandom() {
        return _positionNode[_random.Next(1, _elements.Count + 1)].Value;
      }
    }

    /**
     * Your RandomizedSet object will be instantiated and called as such:
     * RandomizedSet obj = new RandomizedSet();
     * bool param_1 = obj.Insert(val);
     * bool param_2 = obj.Remove(val);
     * int param_3 = obj.GetRandom();
     */



    #endregion


  }
}
