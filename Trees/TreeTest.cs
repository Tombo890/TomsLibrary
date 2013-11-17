using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trees
{
    class TreeTest
    {
        static void Main()
        {
            int[] smallTree = new int[] { 7, 6, 3, 5, 8, 15, 19, 10, 4, 8 };

            DFS dfsTree = new DFS(smallTree);
            bool isItThere = dfsTree.PreOrderSearch(0, 4);
            System.Console.WriteLine(isItThere);

            isItThere = dfsTree.InOrderSearch(0, 412);
            System.Console.WriteLine(isItThere);

            isItThere = dfsTree.PostOrderSearch(0, 6);
            System.Console.WriteLine(isItThere);

            BFS bfsTree = new BFS(smallTree);
            isItThere = bfsTree.LevelOrderSearch(19);
            System.Console.WriteLine(isItThere);

            isItThere = bfsTree.LevelOrderSearch(555);
            System.Console.WriteLine(isItThere);

            // Keep the console window open in debug mode.
            System.Console.WriteLine("Press any key to exit.");
            System.Console.ReadKey();
        }
    }
}
