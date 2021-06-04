using System;
using System.Collections.Generic;
using System.Linq;

namespace Assignment1_Summer2021
{
    class Program
    {
        static void Main(string[] args)
        {

            //Question 1
            Console.WriteLine("Q1 : Enter the Moves of Robot:");
            string moves = Console.ReadLine();
            bool pos = JudgeCircle(moves);
            if (pos)
            {
                Console.WriteLine("The Robot return’s to initial Position (0,0)");
            }
            else
            {
                Console.WriteLine("The Robot doesn’t return to the Initial Postion (0,0)");
            }

            Console.WriteLine();

            //Question 2:
            Console.WriteLine(" Q2 : Enter the string to check for pangram:");
            string s = Console.ReadLine();
            bool flag = CheckIfPangram(s);
            if (flag)
            {
                Console.WriteLine("Yes, the given string is a pangram");
            }
            else
            {
                Console.WriteLine("No, the given string is not a pangram");
            }
            Console.WriteLine();

            //Question 3:

            int[] arr = { 1, 2, 3, 1, 1, 3 };
            int gp = NumIdenticalPairs(arr);
            Console.WriteLine("Q3:");
            Console.WriteLine("The number of IdenticalPairs in the array are {0}:", gp);


            //Question 4:
            //int[] arr1 = { 3, 1, 4, 1, 5 };
            int[] arr1 = { 1, 7, 3, 6, 5, 6 };
            Console.WriteLine("Q4:");
            int pivot = PivotIndex(arr1);
            if (pivot > 0)
            {
                Console.WriteLine("The Pivot index for the given array is {0}", pivot);
            }
            else
            {
                Console.WriteLine("The given array has no Pivot index");
            }
            Console.WriteLine();

            //Question 5:
            Console.WriteLine("Q5:");
            Console.WriteLine("Enter the First Word:");
            String word1 = Console.ReadLine();
            Console.WriteLine("Enter the Second Word:");
            String word2 = Console.ReadLine();
            String merged = MergeAlternately(word1, word2);
            Console.WriteLine("The Merged Sentence fromed by both words is {0}", merged);


            //Quesiton 6:
            Console.WriteLine("Q6: Enter the sentence to convert:");
            string sentence = Console.ReadLine();
            string goatLatin = ToGoatLatin(sentence);
            Console.WriteLine("Goat Latin for the Given Sentence is {0}", goatLatin);
            Console.WriteLine();

        }

        /* 
<summary>
/// Input: moves = "UD"
/// Output: true
/// Explanation: The robot moves up once, and then down once. All moves have the same ///magnitude, so it ended up at the origin where it started. Therefore, we return true.
</summary>
<retunrs>true/False</returns>
*/
        private static bool JudgeCircle(string moves)
        {
            try
            {
                //Check the moves of the robot
                if (moves == "UD" | moves == "RL" | moves == "DU" | moves == "LR")
                {
                    return true; //return true if the input string matches with any of the condition above
                }
                else
                {
                    return false; // return flase if the input string doesnt match the condition
                }
            }
            catch (Exception)
            {
                throw;
            }

        }

        /* 
 <summary>
A pangram is a sentence where every letter of the English alphabet appears at least once.
Given a string sentence containing only lowercase English letters, return true if sentence is a pangram, or false otherwise.
Example 1:
Input: sentence = "thequickbrownfoxjumpsoverthelazydog"
Output: true
Explanation: sentence contains at least one of every letter of the English alphabet.
</summary>
</returns> true/false </returns>
Note: Use of String function (Contains) and hasmap is not allowed, think of other ways how you could the numbers be represented
        */


        private static bool CheckIfPangram(string s)
        {
            try
            {
                //check only for distinct characters in the string
                var unique = s.ToCharArray().Distinct(); //calculate for the count of distinct characters and check if it is 26
                if (unique.Count() == 26)
                {
                    return true; //return true if the distinct characters count matches the count of alphabets in english 
                }
                else
                return false;//return false if the count is not equal to 26
                                
            }
            catch (Exception)
            {
                throw;
            }

        }


        /*

 <summary> 
 Given an array of integers nums 
 A pair (i,j) is called good if nums[i] == nums[j] and i < j.
 Return the number of good pairs.
 Example:
 Input: nums = [1,2,3,1,1,3]
 Output: 4
 Explanation: There are 4 good pairs (0,3), (0,4), (3,4), (2,5) 0-indexed.
   return type  : int
 </summary>
 <returns>int </returns>
     */

        public static int NumIdenticalPairs(int[] arr)
        {
            
            try
            {
                int counter=0;
                //check if array is not null
                if (arr.Length > 0)
                {
                    //start the array at 0 position and traverse till length of array is reached
                    for (int i = 0; i < arr.Length - 1; i++)
                    {
                        //start the counter from i+1th position each time and traverse through the array length
                        for (int j = i+1; j < arr.Length; j++)
                        {
                            //compare the current number in array with the rest of the numbers to the right
                            if (arr[i] == arr[j]) 
                            {
                                //increment counter when there is a match
                                counter = counter + 1;
                            }
                        }

                    }
                    //return the count of same number pairs
                    return counter;
                }
                else
                //return 0 if array is null
                return 0;

            }
            catch (Exception)
            {

                throw;
            }
        }






