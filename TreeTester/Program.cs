using Cryptothecia;
using System;
using IFL = System.Tuple<int, float, string>;
namespace TreeTester
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            Node<string> n = new Node<string>("wolverhampton");
            n.AddRight(n, "sucks");
            n.AddLeft(n, "doesn't suck");

            //IFL ifl = new IFL(0,0,string.Empty);
            var T = new Tree<IFL>(new IFL(0, 0, "root"));
            var Cow = T.Add(new IFL(0, 0, "cow"));
            T.Add(Cow, new IFL(0, 0, "hoof"));
            T.Add(Cow, new IFL(0, 0, "tail"));
            var Dog = T.Add(new IFL(0, 0, "dog"));
            var Woof = T.Add(Dog, new IFL(0, 0, "tail"));
            T.Add(Woof, new IFL(0, 0, "vertebra"));
            T.Add(Woof, new IFL(0, 0, "hide"));
            T.Add(Dog, new IFL(0, 0, "legs"));
            var Cat = T.Add(new IFL(0, 0, "cat"));
            var result = T.Traverse(T, Tree<IFL>.TRAVERSAL.TOPDOWN);
            foreach (Tree<IFL> t in result)
            {
                Console.WriteLine("{1} child of {0}", t.Parent != null ? t.Parent.Data.Item3 : "null", t.Data.Item3);
            }
            Console.WriteLine("---------");

            result = T.Traverse(T, Tree<IFL>.TRAVERSAL.BOTTOMUP);
            foreach (Tree<IFL> t in result)
            {
                Console.WriteLine("{1} child of {0}", t.Parent != null ? t.Parent.Data.Item3 : "null", t.Data.Item3);
            }
            var y = Console.ReadKey();
        }
    }
}
