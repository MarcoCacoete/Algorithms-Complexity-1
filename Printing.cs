using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment_1_Algo
{
    class Printing
    {           // Method responsible for printing every 10th and 50th value of a sorted array.
        public static void print(int[] SortedArray)
        {
            int Number = 10;
            int Increment = 10;
            if (SortedArray.Length > 512)       // Depending on the array size, the appropriate variable will be selected.
            {
                Number = 50;
                Increment = 50;
            }
            try                                                                             
            {                // A for loop iterates through each value of sorted array and prints it to console.
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Printing sorted array.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine();
                foreach (int i in SortedArray)
                {
                    Console.WriteLine(i);
                }
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Printing every " + Increment + "'th value.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine();
                while (true)
                {           // Following the above task, every 'th value is printed below.
                    Console.WriteLine("Value " + SortedArray[0 + Number] + " found at index " + Number);
                    Number += Increment;
                }               
            }
            catch
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine();
                Console.WriteLine("Finished writing every " + Increment + "'th value.");
                Console.WriteLine();
                Console.WriteLine("Please scroll up to view printed array and every " + Increment+"'th value.");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }
}
