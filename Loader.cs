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
        {   // Declares string arrays with names matching .txt files.
            string[] RoadsArray1256;
            string[] RoadsArray2256;
            string[] RoadsArray3256;
            string[] RoadsArray12048;
            string[] RoadsArray22048;
            string[] RoadsArray32048;
            // Reads all txt files and adds strings into arrays.
            RoadsArray1256 = File.ReadAllLines("Road_1_256.txt");               
            RoadsArray2256 = File.ReadAllLines("Road_2_256.txt");
            RoadsArray3256 = File.ReadAllLines("Road_3_256.txt");
            RoadsArray12048 = File.ReadAllLines("Road_1_2048.txt");
            RoadsArray22048 = File.ReadAllLines("Road_2_2048.txt");
            RoadsArray32048 = File.ReadAllLines("Road_3_2048.txt");
            try
            {   // Prompts for user to pick which array to use wrapped in try catch method for error handling.
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
                // Conditions to execute correct Converter method for respective array, and convert that array to int array.
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
                if (RoadChoice == 7)                                 
                {
                    string[] merged = RoadsArray1256.Concat(RoadsArray3256).ToArray();
                    Converter(merged, merged.Length);
                    return;
                }                                           // Merges and concatenates arrays if options 7 or 8 are selected, then converts type of array to int array.
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
            catch       // Two ways of handling user input errors, same methods used for rest of prompts.
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Please enter valid option.");
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.White;
                loader();
            }
        }
                        // Method for converting string arrays to int arrays.
        static int[] Converter(string[] StringArray, int Size)                                     
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
        
                        // Method used to give the user a choice of sorting direction.
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
                }                               // Depending on choice, the respective arguments are used for execution of sorter picker method below.
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
                        // Method responsible for giving the user a choice of sorting method to be used.
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
                        // Depending on choice, a method will be executed, then followed by call to the search method. message is displayed with some information for user in a different color.
                if (SortChoice == 1)
                {
                    Sort.BackSorter(IntArray, Direction);  //Sort method is called, same for every case below.
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Total amount of steps: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(Sort.Efficiency);
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine(); 
                    Console.WriteLine("Press any key to continue.");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.ReadLine();
                    Printing.print(IntArray);               // Array printing method is called to print sorted array and 'nth values.
                    SearchPicker(IntArray, Direction);      // Search method is called with sorted array as argument. 
                    return;
                }                                           // All following blocks of code do the same  as above.
                if (SortChoice == 2)
                {
                    Sort.PushSorter(IntArray, Direction);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Total amount of steps: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(Sort.Efficiency);
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine(); 
                    Console.WriteLine("Press any key to continue.");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.ReadLine();
                    Printing.print(IntArray);
                    SearchPicker(IntArray, Direction);
                    return;
                }
                if (SortChoice == 3)
                {
                    Sort.SortArray(IntArray, Direction);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Total amount of steps: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(Sort.Efficiency);
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine(); 
                    Console.WriteLine("Press any key to continue.");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.ReadLine();  
                    Printing.print(IntArray);
                    SearchPicker(IntArray, Direction);
                    return;
                }
                if (SortChoice == 4)
                {
                    Sort.QuickSort(IntArray, Direction);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Total amount of steps: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(Sort.Efficiency);
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine(); 
                    Console.WriteLine("Press any key to continue.");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.ReadLine();  
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
        
                    // Same logic as above, user choice of type of searching algorithm.
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
                    Search.search(IntArray, Direction,SearchType, Number);          // Calls helper method search with search direction search type and value to be searched as arguments.
                    Console.ForegroundColor = ConsoleColor.Red;
                    int TotalSteps = Search.EfficiencySearch + Search.HelperSteps;
                    Console.Write("Total amount of search algorithm steps: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(Search.EfficiencySearch);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Total amount of search helper method steps: ");
                    Console.ForegroundColor = ConsoleColor.Green;                           // This block prints operations steps taken to find values. The following block does the same.
                    Console.WriteLine(Search.HelperSteps);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Total Steps combined: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(+ TotalSteps);
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("Press any key to continue.");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.ReadLine(); 
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
                    Console.ForegroundColor = ConsoleColor.Red;
                    int TotalSteps = Search.EfficiencySearch + Search.HelperSteps;
                    Console.Write("Total amount of search algorithm steps: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(Search.EfficiencySearch);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Total amount of search helper method steps: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(Search.HelperSteps);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Total Steps combined: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(+ TotalSteps);
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("Press any key to continue.");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.ReadLine(); 
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
