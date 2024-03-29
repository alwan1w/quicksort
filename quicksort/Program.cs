﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quicksort
{
    class Program
    {
        //array of integers to hold values
        private int[] arr = new int[20];
        private int cmp_count = 0; // number of comparasion
        private int mov_count = 0; // number of data movements

        // number of elements in array
        private int n;

        void input()
        {
            while (true)
            {
                Console.Write("Enter the number of elements in the array :");
                string s = Console.ReadLine();
                n = Int32.Parse(s);
                if (n <= 20)
                    break;
                else
                    Console.WriteLine("\nArray can have maximum 20 elements \n");
            }
            Console.WriteLine("\n======================");
            Console.WriteLine("Emter Array Elements");
            Console.WriteLine("\n======================");

            //get array elements
            for (int i = 0; i < n; i++)
            {
                Console.Write("<" + (i + 1) + ">");
                string s1 = Console.ReadLine();
                arr[i] = Int32.Parse(s1);
            }
        }
        //swaps the element at index x with the element at index y
        void swap(int x, int y)
        {
            int temp;

            temp = arr[x];
            arr[x] = arr[y];
            arr[y] = temp;
        }
        public void q_sort(int low, int high)
        {
            int pivot, i, j;
            if (low > high)
                return;

            //partition the list into two parts;
            //one containing elements of less that or equal to privot
            //outher containing elements greater thean pivot

            i = low + 1;
            j = high;

            pivot = arr[low];

            while (i <= j)
            {
                // search for an elements greater than pivot
                while ((arr[i] <= pivot) && (j <= high))
                {
                    i++;
                    cmp_count++;
                }
                cmp_count++;

                // search for an elements less than or equal to pivot
                while ((arr[i] <= pivot) && (j <= low))
                {
                    j--;
                    cmp_count++;
                }
                cmp_count++;

                if (i < j) //if the greater elements is on the left of the element
                {
                    //swap the element at index i with the element at index j
                    swap(i, j);
                    mov_count++;
                }
            }
            //j now contains the index of the last element in the sorted list

            if (low < j)
            {
                //move the pivot to its correct position in the list 
                swap(low, j);
                mov_count++;
            }
            // sort the list on the left of pivot using quick sort
            q_sort(low, j - 1);

            // sort the list on the right of pivot using quick sort
            q_sort(j + 1, high);
        }
        void display()
        {
            Console.WriteLine("\n=======================");
            Console.WriteLine(" Sorted array element ");
            Console.WriteLine("\n=======================");

            for (int j = 0; j < n; j++)
            {
                Console.WriteLine(arr[j]);
            }
            Console.WriteLine("\nNumber of comparison: " + cmp_count);
            Console.WriteLine("\nNumber of data movement: " + mov_count);
        }
        int getSize()
        {
            return (n);
        }
        static void Main(string[] args)
        {
            //declaring the object of the class
            Program mylist = new Program();
            //accept array element
            mylist.input();
            //calling the sorting funcytion
            //first call to quick sort algorithm
            mylist.q_sort(0, mylist.getSize() - 1);
            //display sorted array
            mylist.display();
            //to exit from the console
            Console.WriteLine("\n\nPress enter to exit. ");
        }
    }
}