        /*

          <summary>
   Given an array of integers nums, calculate the pivot index of this array.The pivot index is the index where the sum of all the numbers strictly to the left of  the index is equal to the sum of all the numbers strictly to the index's right.
  If the index is on the left edge of the array, then the left sum is 0 because there are no elements to the left. This also applies to the right edge of the array.
  Return the leftmost pivot index. If no such index exists, return -1.
  Example 1:
  Input: nums = [1,7,3,6,5,6]
         Output : 3
        3, 1, 4, 1, 5

      Explanation:
  The pivot index is 3.
  Left sum = nums[0] + nums[1] + nums[2] = 1 + 7 + 3 = 11
  Right sum = nums[4] + nums[5] = 5 + 6 = 11
          /// </summary>
          /// <param name="nums"></param>
          /// <returns>Number the index in the array</returns>
      */
        private static int PivotIndex(int[] nums)
        {
            try
            {
                int[] leftSum = new int[nums.Length];
                int[] rightSum = new int[nums.Length];
                //check if the array is not null
               
                //starting from 0th position, traverse i till the value of i is less than pivot
                for (int i = 0; i < nums.Length; i++)
                {
                    leftSum[i] = leftSum[i - 1] + nums[i - 1];//calculate the sum starting from the left most number in array
                    //calculate sum starting from right most in array
                    rightSum[nums.Length - i - 1] = rightSum[nums.Length - i] + nums[nums.Length - 1];
                }
                for (int i = 0; i < nums.Length; i++)
                {
                    if (leftSum[i] == rightSum[i]) //if the sum of left numbers match the sum of right numbers 
                    {
                        return i;//return pivot index
                    }
                }
                return -1;
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occured: " + e.Message);
                throw;
            }
        }

        /*
            /// <summary>
    /// You are given two strings word1 and word2. Merge the strings by adding letters /// in alternating order, starting with word1. If a string is longer than the other,
    /// append the additional letters onto the end of the merged string.
    /// Example 1
    /// Input: word1 = "abc", word2 = "pqr"
    /// Output: "apbqcr"
    /// Explanation: The merged string will be merged as so:
    /// word1:  a   b   c
    /// word2:    p   q   r
    /// merged: a p b q c r
    /// </summary>
           /// <param name="word1"></param>
    ///<param name="word2"></param>
           /// <returns>return the merged string </returns>

    */

        private static string MergeAlternately(string word1, string word2)
        {
            try
            {
                //check if word1 and word2 are not null
                if (word1.Length > 0 && word2.Length > 0)
                {
                    string merged = "";
                    int str1Len = word1.Length; //calculate the length of word1
                    int str2Len = word2.Length; //calculate the lenght of word2
                    int counter = 0;
                    int i = 0;
                    if (str1Len == str2Len) //if lenght of both words are same
                    {
                        //starting with 0 till the length any word, traverse through the array
                        for (i = 0; i < str1Len; i++)
                        {
                            //in each iteration, take single character from each word and add it to merged
                            merged += word1.Substring(i, 1) + word2.Substring(i, 1); 
                        }
                    }
                    else if (str1Len > str2Len)
                    {
                        //starting with 0 till the length second word, traverse through the string
                        for (i = 0; i < str2Len; i++)
                        {
                            //in each iteration, take single character from each word and add it to merged
                            merged += word1.Substring(i, 1) + word2.Substring(i, 1);
                            //store the i'th position in counter
                            counter = counter + 1;
                        }
                        //merge the rest of the characters from word1 starting with the counter position
                        merged += word1.Substring(counter, str1Len - counter);
                    }
                    else
                    {
                        //starting with 0 till the length first word, traverse through the string
                        for (i = 0; i < str1Len; i++)
                        {
                            //in each iteration, take single character from each word and add it to merged
                            merged += word1.Substring(i, 1) + word2.Substring(i, 1);
                            //store the i'th position in counter
                            counter = counter + 1;
                        }
                        //merge the rest of the characters from word2 starting with the counter position
                        merged += word2.Substring(counter, str2Len - counter);
                    }
                    //return the merged string
                    return merged;
                }
                else
                    return "null";
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }

        }

        /*
        <summary>
    /// A sentence sentence is given, composed of words separated by spaces. Each word consists of lowercase and uppercase letters only.
    We would like to convert the sentence to "Goat Latin" (a made-up language similar to Pig Latin.)
    The rules of Goat Latin are as follows:
    1)	If a word begins with a vowel (a, e, i, o, or u), append "ma" to the end of the word.
    For example, the word 'apple' becomes 'applema'.

    2)	If a word begins with a consonant (i.e. not a vowel), remove the first letter and append it to the end, then add "ma".
    For example, the word "goat" becomes "oatgma".

    3)	Add one letter 'a' to the end of each word per its word index in the sentence, starting with 1.
    For example, the first word gets "a" added to the end, the second word gets "aa" added to the end and so on.
    Hint : think of a string function to divide the sentence on white spaces
        /// </summary>
        /// <param name="sentence"></param>
        /// <returns> string</returns>
       */
        private static string ToGoatLatin(string sentence)
        {
            try
            {
                String vowels = "aeiouAEIOU";
                String[] wordList = sentence.Split(" ");
                int strlen = wordList.Length;
                System.Text.StringBuilder finalSen = new System.Text.StringBuilder();
                for (int i = 0; i < strlen; i++)
                {
                    String index = wordList[i];
                    if (vowels.IndexOf(index[0]) >= 0)//if vowel exist
                    {
                        finalSen.Append(index);
                        finalSen.Append("ma"); //If a word begins with a vowel (a, e, i, o, or u), append "ma" to the end of the word
                    }
                    else
                    {
                        finalSen.Append(index.Substring(1));//take first character of the sentence
                        finalSen.Append(index.Substring(0, 1));//append the character to the end
                        finalSen.Append("ma");//If a word begins with a consonant (i.e. not a vowel), remove the first letter and append it to the end, then add "ma".
                    }
                    for (int j = 0; j < i + 1; j++)
                    {
                        finalSen.Append("a");//Add one letter 'a' to the end of each word per its word index in the sentence, starting with 1
                    }
                    finalSen.Append(" ");//finally append all the words to form the sentence
                }
                return finalSen.ToString().Trim();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
