using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolving
{
    class ProblemSolvingTest
    {
        static void Main(string[] args)
        {
            int[] weights = new int[] { 3, 2, 1 };
            int[] values = new int[] { 5, 3, 4 };
            Knapsack sackObject = new Knapsack();
            List<int> solution = new List<int>{};

            solution = sackObject.KnapsackSolver(weights, values, 5);
            foreach(int item in solution)
            {
                System.Console.WriteLine("Item: " + item + " with a value of: " + values[item]);
            }

            // Keep the console window open in debug mode.
            System.Console.WriteLine("Press any key to exit.");
            System.Console.ReadKey();
        }
    }
}
