using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolving
{
    class Knapsack
    {
        public List<int> KnapsackSolver(int[] weight, int[] value, int size)
        {
            // Vars
            int[,] tempArray = new int[weight.Length + 1, size];
            bool[,] keepArray = new bool[weight.Length + 1, size];
            List<int> fullKnapsack = new List<int> { };
            int leftOver = 0;
            
            // Base case, if there are no items or size is 0 return
            if (weight.Length <= 0 || size <= 0)
            {
                return fullKnapsack;
            }

            // Loop through each item
            for (int item = 1; item < weight.Length + 1; item++)
            {
                // Loop through each sub sack
                for (int subSack = 0; subSack < size; subSack++)
                {
                    // If the weight is less than the sub sack size
                    if (weight[item - 1] <= subSack + 1)
                    {
                        // Compute how much space is left after putting item in sub sack
                        leftOver = (subSack + 1) - weight[item - 1];

                        // Mark the keep array that we we're able to fit an item
                        keepArray[item, subSack] = true;

                        // If the item before this one was placed in the same sub sack but worth more
                        // than current item + whatever item is in the row above this one in the sub sack
                        // column of the leftover weight then keep the item from before this one
                        if(tempArray[item - 1, subSack] > weight[item - 1] + tempArray[item - 1, leftOver])
                        {
                            tempArray[item, subSack] = tempArray[item - 1, subSack];
                        }
                        // Otherwise keep the current item + whatever you can get from the leftove weight
                        else
                        {
                            tempArray[item, subSack] = weight[item - 1] + tempArray[item - 1, leftOver];
                        }
                    }
                    // If the weight is larger than the sack size mark both arrays with 0s
                    else
                    {
                        tempArray[item, subSack] = 0;
                        keepArray[item, subSack] = false;
                    }

                }
            }

            int spaceRemaining = size - 1;
            int currentItem = weight.Length - 1;

            // Loop through each item
            while (currentItem > 0)
            {
                // If we have a value for that subSack then:
                if (keepArray[currentItem, spaceRemaining])
                {
                    // Add the item to the sack
                    fullKnapsack.Add(weight[currentItem]);

                    // Subtract the space we just took up
                    spaceRemaining = spaceRemaining - weight[currentItem];
                }

                // Move on to the next item
                currentItem--;
            }

            return fullKnapsack;
        }

        public List<Item> FindItemsToPack(List<Item> items, int capacity, out int totalValue)
        {
            // Vars
            int[,] tempArray = new int[items.Count + 1, capacity + 1];
            bool[,] keepArray = new bool[items.Count + 1, capacity + 1];

            // Loop through each item
            for (int currentItem = 1; currentItem <= items.Count; currentItem++)
            {
                // Loop through each subSack
                for (int subSack = 1; subSack <= capacity; subSack++)
                {
                    // If item fits in the subSack then deal with it
                    if (items[currentItem - 1].Weight <= subSack)
                    {
                        int remainingSpace = subSack - items[currentItem - 1].Weight;

                        // If the current item + the previous item that fits in the left over space
                        // is greater than the previous item for that sub sack then take the new value 
                        // + the previous item that fits in the left over space
                        if (items[currentItem - 1].Value + tempArray[currentItem - 1, remainingSpace] > tempArray[currentItem - 1, subSack])
                        {
                            keepArray[currentItem, subSack] = true;
                            tempArray[currentItem, subSack] = items[currentItem - 1].Value + tempArray[currentItem - 1, remainingSpace];
                        }
                        // Otherwise take the previous item value for the subSack
                        else
                        {
                            keepArray[currentItem, subSack] = false;
                            tempArray[currentItem, subSack] = tempArray[currentItem - 1, subSack];
                        }
                    }
                }
            }

            List<Item> itemsToBePacked = new List<Item>();
            int spaceRemaining = capacity;
            int item = items.Count;

            // Loop through each item
            while (item > 0)
            {
                // If we have a value for that subSack then:
                if (keepArray[item, spaceRemaining])
                {
                    // Add the item to the sack
                    itemsToBePacked.Add(items[item - 1]);

                    // Subtract the space we just took up
                    spaceRemaining = spaceRemaining - items[item - 1].Weight;
                }

                // Move on to the next item
                item--;
            }

            totalValue = tempArray[items.Count, capacity];
            return itemsToBePacked;
        }
    }

    public class Item
    {
        public int ID;
        public int Weight;
        public int Value;
        public Item(int id, int weight, int value)
        {
            this.ID = id;
            this.Weight = weight;
            this.Value = value;
        }

        public override string ToString()
        {
            return "ID=" + ID + ",W=" + Weight + ",V=" + Value;
        }
    }
}
