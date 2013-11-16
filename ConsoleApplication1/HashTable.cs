using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsSortSomeStuff
{
    class HashTable
    {
        // Vars
        private int tableSize;
        private string[][] hashTable;

        public HashTable(int tableSize)
        {
            // Setup Vars
            this.tableSize = tableSize;
            int slots = 5;

            //Setup Table with each bucket having desired slots
            hashTable = new string[this.tableSize][];
            for (int index = 0; index < hashTable.Length; index++)
            {
                hashTable[index] = new string[slots];
            }
        }

        public void Insert(string val)
        {
            // Make sure that val is not null
            if (val == null)
            {
                return;
            }

            // Hash Value
            int hashedVal = CalculateHash(val);

            for (int index = 0; index < hashTable[hashedVal].Length; index++)
            {
                // Insert the value in the first null index
                if (hashTable[hashedVal][index] == null)
                {
                    hashTable[hashedVal][index] = val;
                    return;
                }
            }

            // Make a copy of the array at the hashed index, extend it, replace it
            string[] temp = new string[hashTable[hashedVal].Length + 5];
            Array.Copy(hashTable[hashedVal], temp, hashTable[hashedVal].Length);
            hashTable[hashedVal] = temp;

            // Insert element into the last position of the hashed index array
            hashTable[hashedVal][hashTable[hashedVal].Length - 1] = val;

        }

        public void Remove(string val)
        {
            // Make sure that val is not null
            if (val == null)
            {
                return;
            }
            
            // Hash Value
            int hashedVal = CalculateHash(val);

            // Remove val at hashed index
            for (int index = 0; index < hashTable[hashedVal].Length; index++)
            {
                // If we find the value, remove it and return
                if (hashTable[hashedVal][index] == val)
                {
                    hashTable[hashedVal][index] = null;
                    return;
                }
            }
        }

        public bool Contains(string val)
        {
            // Make sure that val is not null
            if (val == null)
            {
                return false;
            }
            
            // Hash Value
            int hashedVal = CalculateHash(val);

            // Scan the hashed index for val
            for (int index = 0; index < hashTable[hashedVal].Length; index++)
            {
                // If we find the value, return true
                if (hashTable[hashedVal][index] == val)
                {
                    return true;
                }
            }

            // If we don't find the val return false
            return false;
        }

        private int CalculateHash(string stringToHash)
        {
            // Vars
            int sum = 0;

            // Add up each char in stringToHash
            for (int c = 0; c < stringToHash.Length; c++)
            {
                sum += stringToHash[c];
            }

            // Return the sum with the range of the hash table
            return sum % this.tableSize;
        }
    }
}
