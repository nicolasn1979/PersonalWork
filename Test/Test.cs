using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TextAnalyser;
using TextAnalyser.BinarySearchTree;
using TextAnalyser.ThreadedTree;
using System.Collections.Generic;

namespace Test
{
    [TestClass]
    public class Test
    {
        [TestMethod]
        public void BinarySearchTreeInsertRoot()
        {
            BinarySearchTree binarySearchTree = new BinarySearchTree();
            binarySearchTree.Insert(new Item("root"));

            Assert.IsTrue(binarySearchTree.Root != null);
            Assert.IsTrue(binarySearchTree.Root.Item != null);
            Assert.IsTrue(binarySearchTree.Root.Item.Value == "root");
        }

        [TestMethod]
        public void BinarySearchTreeInsert()
        {
            BinarySearchTree binarySearchTree = new BinarySearchTree();
            binarySearchTree.Insert(new Item("The"));
            Assert.IsTrue(((BinarySearchNode)binarySearchTree.Root).Left == null);
            Assert.IsTrue(((BinarySearchNode)binarySearchTree.Root).Right == null);

            binarySearchTree.Insert(new Item("quick"));
            Assert.IsTrue(((BinarySearchNode)binarySearchTree.Root).Left == null);
            Assert.IsTrue(((BinarySearchNode)binarySearchTree.Root).Right != null);
            Assert.IsTrue(((BinarySearchNode)binarySearchTree.Root).Right.Item.Value == "quick");

            binarySearchTree.Insert(new Item("brown"));
            Assert.IsTrue(((BinarySearchNode)binarySearchTree.Root).Right.Left != null);
            Assert.IsTrue(((BinarySearchNode)binarySearchTree.Root).Right.Right == null);
            Assert.IsTrue(((BinarySearchNode)binarySearchTree.Root).Right.Left.Item.Value == "brown");

            binarySearchTree.Insert(new Item("fox"));
            Assert.IsTrue(((BinarySearchNode)binarySearchTree.Root).Right.Left.Left != null);
            Assert.IsTrue(((BinarySearchNode)binarySearchTree.Root).Right.Left.Left.Item.Value == "fox");

            binarySearchTree.Insert(new Item("dog's"));
            Assert.IsTrue(((BinarySearchNode)binarySearchTree.Root).Right.Left.Right != null);
            Assert.IsTrue(((BinarySearchNode)binarySearchTree.Root).Right.Left.Right.Item.Value == "dog's");

        }

        [TestMethod]
        public void BinarySearchTreeTraverse()
        {
            String[] input = "The quick brown fox jumped over the lazy brown dog's back".Split(' ');
            List<Tuple<int, String>> output = InitOutput();

            BinarySearchTree binarySearchTree = new BinarySearchTree();
            foreach(var i in input)
                binarySearchTree.Insert(new Item(i));
            binarySearchTree.Traverse();

            for (int i = 0; i < binarySearchTree.Report.Count; i++)
            {
                Assert.IsTrue(binarySearchTree.Report[i].Count == output[i].Item1);
                Assert.IsTrue(binarySearchTree.Report[i].Item.Value == output[i].Item2);
            }
        }

        private List<Tuple<int, String>> InitOutput()
        {
            List<Tuple<int, String>> mylist = new List<Tuple<int, String>>();
            mylist.Add(new Tuple<int, string>(1, "The"));
            mylist.Add(new Tuple<int, string>(1, "fox"));
            mylist.Add(new Tuple<int, string>(1, "the"));
            mylist.Add(new Tuple<int, string>(1, "back"));
            mylist.Add(new Tuple<int, string>(1, "lazy"));
            mylist.Add(new Tuple<int, string>(1, "over"));
            mylist.Add(new Tuple<int, string>(2, "brown"));
            mylist.Add(new Tuple<int, string>(1, "dog's"));
            mylist.Add(new Tuple<int, string>(1, "quick"));
            mylist.Add(new Tuple<int, string>(1, "jumped"));
            return mylist;
        }

        [TestMethod]
        public void ThreadedTreeInsertRoot()
        {
            TextAnalyser.ThreadedTree.ThreadedTree threadedSearchTree = new TextAnalyser.ThreadedTree.ThreadedTree();
            threadedSearchTree.Insert(new Item("root"));

            Assert.IsTrue(threadedSearchTree.Root != null);
            Assert.IsTrue(threadedSearchTree.Root.Item != null);
            Assert.IsTrue(threadedSearchTree.Root.Item.Value == "root");
        }

