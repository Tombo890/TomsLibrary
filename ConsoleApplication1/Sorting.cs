using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsSortSomeStuff
{
    class Sorting
    {
        static void Main(string[] args)
        {
            int[] myNumbers = new int[] { 1, 7, 4, 5, 3, 4, 1, 3, 6, 9 };
            Sort sortObject = new Sort();
            //sortObject.QuickSort(myNumbers, 0, myNumbers.Length - 1);
            sortObject.MergeSort(myNumbers, 0, myNumbers.Length - 1);
            Console.WriteLine(myNumbers.ToString());

            HashTable hashObject = new HashTable(10);
            hashObject.Insert("superduper");
            bool works = hashObject.Contains("superduper");
            hashObject.Insert("another");
            works = hashObject.Contains("superduper");
            works = hashObject.Contains("another");
            hashObject.Remove("superduper");
            works = hashObject.Contains("supderduper");
            hashObject.Insert("superdupers");
            hashObject.Insert("this");
            hashObject.Insert("that");
            hashObject.Insert("and");
            hashObject.Insert("a");
            hashObject.Insert("rattle");
            hashObject.Insert("tat");
            hashObject.Insert("that");
            hashObject.Insert("another");
            hashObject.Insert("superduper");
            hashObject.Insert("that");
            hashObject.Insert("another");
            hashObject.Insert("superduper");
            hashObject.Insert("that");
            hashObject.Insert("another");
            hashObject.Insert("superduper");
            hashObject.Insert("that");
            hashObject.Insert("another");
            hashObject.Insert("superduper");
        }
    }
}
