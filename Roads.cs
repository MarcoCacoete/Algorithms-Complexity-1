using Assessment_1_Algo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
/*
namespace Assessment_1_Algo
{
    class Roads
    {
        public static void loader()
        {
            string[] roadsArray1256;
            string[] roadsArray2256;
            string[] roadsArray3256;
            string[] roadsArray12048;
            string[] roadsArray22048;
            string[] roadsArray32048;

            roadsArray1256 = File.ReadAllLines("Road_1_256.txt");               //loads all txt files into arrays
            roadsArray2256 = File.ReadAllLines("Road_2_256.txt");
            roadsArray3256 = File.ReadAllLines("Road_3_256.txt");
            roadsArray12048 = File.ReadAllLines("Road_1_2048.txt");
            roadsArray22048 = File.ReadAllLines("Road_2_2048.txt");
            roadsArray32048 = File.ReadAllLines("Road_3_2048.txt");

            RoadsChoice();
            void RoadsChoice()
            {
                try
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("Which array would you like to load? ");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("1: Road 1 256.");
                    Console.WriteLine("2: Road 2 256.");
                    Console.WriteLine("3: Road 3 256.");
                    Console.WriteLine("4: Road 1 2048.");
                    Console.WriteLine("5: Road 2 2048.");
                    Console.WriteLine("6: Road 3 2048.");
                    Console.WriteLine("7: Merged 1 and 3");
                    Console.WriteLine("8: Merged 4 and 6");

                    string Choice = Console.ReadLine();                // converts string arrays to int arrays                

                    if (Choice == "1")
                    {
                        converter(roadsArray1256, 256);
                        return;
                    }
                    if (Choice == "2")
                    {
                        converter(roadsArray2256, 256);
                        return;
                    }
                    if (Choice == "3")
                    { 
                        converter(roadsArray3256, 256);
                        return;
                    }
                    if (Choice == "4")
                    {
                        converter(roadsArray12048, 2048);
                        return;
                    }
                    if (Choice == "5")
                    {
                        converter(roadsArray22048, 2048);
                        return;
                    }
                    if (Choice == "6")
                    {
                        converter(roadsArray32048, 2048);
                        return;
                    }
                    if (Choice == "7")                                 //merges and concatenates arrays if options 7 or 8, then converts type of array
                    {
                        string[] merged = roadsArray1256.Concat(roadsArray3256).ToArray();
                        converter(merged, merged.Length);
                        return;
                    }
                    if (Choice == "8")
                    {
                        string[] merged = roadsArray12048.Concat(roadsArray32048).ToArray();
                        converter(merged, merged.Length);
                        return;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Please enter valid option.");
                        Console.WriteLine();
                        RoadsChoice();
                        Console.ForegroundColor = ConsoleColor.White;                        
                    }

                }
                catch(Exception e)
                {
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(e);
                    Console.WriteLine("Please enter valid option.");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine();
                    RoadsChoice();
                }
            }
            //converts strings to ints in arrays
            int[] converter(string[]array,int size)                                     //method for converting string array to int array
            {                
                int[] intArray = new int[size];
                int iterator = 0;                
                while (iterator < size)      
                {
                    foreach (string s in array)
                    {
                        int number = int.Parse(s);
                        intArray[iterator] = number;
                        iterator++;
                    }
                }
                try
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("Which type of sort would you like to use?");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("1: Insertion sort.");
                    Console.WriteLine("2: Bubble sort.");
                    Console.WriteLine("3: Merge sort.");
                    Console.WriteLine("4: Quicksort.");
                    int sortChoice = int.Parse(Console.ReadLine());
                    Console.WriteLine();

                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("Would you like to sort ascending or descending order?");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("1: Ascending.");
                    Console.WriteLine("2: Descending.");
                    int DirectionChoice = int.Parse(Console.ReadLine());
                    Console.WriteLine();

                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("Which type of search would you like to do?");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("1: Binary search.");
                    Console.WriteLine("2: Sequential search.");
                    int searchT = int.Parse(Console.ReadLine());
                    Console.WriteLine();

                    if (sortChoice == 1)
                        Sort.BackSorter(intArray, DirectionChoice, searchT);
                    if (sortChoice == 2)
                        Sort.PushSorter(intArray, DirectionChoice, searchT);
                    if (sortChoice == 3)
                    {
                        if (DirectionChoice == 1)
                        {
                            Sort.SortArray(intArray, 0, intArray.Length - 1);
                            Printing.print(intArray);
                            Search.search(intArray, DirectionChoice, searchT);
                        }
                        if (DirectionChoice == 2)
                        {
                            Sort.SortArrayR(intArray, 0, intArray.Length - 1);
                            Printing.print(intArray);
                            Search.search(intArray, DirectionChoice, searchT);
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Please enter valid option.");
                            Console.WriteLine();
                            RoadsChoice();
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                    }
                    if (sortChoice == 4)
                    {
                        if (DirectionChoice == 1)
                        {
                            Sort.QuickSort(intArray, 0, intArray.Length - 1);
                            Printing.print(intArray);
                            Search.search(intArray, DirectionChoice, searchT);
                        }
                        if (DirectionChoice == 2)
                        {
                            Sort.QuickSortR(intArray, 0, intArray.Length - 1);
                            Printing.print(intArray);
                            Search.search(intArray, DirectionChoice, searchT);
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Please enter valid option.");
                            Console.WriteLine();
                            RoadsChoice();
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Please enter valid option.");
                        Console.WriteLine();
                        RoadsChoice();
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(e);
                    Console.WriteLine("Please enter valid option.");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine();
                    RoadsChoice();
                }
                return intArray;
            }
        }       
    }
}*/
