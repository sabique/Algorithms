﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.SORTING
{
    class ShellSort
    {
        public static void Main()
        {
            int totalItems = 10;
            string holdValue = string.Empty;

            Console.WriteLine("STARTING SHELL SORT");

            #region Initialize and Fill Array with Random Numbers
            IComparable[] arr = new IComparable[totalItems];

            Random rnd = new Random();

            for (int i = 0; i < totalItems; i++)
            {
                arr[i] = rnd.Next(1, 100);
            }
            #endregion

            #region Print Unsorted Array
            Console.WriteLine("The array before sorting: ");
            printArray(arr, totalItems);
            #endregion

            #region Perform Sorting Operation
            Console.WriteLine("\nSorting Array...");
            sort(arr);
            Console.WriteLine("\nSorting Completed!");
            #endregion

            #region Print Sorted Array
            Console.WriteLine("\nThe array after sorting: ");
            printArray(arr, totalItems);
            #endregion

            Console.ReadLine();
        }

        /// <summary>
        /// The method to sort the array using the Shell Sort implementation
        /// </summary>
        /// <param name="a">The array to be sorted</param>
        private static void sort(IComparable[] a)
        {
            int N = a.Length;
            int h = 1;

            while (h < N / 3) h = 3 * h + 1; //3x*1 increment sequence

            while (h >= 1)
            {
                #region Insertion Sort Code
                for (int i = h; i < N; i++)
                {
                    for (int j = i; j >= h && less(a[j], a[j - h]); j -= h)
                    {
                        exch(a, j, j - h);
                    }
                } 
                #endregion

                h = h / 3; //move to next pointer
            }
        }

        /// <summary>
        /// The method to compare if the first value is less or not
        /// </summary>
        /// <param name="v">The first number - which we have to compare</param>
        /// <param name="w">The second number - against which we have to compare</param>
        /// <returns>Returns true is first number is small else false</returns>
        private static bool less(IComparable v, IComparable w)
        {
            return v.CompareTo(w) < 0;
        }

        /// <summary>
        /// The method to exchange/swap the two numbers in the array
        /// </summary>
        /// <param name="a">The array in which swapping is required</param>
        /// <param name="i">The index of the first variable</param>
        /// <param name="j">The index of the second variable</param>
        private static void exch(IComparable[] a, int i, int j)
        {
            IComparable swap = a[i];
            a[i] = a[j];
            a[j] = swap;
        }

        /// <summary>
        /// The method to print the array
        /// </summary>
        /// <param name="a">The array we need to print</param>
        /// <param name="totalItems">The total number of elements in the array</param>
        private static void printArray(IComparable[] a, int totalItems)
        {
            string holdValue = string.Empty;

            for (int i = 0; i < totalItems; i++)
            {
                if (i == 0)
                    holdValue += a[i].ToString();
                else
                    holdValue += ", " + a[i].ToString();
            }

            Console.WriteLine(holdValue);
        }
    }
}
