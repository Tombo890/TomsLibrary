using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trees
{
    class BFS
    {
        // Properties
        private int[] treeArray{ get; set;}

        public BFS(int[] treeToSearch)
        {
            this.treeArray = treeToSearch;
        }

        public bool LevelOrderSearch(int value)
        {
            // vars
            int index = 0;

            // Saftey Checks
            if (treeArray == null || treeArray.Length == 0 || index > treeArray.Length - 1)
            {
                return false;
            }

            // Create a stack and loop while the stack is not empty
            Queue<int> nodesToVisit = new Queue<int> {};
            nodesToVisit.Enqueue(index);

            // Pop the stack
            while(nodesToVisit.Count > 0)
            {
                index = nodesToVisit.Dequeue();

                // visit the poped node
                if (treeArray[index] == value)
                {
                    return true;
                }

                // If using Type that is not 0 based
                // left node is index * 2
                // right node is index * 2 + 1
                if (index == 0)
                {
                    nodesToVisit.Enqueue(1);
                    nodesToVisit.Enqueue(2);
                }
                else
                {
                    if(index * 2 + 1 < treeArray.Length - 1)
                    {
                        nodesToVisit.Enqueue(index * 2 + 1);
                    }

                    if (index * 2 + 2 < treeArray.Length - 1)
                    {
                        nodesToVisit.Enqueue(index * 2 + 2);
                    }
                }

            }

            return false;
        }
    }
}
