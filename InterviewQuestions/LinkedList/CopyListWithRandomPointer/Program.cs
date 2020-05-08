using System;
using System.Collections.Generic;
using System.Linq;

namespace CopyListWithRandomPointer {
  class Program {
    static void Main(string[] args) {
      Node list = buildList("7,-1;13,0;11,-1;10,2;1,0");
      var s = new Solution();
      s.CopyRandomList(list);
    }

    private static Node buildList(string v) {
      var pairs = v.Split(';').Select(i => Tuple.Create(int.Parse(i.Split(',')[0]), int.Parse(i.Split(',')[1]))).ToList();
      var nodes = pairs.Select(i => new Node(i.Item1)).ToList();
      for (int i = 0; i < nodes.Count; ++i) {
        if (i != nodes.Count - 1) {
          nodes[i].next = nodes[i + 1];
        }
        if (pairs[i].Item2 != -1) {
          nodes[i].random = nodes[pairs[i].Item2];
        }
      }
      return nodes[0];
    }
  }

  /*
// Definition for a Node.*/
  public class Node {
    public int val;
    public Node next;
    public Node random;

    public Node(int _val) {
      val = _val;
      next = null;
      random = null;
    }
  }


  #region MyRegion


  public class Solution {
    public Node CopyRandomList(Node head) {
      var map = new Dictionary<Node, Node>();
      Node headNewList = null, tailNewList = null, current = head, newNode;
      while (current != null) {
        newNode = new Node(current.val);
        if (tailNewList == null) {
          headNewList = tailNewList = newNode;
        } else {
          tailNewList.next = newNode;
          tailNewList = tailNewList.next;
        }
        map.Add(current, newNode);
        current = current.next;
      }
      current = head;
      while (current != null) {
        if (current.random != null) {
          map[current].random = map[current.random];
        }
        current = current.next;
      }
      return headNewList;
    }
  }


  #endregion
}
