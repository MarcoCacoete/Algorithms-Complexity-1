using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Assessment_1_Algo
{
    public class Search
    {       // Global variables to count number of steps to analyse efficiency.
        public static int HelperSteps = 0;
        public static int EfficiencySearch = 0;
        
            // Helper method to pick search type and sorting order.
        public static void search(int[] road, int rev, int SearchAlgo, int Number)
        {
            if (rev == 1)
            {
                HelperSteps++;
                SearchUp(road, rev, SearchAlgo, Number);
            }
            else
            {
                HelperSteps++;
                SearchDown(road, rev, SearchAlgo, Number);
            }
            
                         // Binary Search method
            static int BinSearch(int[] array, int num)    
            {
                int HalfLeft = 0;
                int HalfRight = array.Length - 1;
                int Middle;                              // Declares left and right limit indexes. 
                while (HalfLeft <= HalfRight)
                {
                    EfficiencySearch++;
                    Middle = (HalfLeft + HalfRight) / 2;    // Finds Middle point of array
                                                            // Best case result if value is Middle value of array.
                    if (num == array[Middle])               // It eventually will match the Middle result to searched value, unless not in array.
                    {
                        EfficiencySearch++;
                        return Middle;
                    }
                    else if (num < array[Middle])           // If value is smaller than array middle index it adjusts right index limit of search to middle index -1.
                    {
                        EfficiencySearch++;
                        HalfRight = Middle - 1;
                    }
                    else
                    {
                        EfficiencySearch++;
                        HalfLeft = Middle + 1;               // Otherwise it does the reverse.
                    }
                }
                return -1;                                   // Returns -1 when it doesn't find the value.
            }
            
                    // Same Search as above but for reverse sorting order.
            static int BinSearchR(int[] array, int num)     
            {
                int HalfLeft = 0;
                int HalfRight = array.Length - 1;
                int Middle;
                while (HalfLeft <= HalfRight)
                {
                    EfficiencySearch++;
                    Middle = (HalfLeft + HalfRight) / 2;

                    if (num == array[Middle])
                    {
                        EfficiencySearch++;
                        return Middle;
                    }
                    else if (num < array[Middle])
                    {
                        EfficiencySearch++;
                        HalfLeft = Middle + 1;

                    }
                    else
                    {
                        EfficiencySearch++;
                        HalfRight = Middle - 1;
                    }
                }
                return -1;
            }
            
                        // Method for sequential search.
            static int SeqSearch(int[] x, int y)
            {
                int counter = 0;
                
                foreach (int i in x)     // For each value in array x.
                {
                    EfficiencySearch++;

                    if (i == y)          // It will compare if value is same as the one we're looking for, if it is it returns that items index.
                    {
                        EfficiencySearch++;

                        return counter;
                    }
                    counter++;
                }
                
                return -1;              // If value is not found, it returns -1 to be fed to helper search method that adjusts number to closest number.
            }
                            // Helper method that finds all occurrences of value we are searching for
            static void MoreValues(int[] road, int Number, int foundNumber)
            {
                int reset = 0;      // Counter used to reset index so it can start searching in other direction.
                try                                                   
                {
                    while (road[foundNumber - 1] == Number)     // First it checks up the array for more of the same value
                    {
                        HelperSteps++;
                        foundNumber = foundNumber - 1;          // If it finds more of the number it will print its index.
                        Console.WriteLine("The Number " + Number + " was also found at index " + foundNumber);
                        reset++;
                    }
                }
                catch
                {
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("No more occurrences found before first location.");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine();
                }
                foundNumber = foundNumber + reset;  // This resets the index of the found number.
                int totalFound = reset + 1;         // This counter counts occurrences of value found.
                try
                {                   // Same method as above but now looking for locations after first location found.
                    while (road[foundNumber + 1] == Number)                        
                    {
                        HelperSteps++;
                        totalFound++;
                        foundNumber = foundNumber + 1;
                        Console.WriteLine("The Number " + Number + " was also found at index " + foundNumber);
                    }
                }
                catch
                {
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("No more occurrences found after first location.");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine();
                }
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Total occurrences of Number found: " + totalFound);  // Prints count for total values found
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine();
                
            }
            
                    // This method looks for the closest number found before the number we failed to find in an array.
            static void ClosestNumberUp(int[] road, int Number, int foundNumber, int SearchAlgo)
            {
                int adjNumber = 0;
                int originalNumber = Number;
                while (foundNumber == -1)          // When Search fails to find value, value is adjusted to closest value to be found.
                {
                    HelperSteps++;
                    adjNumber = Number - 1;
                    Console.ForegroundColor = ConsoleColor.Green;               // Message to inform user the original number wasn't found.
                    Console.WriteLine("Number " + Number + " not found, attempting to find closest Number."); 
                    Console.ForegroundColor = ConsoleColor.White;   
                    Console.WriteLine();

                    if (SearchAlgo == 1)        // Honors original choice of algorithm to look for new values.
                    {
                        HelperSteps++;
                        foundNumber = BinSearch(road, adjNumber);
                        Number--;
                    }
                    if (SearchAlgo == 2)
                    {
                        HelperSteps++;
                        foundNumber = SeqSearch(road, adjNumber);
                        Number--;
                    }
                }
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("The Number " + Number + " was first found at index " + foundNumber);   // New value is found and it's location revealed.
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Searching for more locations for same value.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine();
                MoreValues(road, Number, foundNumber);              // Calls method that finds more of the same value.

                Number = originalNumber;
                foundNumber = -1;
            }
                        // Once again this method is same as above in every way, except it looks for closest number after value not found.
            static void ClosestNumberDown(int[] road, int Number, int foundNumber, int SearchAlgo)
            {
                int adjNumber = 0;
                while (foundNumber == -1)                                
                {
                    HelperSteps++;
                    adjNumber = Number + 1;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Number " + Number + " not found, attempting to find closest Number.");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine();

                    if (SearchAlgo == 1)
                    {
                        HelperSteps++;
                        foundNumber = BinSearch(road, adjNumber);
                        Number++;
                    }
                    if (SearchAlgo == 2)
                    {
                        HelperSteps++;
                        foundNumber = SeqSearch(road, adjNumber);
                        Number++;
                    }
                }
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("The Number " + Number + " was first found at index " + foundNumber);     
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Searching for more locations for same value.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine();
                MoreValues(road, Number, foundNumber);
            }
                
            // Once again this method is same as above in every way, except it looks for closest number before value not found in reverse sorted array.
            static void ClosestNumberUpReverse(int[] road, int Number, int foundNumber, int SearchAlgo)
            {
                int adjNumber = 0;
                int originalNumber = Number;
                while (foundNumber == -1)                                 
                {
                    HelperSteps++;
                    adjNumber = Number - 1;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Number " + Number + " not found, attempting to find closest Number.");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine();

                    if (SearchAlgo == 1)
                    {
                        HelperSteps++;
                        foundNumber = BinSearchR(road, adjNumber);
                        Number--;
                    }
                    if (SearchAlgo == 2)
                    {
                        HelperSteps++;
                        foundNumber = SeqSearch(road, adjNumber);
                        Number--;
                    }
                }
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("The Number " + Number + " was first found at index " + foundNumber);     
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Searching for more locations for same value.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine();
                MoreValues(road, Number, foundNumber);

                Number = originalNumber;
                foundNumber = -1;
            }
            
            // Once again this method is same as above in every way, except it looks for closest number after value not found in reverse sorted array.
            static  void ClosestNumberDownReverse(int[] road, int Number, int foundNumber,int SearchAlgo)
            {
                int adjNumber = 0;
                while (foundNumber == -1)                                   
                {
                    HelperSteps++;
                    adjNumber = Number + 1;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Number " + Number + " not found, attempting to find closest Number.");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine();

                    if (SearchAlgo == 1)
                    {
                        HelperSteps++;
                        foundNumber = BinSearchR(road, adjNumber);
                        Number++;
                    }
                    if (SearchAlgo == 2)
                    {
                        HelperSteps++;
                        foundNumber = SeqSearch(road, adjNumber);
                        Number++;
                    }
                }
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("The Number " + Number + " was first found at index " + foundNumber);     
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Searching for more locations for same value.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine();
                MoreValues(road, Number, foundNumber);
            }
            
            // Helper method to search algorithm it gives best case results in case number searched is lower or higher than firs and last index.
            // It also is responsible for calling more values method and closest number methods passing correct sort order and search type picked.
            static void SearchUp(int[] road, int rev, int SearchAlgo,int Number)
            {
                if (Number > road[road.Count() - 1])        // If statements prevent Search of out of index values, return best case result instead.
                {                                           // and all its occurrences.
                    HelperSteps++;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Number " + Number + " not found!");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine();
                    Number = road[road.Count() - 1];
                    int index = road.Count() - 1;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("The closest Number found was " + Number + " found at index " + index);
                    Console.ForegroundColor = ConsoleColor.White;
                    MoreValues(road, Number, index);
                    return;
                }
                if (Number < road[0])
                {
                    HelperSteps++;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Number " + Number + " not found!");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine();
                    Number = road[0];
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("The closest Number found was " + Number + " found at index 0.");
                    Console.ForegroundColor = ConsoleColor.White;
                    MoreValues(road, Number, 0);
                    return;
                }
                else                         // If above is not the case, it starts calling search methods.
                {                   
                    HelperSteps++;
                    int foundNumber = 0;

                    if (SearchAlgo == 1)
                    {
                        HelperSteps++;
                        foundNumber = BinSearch(road, Number);   //calls up binary Search for value selected on array selected
                    }
                    if (SearchAlgo == 2)
                    {
                        HelperSteps++;
                        foundNumber = SeqSearch(road, Number);  // calls sequential Search for value selected on corresponding array
                    }
                    if (foundNumber == -1)
                    {
                        HelperSteps++;
                        ClosestNumberUp(road, Number, foundNumber, SearchAlgo);
                        ClosestNumberDown(road, Number, foundNumber, SearchAlgo);
                        return;
                    }
                    else                      // I value is found it tries to find more occurrences of same value.
                    {
                        HelperSteps++;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("The Number " + Number + " was first found at index " + foundNumber);     
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Searching for more locations for same value.");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine();
                        MoreValues(road, Number, foundNumber);
                    }
                }
            }
            
            // Again same method as above but for reverse sort order.
            static void SearchDown(int[] road, int rev, int SearchAlgo,int Number)                                                                      // same exact methods only for descending sort
            {
                if (Number < road[road.Count() - 1])
                {
                    HelperSteps++;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Number " + Number + " not found!");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine();
                    Number = road[road.Count() - 1];
                    int index = road.Count() - 1;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("The closest Number found was " + Number + " found at index " + index);
                    Console.ForegroundColor = ConsoleColor.White;
                    MoreValues(road, Number, index);

                    return;
                }
                if (Number > road[0])
                {
                    HelperSteps++;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Number " + Number + " not found!");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine();
                    Number = road[0];
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("The closest Number found was " + Number + " found at index 0.");
                    Console.ForegroundColor = ConsoleColor.White;
                    MoreValues(road, Number, 0);

                    return;
                }
                else
                {
                    HelperSteps++;
                    int foundNumber = 0;

                    if (SearchAlgo == 1)
                    {
                        HelperSteps++;
                        foundNumber = BinSearchR(road, Number);   
                    }
                    if (SearchAlgo == 2)
                    {
                        HelperSteps++;
                        foundNumber = SeqSearch(road, Number);
                    }


                    if (foundNumber == -1)
                    {
                        HelperSteps++;
                        ClosestNumberUpReverse(road, Number, foundNumber, SearchAlgo);
                        ClosestNumberDownReverse(road, Number, foundNumber, SearchAlgo);
                        return;
                    }
                    else
                    {
                        HelperSteps++;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("The Number " + Number + " was first found at index " + foundNumber);     
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Searching for more locations for same value.");
                        Console.ForegroundColor = ConsoleColor.White; 
                        Console.WriteLine();
                        MoreValues(road, Number, foundNumber);
                    }                    
                }
            }
        }
    }
}

    

