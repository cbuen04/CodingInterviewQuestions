using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Arrays_And_Strings
{
    public class Arrays
    {
        /// <summary>
        /// This method determines if a string has all unique characters
        /// using only an array
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool IsUnique(String s)
        {
            //create a hashtable
            Hashtable hash = new Hashtable();

            //add each character to the hash table
            foreach(char c in s)
            {
                //character is already present in the hash table
                if (hash.ContainsValue(c))
                {
                    return false;
                }
                //character is not in the hashtable so we add the character
                else
                {
                    hash.Add(c.GetHashCode(), c);
                }
            }
            //characters were all added successfully in the hashtable
            return true;
        }

        /// <summary>
        /// Given two strings this method determines if they are permutations of eachother.
        /// </summary>
        /// <param name="s1"></param>
        /// <param name="s2"></param>
        /// <returns></returns>
        public static bool IsPermutation(String s1, String s2)
        {
            // initial check for empty strings
            if(s1.Equals(null) || s2.Equals(null) || s1.Length == 0 || s2.Length == 0)
            {
                return false;
            }

            // create dictionaries to load each character mapping occurances of the char
            Dictionary<char, int> s1Dictionary = new Dictionary<char, int>();
            Dictionary<char, int> s2Dictionary = new Dictionary<char, int>();

            //loads the first string into dictionary
            foreach(char c in s1)
            {
                // case of first occurence
                if (!s1Dictionary.ContainsKey(c))
                {
                    s1Dictionary.Add(c, 1);
                }
                // case of character already in dictionary
                else
                {
                    //update occurences of the value in the dictionary
                    s1Dictionary.TryGetValue(c, out int x);
                    s1Dictionary.Remove(c);
                    s1Dictionary.Add(c, x++);
                }
            }
            //loading the second string into dictionary
            foreach(char c in s2)
            {
                // case of first occurence
                if (!s2Dictionary.ContainsKey(c))
                {
                    s2Dictionary.Add(c, 1);
                }
                // case of char in dictionary
                else
                {
                    //update occurences of the value in the dictionary
                    s2Dictionary.TryGetValue(c, out int y);
                    s2Dictionary.Remove(c);
                    s2Dictionary.Add(c, y++);
                }
            }
            // iterates one dictionary key value pair
            foreach(KeyValuePair<char, int> pair in s1Dictionary)
            {
                // if the key isn't in the second dictionary it is not a permutation
                if (!s2Dictionary.ContainsKey(pair.Key))
                {
                    return false;
                }
                else
                {
                    // if the key is in the dictionary but does not have the same number of occurences then return false
                    s2Dictionary.TryGetValue(pair.Key, out int val);
                    if(val != pair.Value)
                    {
                        return false;
                    }

                }
            }
            // the strings are exact matches.
            return true;
        }

        /// <summary>
        /// this method takes in a string and replaces each space character with a %20
        /// </summary>
        /// <returns></returns>
        public static string URLify(string s)
        {
            // initial check for empty strings
            if(s.Length == 0 || s.Equals(null))
            {
                return "";
            }
            //using a string builder for better run times
            StringBuilder sb = new StringBuilder();

            //cycle through each char in the string
            foreach(char c in s)
            {
                // once we find the space char replace for the %20 characters
                if (c == ' ')
                {
                    sb.Append("%20");
                }
                // anything else can be appended to the sb
                else
                {
                    sb.Append(c);
                }
            }
            // return the final string
            return sb.ToString();
        }

        /// <summary>
        /// this method compresses a string by returning the number of letters numerically
        /// right after each letter eg aabbcccaaaaa returns a2b2c3a5
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string StringCompression(string s)
        {
            // initial check that a small string will be better than compressed
            if(s.Length == 0 || s.Length == 1)
            {
                return s;
            }
            int occurence = 0;
            char prev = s[0];
            StringBuilder sb = new StringBuilder();
            foreach(char c in s)
            {
                // found a repeat increment counter for letter
                if(c == prev)
                {
                    occurence++;
                }
                // new letter is started
                else
                {
                    // append the current info to the sb
                    sb.Append(prev.ToString() + occurence.ToString());
                    //assign the new char to look for
                    prev = c;
                    // start the counter over
                    occurence = 1;
                }
            }
            sb.Append(prev.ToString() + occurence.ToString());
            //checks to see compression is better than original
            if (sb.ToString().Length > s.Length)
            {
                return s;
            }
            else
            {
                return sb.ToString();
            }
        }

        /// <summary>
        /// this method takes in a string and determines if it
        /// is permmutation of a palendrome.
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool IsPalendrome(string s)
        {
            s = s.Trim();
            // create a dictionary to hold char and occurence count
            Dictionary<char, int> occurence = new Dictionary<char, int>();
            bool even = false;

            int sLength = 0;

            // adds each character along with current occurence to the dictionary
            foreach(char c in s)
            {
                sLength++;
                if(c == ' ')
                {
                    sLength--;
                    continue;
                }

                if (occurence.TryGetValue(c, out int x))
                {
                    occurence.Remove(c);
                    occurence.Add(c, x+1);
                }
                else
                {
                    occurence.Add(c, 1);
                }
            }

            //determines if string is odd or even to cover odd palendrome case
            if (sLength % 2 == 0)
            {
                even = true;
            }
            // int to track pairs of odd letter occurences
            int oddKVPairs = 0;
            //cycles each kv pair and checks if it breaks pallendrome rules
            foreach(KeyValuePair<char,int> pair in occurence)
            {
                if (even && (pair.Value %2 != 0))
                {
                    return false;
                }
                if(!even && (pair.Value % 2 != 0))
                {
                    oddKVPairs++;
                }
                // placed in here so it breaks immediately after another invalid pair is found
                if(oddKVPairs > 1)
                {
                    return false;
                }
            }

            //no rules were broken, case is true
            return true;
        }

        /// <summary>
        /// this method takes in an M x N matrix and finds any zero element
        /// and changes that entire row and coloumn to zeros.
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public static int[][] zeroMatrix(int[][] matrix)
        {
            List<int[]> indexes = new List<int[]>();
            int[] map;
            for(int i = 0; i< matrix.GetLength(0); i++)
            {
                for(int j = 0; j < matrix.GetLength(1); j++)
                {
                    if(matrix[i][j] == 0)
                    {
                        map = new int[2];
                        map[0] = i;
                        map[1] = j;
                        indexes.Add(map); 
                    }
                }
            }
            
            return transformZeros(indexes, matrix);
        }

        /// <summary>
        /// this is a helper method for the zero matrix method
        /// </summary>
        /// <param name="indexes"></param>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public static int [][] transformZeros(List<int[]> indexes, int[][] matrix)
        {
            foreach (int[] index in indexes)
            {
                int row = index[0];
                int col = index[1];
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    matrix[row][i] = 0;
                }
                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    matrix[j][col] = 0;
                }
            }
            return matrix;
        }
    }
}
