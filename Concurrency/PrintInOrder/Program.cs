using System;
using System.Linq;
using System.Threading;

namespace PrintInOrder {
  class Program {
    public class Foo {
      private object _firstLock = new object();
      private bool _first = false;
      private object _secondLock = new object();
      private bool _second = false;
      private const int WAIT = 1000;

      public Foo() {

      }

      private void TakeFlag(Random random, object flag) {
        while (!Monitor.TryEnter(flag, WAIT)) {
          Thread.Sleep(Convert.ToInt32(Math.Ceiling(WAIT + WAIT * random.NextDouble())));
        }
      }

      public void First(Action printFirst) {
        printFirst();
        var random = new Random();
        TakeFlag(random, _firstLock);
        _first = true;
        Monitor.Exit(_firstLock);
      }

      public void Second(Action printSecond) {
        var random = new Random();
        while (true) {
          TakeFlag(random, _firstLock);
          if (_first) {
            break;
          }
          Monitor.Exit(_firstLock);
        }
        printSecond();
        Monitor.Exit(_firstLock);
        TakeFlag(random, _secondLock);
        _second = true;
        Monitor.Exit(_secondLock);
      }

      public void Third(Action printThird) {
        var random = new Random();
        while (true) {
          TakeFlag(random, _secondLock);
          if (_second) {
            break;
          }
          Monitor.Exit(_secondLock);
        }
        printThird();
        Monitor.Exit(_secondLock);
      }
    }
    static void Main(string[] args) {
      var random = new Random();
      var commonInstance = new Foo();
      var threads = new Thread[3];
      threads[0] = new Thread(new ThreadStart(() => commonInstance.First(() => Console.WriteLine("first"))));
      threads[1] = new Thread(new ThreadStart(() => commonInstance.Second(() => Console.WriteLine("second"))));
      threads[2] = new Thread(new ThreadStart(() => commonInstance.Third(() => Console.WriteLine("third"))));
      threads = threads.OrderBy(x => random.Next()).ToArray();
      for (int i = 0; i < threads.Length; i++) {
        threads[i].Start();
      }
      for (int i = 0; i < threads.Length; i++) {
        threads[i].Join();
      }
      Console.WriteLine("END");
    }
  }
}
