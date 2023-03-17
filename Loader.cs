using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
namespace Assessment_1_Algo
{
    class Loader
    {
        public static void loader()
        {

            string[] RoadsArray1256;
            string[] RoadsArray2256;
            string[] RoadsArray3256;
            string[] RoadsArray12048;
            string[] RoadsArray22048;
            string[] RoadsArray32048;

            RoadsArray1256 = File.ReadAllLines("Road_1_256.txt");               //loads all txt files into arrays
            RoadsArray2256 = File.ReadAllLines("Road_2_256.txt");
            RoadsArray3256 = File.ReadAllLines("Road_3_256.txt");
            RoadsArray12048 = File.ReadAllLines("Road_1_2048.txt");
            RoadsArray22048 = File.ReadAllLines("Road_2_2048.txt");
            RoadsArray32048 = File.ReadAllLines("Road_3_2048.txt");
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
                int RoadChoice = Convert.ToInt32(Console.ReadLine());
            
                if (RoadChoice == 1)
                {
                    Converter(RoadsArray1256, 256);
                    return;
                }
                if (RoadChoice == 2)
                {
                    Converter(RoadsArray2256, 256);
                    return;
                }
                if (RoadChoice == 3)
                {
                    Converter(RoadsArray3256, 256);
                    return;
                }
                if (RoadChoice == 4)
                {
                    Converter(RoadsArray12048, 2048);
                    return;
                }
                if (RoadChoice == 5)
                {
                    Converter(RoadsArray22048, 2048);
                    return;
                }
                if (RoadChoice == 6)
                {
                    Converter(RoadsArray32048, 2048);
                    return;
                }
                if (RoadChoice == 7)                                 //merges and concatenates arrays if options 7 or 8, then converts type of array
                {
                    string[] merged = RoadsArray1256.Concat(RoadsArray3256).ToArray();
                    Converter(merged, merged.Length);
                    return;
                }
                if (RoadChoice == 8)
                {
                    string[] merged = RoadsArray12048.Concat(RoadsArray32048).ToArray();
                    Converter(merged, merged.Length);
                    return;
                }
                else
                {
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please enter valid option.");
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.White;
                    loader();
                }
            }
            catch
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Please enter valid option.");
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.White;
                loader();
            }
        }
        static int[] Converter(string[] StringArray, int Size)                                     //method for converting string array to int array
        {
            int[] IntArray = new int[Size];
            int Iterator = 0;
            while (Iterator < Size)
            {
                foreach (string s in StringArray)
                {
                    int Number = int.Parse(s);
                    IntArray[Iterator] = Number;
                    Iterator++;
                }
            }
            Direction(IntArray);
            return IntArray;
        }
        static void Direction(int[] IntArray)
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Would you like to sort ascending or descending order?");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("1: Ascending.");
                Console.WriteLine("2: Descending.");
                int DirectionChoice = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();
            
                if (DirectionChoice == 1)
                {
                    SorterPicker(IntArray, 1);
                    return;
                }
                if (DirectionChoice == 2)
                {
                    SorterPicker(IntArray, 2);
                    return;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please enter valid option.");
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.White;
                    Direction(IntArray);
                }
            }
            catch
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Please enter valid option.");
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.White;
                Direction(IntArray);
            }
        }
        static void SorterPicker(int[] IntArray, int Direction)
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Which type of sort would you like to use?");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("1: Insertion sort.");
                Console.WriteLine("2: Bubble sort.");
                Console.WriteLine("3: Merge sort.");
                Console.WriteLine("4: Quicksort.");
                int SortChoice = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();
            
                if (SortChoice == 1)
                {
                    Sort.BackSorter(IntArray, Direction);
                    Printing.print(IntArray);
                    SearchPicker(IntArray, Direction);
                    return;
                }
                if (SortChoice == 2)
                {
                    Sort.PushSorter(IntArray, Direction);
                    Printing.print(IntArray);
                    SearchPicker(IntArray, Direction);
                    return;
                }
                if (SortChoice == 3)
                {
                    Sort.SortArray(IntArray, Direction,0);
                    Printing.print(IntArray);
                    SearchPicker(IntArray, Direction);
                    return;
                }
                if (SortChoice == 4)
                {
                    Sort.QuickSort(IntArray, Direction,0);
                    Printing.print(IntArray);
                    SearchPicker(IntArray, Direction);
                    return;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please enter valid option.");
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.White;
                    SorterPicker(IntArray, Direction);
                }
            }
            catch
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Please enter valid option.");
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.White;
                SorterPicker(IntArray, Direction);
            }
        }
        static void SearchPicker(int[] IntArray,int Direction)
        {
            try
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Which type of search would you like to do?");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("1: Binary search.");
                Console.WriteLine("2: Sequential search.");
                int SearchType = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();            
                if(SearchType == 1)
                {
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("What Number would you like to Search for? ");
                    Console.ForegroundColor = ConsoleColor.White;
                    int Number = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine();
                    Search.search(IntArray, Direction,SearchType, Number);
                    return;
                }
                if (SearchType == 2)
                {
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("What Number would you like to Search for? ");
                    Console.ForegroundColor = ConsoleColor.White;
                    int Number = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine();
                    Search.search(IntArray, Direction, SearchType,Number);
                    return;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please enter valid option.");
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.White;
                    SearchPicker(IntArray, Direction);
                }
            }
            catch
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Please enter valid option.");
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.White;
                SearchPicker(IntArray, Direction);
            }
        }
    }
}