        [TestMethod]
        public void ThreadedTreeInsert()
        {
            ThreadedTree threadedTree = new ThreadedTree();
            threadedTree.Insert(new Item("The"));
            Assert.IsTrue(((ThreadedNode)threadedTree.Root).Left == null);
            Assert.IsTrue(((ThreadedNode)threadedTree.Root).Right == null);

            threadedTree.Insert(new Item("quick"));
            Assert.IsTrue(((ThreadedNode)threadedTree.Root).Left == null);
            Assert.IsTrue(((ThreadedNode)threadedTree.Root).Right != null);
            Assert.IsTrue(((ThreadedNode)threadedTree.Root).RightThread == false);
            Assert.IsTrue(((ThreadedNode)threadedTree.Root).Right.Item.Value == "quick");

            threadedTree.Insert(new Item("brown"));
            Assert.IsTrue(((ThreadedNode)threadedTree.Root).Right.Left != null);
            Assert.IsTrue(((ThreadedNode)threadedTree.Root).Right.Right == null);
            Assert.IsTrue(((ThreadedNode)threadedTree.Root).Right.Left.RightThread == true);
            Assert.IsTrue(((ThreadedNode)threadedTree.Root).Right.Left.Right.Item.Value == "quick");
            Assert.IsTrue(((ThreadedNode)threadedTree.Root).Right.Left.Item.Value == "brown");

            threadedTree.Insert(new Item("fox"));
            Assert.IsTrue(((ThreadedNode)threadedTree.Root).Right.Left.Left != null);
            Assert.IsTrue(((ThreadedNode)threadedTree.Root).Right.Left.Right != null);
            Assert.IsTrue(((ThreadedNode)threadedTree.Root).Right.Left.Left.RightThread == true);
            Assert.IsTrue(((ThreadedNode)threadedTree.Root).Right.Left.Left.Right.Item.Value == "brown");
            Assert.IsTrue(((ThreadedNode)threadedTree.Root).Right.Left.Left.Item.Value == "fox");

            threadedTree.Insert(new Item("dog's"));
            Assert.IsTrue(((ThreadedNode)threadedTree.Root).Right.Left.Right != null);
            Assert.IsTrue(((ThreadedNode)threadedTree.Root).Right.Left.Right != null);
            Assert.IsTrue(((ThreadedNode)threadedTree.Root).Right.Left.Right.RightThread == true);
            Assert.IsTrue(((ThreadedNode)threadedTree.Root).Right.Left.Right.Right != null);
            Assert.IsTrue(((ThreadedNode)threadedTree.Root).Right.Left.Right.Right.Item.Value == "quick");
            Assert.IsTrue(((ThreadedNode)threadedTree.Root).Right.Left.Right.Item.Value == "dog's");
        }

        [TestMethod]
        public void TreadedTreeTraverse()
        {
            String[] input = "The quick brown fox jumped over the lazy brown dog's back".Split(' ');
            List<Tuple<int, String>> output = InitOutput();

            ThreadedTree threadedTree = new ThreadedTree();
            foreach (var i in input)
                threadedTree.Insert(new Item(i));
            threadedTree.Traverse();

            for (int i = 0; i < threadedTree.Report.Count; i++)
            {
                Assert.IsTrue(threadedTree.Report[i].Count == output[i].Item1);
                Assert.IsTrue(threadedTree.Report[i].Item.Value == output[i].Item2);
            }
        }


        [TestMethod]
        public void LengthThenAsciiComparerNullArgs()
        {
            LengthThenAsciiComparer comparer = new LengthThenAsciiComparer();
            var val1 = comparer.Compare(null, null);
            Assert.IsTrue(val1 == 0);

            var val2 = comparer.Compare(new Item(null), null);
            Assert.IsTrue(val2 == 0);

            var val3 = comparer.Compare(new Item(null), new Item("str"));
            Assert.IsTrue(val3 < 0);

            var val4 = comparer.Compare(null, new Item(null));
            Assert.IsTrue(val4 == 0);

            var val5 = comparer.Compare(new Item("str"), null);
            Assert.IsTrue(val5 > 0);
        }

        [TestMethod]
        public void LengthThenAsciiComparerNotSameLength()
        {
            LengthThenAsciiComparer comparer = new LengthThenAsciiComparer();
            var val = comparer.Compare(new Item("myString"), new Item("myOtherString"));
            Assert.IsTrue(val < 0);
        }

        [TestMethod]
        public void LengthThenAsciiComparerSameString()
        {
            LengthThenAsciiComparer comparer = new LengthThenAsciiComparer();
            var val = comparer.Compare(new Item("myString"), new Item("myString"));
            Assert.IsTrue(val == 0);
        }

        [TestMethod]
        public void LengthThenAsciiComparerSameLength()
        {
            LengthThenAsciiComparer comparer = new LengthThenAsciiComparer();
            var val1 = comparer.Compare(new Item("the"), new Item("fox"));
            Assert.IsTrue(val1 > 0);

            var val2 = comparer.Compare(new Item("The"), new Item("fox"));
            Assert.IsTrue(val2 < 0);

            var val3 = comparer.Compare(new Item("the"), new Item("The"));
            Assert.IsTrue(val3 > 0);
        }
    }
}
