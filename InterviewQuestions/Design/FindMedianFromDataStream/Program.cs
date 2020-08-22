using System;
using System.Collections.Generic;

namespace FindMedianFromDataStream {
  class Program {
    static void Main(string[] args) {
      var m = new MedianFinder();
      m.AddNum(6);
      m.AddNum(10);
      m.AddNum(2);
      m.AddNum(6);
      Console.WriteLine(m.FindMedian());
      m.AddNum(5);
      Console.WriteLine(m.FindMedian());
    }
  }

  #region MyRegion


  public class MedianFinder {
    private PriorityQueue<int> leftSet;
    private PriorityQueue<int> rightSet;

    /** initialize your data structure here. */
    public MedianFinder() {
      this.leftSet = new PriorityQueue<int>();
      this.rightSet = new PriorityQueue<int>();
    }

    public void AddNum(int num) {
      leftSet.Enqueue(-num);
      while (leftSet.Count() > 0 && rightSet.Count() > 0 && max(leftSet) > min(rightSet)) {
        rightSet.Enqueue(max(leftSet));
        leftSet.Dequeue();
      }
      while (Math.Abs(leftSet.Count() - rightSet.Count()) > 1) {
        if (leftSet.Count() > rightSet.Count()) {
          rightSet.Enqueue(-leftSet.Dequeue());
        } else {
          leftSet.Enqueue(-rightSet.Dequeue());
        }
      }
    }

    private int min(PriorityQueue<int> list) {
      return list.Peek();
    }

    private int max(PriorityQueue<int> list) {
      return -list.Peek();
    }

    public double FindMedian() {
      if (Count % 2 == 0) {
        return (max(leftSet) + min(rightSet)) / 2d;
      }
      return leftSet.Count() > rightSet.Count() ? max(leftSet) : min(rightSet);
    }

    private int Count {
      get {
        return leftSet.Count() + rightSet.Count();
      }
    }
  }

  /**
   * Your MedianFinder object will be instantiated and called as such:
   * MedianFinder obj = new MedianFinder();
   * obj.AddNum(num);
   * double param_2 = obj.FindMedian();
   */


  #region priority queue

  public class PriorityQueue<T> where T : IComparable<T> {
    private List<T> data;

    public PriorityQueue() {
      this.data = new List<T>();
    }

    public void Enqueue(T item) {
      data.Add(item);
      int ci = data.Count - 1; // child index; start at end
      while (ci > 0) {
        int pi = (ci - 1) / 2; // parent index
        if (data[ci].CompareTo(data[pi]) >= 0) break; // child item is larger than (or equal) parent so we're done
        T tmp = data[ci]; data[ci] = data[pi]; data[pi] = tmp;
        ci = pi;
      }
    }

    public T Dequeue() {
      // assumes pq is not empty; up to calling code
      int li = data.Count - 1; // last index (before removal)
      T frontItem = data[0];   // fetch the front
      data[0] = data[li];
      data.RemoveAt(li);

      --li; // last index (after removal)
      int pi = 0; // parent index. start at front of pq
      while (true) {
        int ci = pi * 2 + 1; // left child index of parent
        if (ci > li) break;  // no children so done
        int rc = ci + 1;     // right child
        if (rc <= li && data[rc].CompareTo(data[ci]) < 0) // if there is a rc (ci + 1), and it is smaller than left child, use the rc instead
          ci = rc;
        if (data[pi].CompareTo(data[ci]) <= 0) break; // parent is smaller than (or equal to) smallest child so done
        T tmp = data[pi]; data[pi] = data[ci]; data[ci] = tmp; // swap parent and child
        pi = ci;
      }
      return frontItem;
    }

    public T Peek() {
      T frontItem = data[0];
      return frontItem;
    }

    public int Count() {
      return data.Count;
    }

    public override string ToString() {
      string s = "";
      for (int i = 0; i < data.Count; ++i)
        s += data[i].ToString() + " ";
      s += "count = " + data.Count;
      return s;
    }

    public bool IsConsistent() {
      // is the heap property true for all data?
      if (data.Count == 0) return true;
      int li = data.Count - 1; // last index
      for (int pi = 0; pi < data.Count; ++pi) // each parent index
      {
        int lci = 2 * pi + 1; // left child index
        int rci = 2 * pi + 2; // right child index

        if (lci <= li && data[pi].CompareTo(data[lci]) > 0) return false; // if lc exists and it's greater than parent then bad.
        if (rci <= li && data[pi].CompareTo(data[rci]) > 0) return false; // check the right child too.
      }
      return true; // passed all checks
    } // IsConsistent
  } // PriorityQueue



  #endregion

  #endregion


}
