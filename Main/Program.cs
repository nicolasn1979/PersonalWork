using System;
using TextAnalyser;
using System.Linq;

namespace Main
{
    class Program
    {
        static void Main(string[] args)
        {
            String[] input = "The quick brown fox jumped over the lazy brown dog’s back".Split(' ');
            LaunchBinaryTreeOrdering(input);
            LaunchThreadedTreeOrdering(input);
            LaunchLinqOrdering(input);

            Console.ReadKey();
        }

        /// <summary>
        /// Order the words using a Binary Search Tree
        /// </summary>
        /// <param name="input">the words to order</param>
        static void LaunchBinaryTreeOrdering(String[] input)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();

            TextAnalyser.BinarySearchTree.BinarySearchTree binarySearchTree = new TextAnalyser.BinarySearchTree.BinarySearchTree();
            foreach (var i in input)
                binarySearchTree.Insert(new Item(i));
            binarySearchTree.Traverse();

            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;

            binarySearchTree.ShowReport();
            Console.WriteLine($"LaunchBinaryTreeOrdering - Result fetched in {elapsedMs} ms\n");
        }

        /// <summary>
        /// Order the words using a Threaded Tree
        /// </summary>
        /// <param name="input">the words to order</param>
        static void LaunchThreadedTreeOrdering(String[] input)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();

            TextAnalyser.ThreadedTree.ThreadedTree threadedTree = new TextAnalyser.ThreadedTree.ThreadedTree();
            foreach (var i in input)
                threadedTree.Insert(new Item(i));
            threadedTree.Traverse();

            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            
            threadedTree.ShowReport();
            Console.WriteLine($"LaunchThreadedTreeOrdering - Result fetched in {elapsedMs} ms\n");
        }

        /// <summary>
        ///  Order the words using Linq, Collection...
        /// </summary>
        /// <param name="input">the words to order</param>
        static void LaunchLinqOrdering(String[] input)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            
            var items = input.Select(x => new Item(x)).ToList();
            var result = items.GroupBy(i => i.Value)
                              .Select(i => new { Item = new Item(i.Key), Count = i.Count() })
                              .OrderBy(x => x.Item, new LengthThenAsciiComparer());

            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;

            // Show the 'Report'
            foreach (var x in result)
                Console.WriteLine($"{x.Count} {x.Item.ToString()}");

            Console.WriteLine($"LaunchLinqOrdering - Result fetched in {elapsedMs} ms\n");
        }

    }
}
