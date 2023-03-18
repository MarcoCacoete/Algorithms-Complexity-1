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
    {
        public static int HelperSteps = 0;
        public static int EfficiencySearch = 0;
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


            static int BinSearchR(int[] array, int num)     //same Search as above but for reverse sorting
            {
                int HalfLeft = 0;
                int HalfRight = array.Length - 1;
                int Middle = (HalfLeft + HalfRight) / 2;
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
            static int BinSearch(int[] array, int num)    //the only algorithm I got working so far for Searching basic binary Search
            {
                int HalfLeft = 0;
                int HalfRight = array.Length - 1;
                int Middle = (HalfLeft + HalfRight) / 2;
                while (HalfLeft <= HalfRight)
                {
                    EfficiencySearch++;
                    Middle = (HalfLeft + HalfRight) / 2;    //finds Middle point of array
                    if (num == array[Middle])               //best case result if value is Middle of array or when it eventually is the Middle result or not
                    {
                        EfficiencySearch++;
                        return Middle;
                    }
                    else if (num < array[Middle])           //if not it checks if it's larger or smaller than Middle, and adjusts Middle to new Middle
                    {
                        EfficiencySearch++;
                        HalfRight = Middle - 1;
                    }
                    else
                    {
                        EfficiencySearch++;
                        HalfLeft = Middle + 1;                 //same as above
                    }
                }
                return -1;                                  //return for when it doesn't find the value
            }

            static int SeqSearch(int[] x, int y)
            {
                int counter = 0;
                while (counter <= x.Count() - 1)
                {
                    EfficiencySearch++;
                    foreach (int i in x)
                    {
                        EfficiencySearch++;

                        if (i == y)
                        {
                            EfficiencySearch++;

                            return counter;
                        }
                        counter++;
                    }
                }
                return -1;
            }

            static void MoreValues(int[] road, int Number, int foundNumber)
            {
                while (true)
                {
                    HelperSteps++;
                    int up = 0;
                    int down = 0;
                    int reset = 0;
                    try                                                   //next few blocks of code are for finding all occurrences of a value in array
                    {
                        if (road[foundNumber - 1] == Number && up == 0)
                        {
                            HelperSteps++;
                            while (road[foundNumber - 1] == Number)       //first it checks up the array for more of the same value
                            {
                                HelperSteps++;
                                foundNumber = foundNumber - 1;
                                Console.WriteLine("The Number " + Number + " was also found at index " + foundNumber);
                                reset++;
                            }
                            up = 1;
                        }
                    }
                    catch
                    {
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("No more occurrences found in this direction.");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine();
                    }
                    foundNumber = foundNumber + reset;
                    int totalFound = reset + 1;
                    try
                    {
                        if (road[foundNumber + 1] == Number && down == 0)
                        {
                            HelperSteps++;
                            while (road[foundNumber + 1] == Number)                             //then it starts going down to check for same
                            {
                                HelperSteps++;
                                totalFound++;
                                foundNumber = foundNumber + 1;
                                Console.WriteLine("The Number " + Number + " was also found at index " + foundNumber);
                            }
                            down = 1;
                        }
                    }
                    catch
                    {
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("No more occurrences found in this direction.");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine();
                    }
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Total occurrences of Number found: " + totalFound);  //prints count for total values found
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine();
                    break;
                }
            }
            static void ClosestNumberUp(int[] road, int Number, int foundNumber, int SearchAlgo)
            {
                int adjNumber = 0;
                int originalNumber = Number;
                while (foundNumber == -1)                                   //when Search fails to find value, value is adjusted to closest value to be found
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
                Console.WriteLine("The Number " + Number + " was first found at index " + foundNumber);     //value is found
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
            static void ClosestNumberDown(int[] road, int Number, int foundNumber, int SearchAlgo)
            {
                int adjNumber = 0;
                while (foundNumber == -1)                                   //when Search fails to find value, value is adjusted to closest value to be found
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
                Console.WriteLine("The Number " + Number + " was first found at index " + foundNumber);     //value is found
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Searching for more locations for same value.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine();
                MoreValues(road, Number, foundNumber);
            }
            static void ClosestNumberUpReverse(int[] road, int Number, int foundNumber, int SearchAlgo)
            {
                int adjNumber = 0;
                int originalNumber = Number;
                while (foundNumber == -1)                                   //when Search fails to find value, value is adjusted to closest value to be found
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
                Console.WriteLine("The Number " + Number + " was first found at index " + foundNumber);     //value is found
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
            static  void ClosestNumberDownReverse(int[] road, int Number, int foundNumber,int SearchAlgo)
            {
                int adjNumber = 0;
                while (foundNumber == -1)                                   //when Search fails to find value, value is adjusted to closest value to be found
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
                Console.WriteLine("The Number " + Number + " was first found at index " + foundNumber);     //value is found
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Searching for more locations for same value.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine();
                MoreValues(road, Number, foundNumber);
            }
            static void SearchUp(int[] road, int rev, int SearchAlgo,int Number)
            {
                if (Number > road[road.Count() - 1])                                    //if statements prevent Search of out of index values
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
                else
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
                    else
                    {
                        HelperSteps++;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("The Number " + Number + " was first found at index " + foundNumber);     //value is found
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
                        foundNumber = BinSearchR(road, Number);   //calls up binary Search for value selected on array selected
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
                        Console.WriteLine("The Number " + Number + " was first found at index " + foundNumber);     //value is found
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

    

