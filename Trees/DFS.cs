using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trees
{
    class DFS
    {
        // Properties
        private int[] treeArray{ get; set;}

        public DFS(int[] treeToSearch)
        {
            this.treeArray = treeToSearch;
        }

        public bool PreOrderSearch(int index, int value)
        {
            // Safety checks
            if(treeArray == null || treeArray.Length == 0 || index > treeArray.Length - 1)
            {
                return false;
            }

            // Visit the root
            if(treeArray[index] == value)
            {
                return true;
            }

            // Vars for switch
            bool left = false;
            bool right = false;
            if (index == 0)
            {
                // Traverse left subtree
                left = PreOrderSearch(1 , value);

                // Traverse right subtree
                right = PreOrderSearch(2, value);
            }
            else
            {
                // If using Type that is not 0 based
                // left node is index * 2
                // right node is index * 2 + 1

                // Traverse left subtree
                left = PreOrderSearch(index * 2 + 1, value);

                // Traverse right subtree
                right = PreOrderSearch(index * 2 + 2, value);
            }

            return left || right;
        }

        public bool InOrderSearch(int index, int value)
        {
            // Safety checks
            if (treeArray == null || treeArray.Length == 0 || index > treeArray.Length - 1)
            {
                return false;
            }

            // Vars for switch
            bool left = false;
            bool right = false;
            if(index == 0)
            {
                // Traverse left subtree
                left = PreOrderSearch(1, value);

                // Visit the root
                if (treeArray[index] == value)
                {
                    return true;
                }

                // Traverse right subtree
                right = PreOrderSearch(2, value);
            }
            else
            {
                // If using Type that is not 0 based
                // left node is index * 2
                // right node is index * 2 + 1

                // Traverse left subtree
                left = PreOrderSearch(index * 2 + 1, value);

                // Visit the root
                if (treeArray[index] == value)
                {
                    return true;
                }

                // Traverse right subtree
                right = PreOrderSearch(index * 2 + 2, value);
            }

            return left || right;
        }

        public bool PostOrderSearch(int index, int value)
        {
            // Safety checks
            if (treeArray == null || treeArray.Length == 0 || index > treeArray.Length - 1)
            {
                return false;
            }

            // Vars for switch
            bool left = false;
            bool right = false;
            if (index == 0)
            {
                // Traverse left subtree
                left = PreOrderSearch(1, value);

                // Traverse right subtree
                right = PreOrderSearch(2, value);

                // Visit the root
                if (treeArray[index] == value)
                {
                    return true;
                }
            }
            else
            {
                // If using Type that is not 0 based
                // left node is index * 2
                // right node is index * 2 + 1

                // Traverse left subtree
                left = PreOrderSearch(index * 2 + 1, value);

                // Traverse right subtree
                right = PreOrderSearch(index * 2 + 2, value);

                // Visit the root
                if (treeArray[index] == value)
                {
                    return true;
                }
            }

            return left || right;
        }
    }
}
