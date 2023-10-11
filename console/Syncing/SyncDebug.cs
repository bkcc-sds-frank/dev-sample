using Microsoft.VisualStudio.TestPlatform.TestHost;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DeveloperSample.Syncing
{
    public class SyncDebug
    {
        public List<string> InitializeListUsingParallel(IEnumerable<string> items)
        {
            var bag = new ConcurrentBag<string>();
            Parallel.ForEach(items, i =>
            {
                bag.Add(i);
            });
            var list = bag.ToList();
            return list;
        }

        public List<string> InitializeListUsingTasks(IEnumerable<string> items)
        {
            var bag = new ConcurrentBag<string>();
            List<Task> tasks = new List<Task>(); //added a list of tasks
            foreach (var i in items)
            {
                tasks.Add(Task.Run(() => bag.Add(i))); //run the tasks
            }
            Task.WaitAll(tasks.ToArray()); //after all tasks have completed return, this was not being done in the original code
            var list = bag.ToList();
            return list;
        }

        ConcurrentQueue<int> itemsToInitialize = new ConcurrentQueue<int>(Enumerable.Range(1, 100));
        public Dictionary<int, string> InitializeDictionary(Func<int, string> getItem)
        {
            itemsToInitialize = new ConcurrentQueue<int>(Enumerable.Range(1, 100));
            var concurrentDictionary = new ConcurrentDictionary<int, string>();
            var threads = Enumerable.Range(0, 3)
                .Select(i => new Thread(new ThreadStart(() =>
                {
                    while (itemsToInitialize.TryDequeue(out var item))
                    {                        
                        {
                            concurrentDictionary.AddOrUpdate(item, getItem, (_, s) => s);
                        }
                    }
                })))
                .ToList();

            foreach (var thread in threads)
            {
                thread.Start();
            }
            foreach (var thread in threads)
            {
                thread.Join();
            }

            return concurrentDictionary.ToDictionary(kv => kv.Key, kv => kv.Value);
        }

        public int TestInt;
        public void TestInterlocked()
        {
            for(int i = 0; i < 100000; i++)
            {
                Interlocked.Increment(ref TestInt);
            }            
        }
    }
}