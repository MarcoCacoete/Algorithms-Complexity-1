using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms_assessment_1
{
   public class Search
    {
        public static void search(int[] road,int rev)
        {
            Console.WriteLine();
            Console.WriteLine("What number would you like to search for? ");
            int number = int.Parse(Console.ReadLine());
            Console.WriteLine();
            if (rev == 1)
            {
                if (number > road[road.Count() - 1])
                {
                    Console.WriteLine("Number " + number + " not found!");
                    Console.WriteLine();
                    number = road[road.Count() - 1];
                    int index = road.Count() - 1;
                    Console.WriteLine("The closest number found was " + number + " found at index " + index);
                    return;
                }
                if (number < road[0])
                {
                    Console.WriteLine("Number " + number + " not found!");
                    Console.WriteLine();
                    number = road[0];
                    Console.WriteLine("The closest number found was " + number + " found at index 0.");
                    return;
                }
                else
                {                                 
                    var foundNumber = binSearch(road, number);
                    int adjNumber = 0;

                    while (foundNumber == -1)
                    {                                                    
                            adjNumber = number - 1;
                            Console.WriteLine("Number " + number + " not found, attempting to find closest number.");
                            Console.WriteLine();

                            foundNumber = binSearch(road, adjNumber);
                            number--;                      
                    }
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("The number " + number + " was first found at index " + foundNumber);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine();
                    Console.WriteLine("Searching for more locations for same value.");
                    Console.WriteLine();

                    while (true)
                    {
                        int up = 0;
                        int down = 0;
                        int reset = 0;

                        try
                        {
                            if (road[foundNumber - 1] == number && up == 0)
                            {
                                while (road[foundNumber - 1] == number)
                                {
                                    foundNumber = foundNumber - 1;
                                    Console.WriteLine("The number " + number + " was also found at index " + foundNumber);
                                    reset++;
                                }
                                up = 1;
                                
                            }
                        }
                        catch
                        {
                        }
                        foundNumber = foundNumber + reset;
                        int totalFound = reset + 1;
                        try
                        {
                            if (road[foundNumber + 1] == number && down == 0)
                            {
                                while (road[foundNumber + 1] == number)
                                {
                                    totalFound++;
                                    foundNumber = foundNumber + 1;
                                    Console.WriteLine("The number " + number + " was also found at index " + foundNumber);
                                }
                                down = 1;
                            }
                        }
                        catch
                        {
                            Console.WriteLine();
                        }
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Total occorrunces of number found - " + totalFound);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine();
                        break;
                    }
                }
            }
            if (rev == 2)
            {
                if (number < road[road.Count() - 1])
                {
                    Console.WriteLine("Number "+number+" not found!");
                    Console.WriteLine();
                    number = road[road.Count() - 1];
                    int index = road.Count() - 1;
                    Console.WriteLine("The closest number found was " + number + " found at index " + index);
                    return;
                }
                if (number > road[0])
                {
                    Console.WriteLine("Number " + number + " not found!");
                    Console.WriteLine();
                    number = road[0];
                    Console.WriteLine("The closest number found was " + number + " found at index 0.");
                    return;
                }
                else
                {
                    var foundNumber = binSearchR(road, number);
                    int counter = 0;
                    int adjNumber = 0;
                    if (foundNumber == -1)
                    {
                        counter++;
                        adjNumber = number - counter;
                        Console.WriteLine("Number " + number + " not found, attempting to find closest number.");
                        Console.WriteLine();

                        foundNumber = binSearchR(road, adjNumber);
                        number--;
                    }
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("The number " + number + " was first found at index " + foundNumber);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine();
                    Console.WriteLine("Searching for more locations for same value.");
                    Console.WriteLine();

                    while (true)
                    {
                        int up = 0;
                        int down = 0;
                        int reset = 0;
                        try
                        {                            
                            if (road[foundNumber - 1] == number && up == 0)
                            {
                                while (road[foundNumber - 1] == number)
                                {
                                    foundNumber = foundNumber - 1;
                                    Console.WriteLine("The number " + number + " was also found at index " + foundNumber);
                                    reset++;
                                }
                                up = 1;
                            }
                        }
                        catch
                        {
                            Console.WriteLine();
                        }
                        foundNumber = foundNumber + reset;
                        int totalFound = reset + 1;
                        try
                        {
                            if (road[foundNumber + 1] == number && down == 0)
                            {
                                while (road[foundNumber + 1] == number)
                                {
                                    totalFound++;
                                    foundNumber = foundNumber + 1;
                                    Console.WriteLine("The number " + number + " was also found at index " + foundNumber);
                                }
                                down = 1;
                            }
                        }
                        catch
                        {
                            Console.WriteLine();
                        }
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Total occorrunces of number found - " + totalFound);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine();
                        break;
                    }
                }
            }
        }
        static int binSearch(int[] array, int num)
        {
            int halfL = 0;
            int halfR = array.Length - 1;
            int middle = (halfL + halfR) / 2;


            while (halfL<=halfR)
            {
                middle = (halfL + halfR) / 2;

                if (num == array[middle])
                {
                    return middle;
                }
                else if (num < array[middle])    
                {
                    halfR = middle - 1;
                    //halfL = middle + 1;

                }
                else
                {
                    halfL = middle + 1;
                   // halfR = middle - 1;

                }
            }
            return -1;
        }
        static int binSearchR(int[] array, int num)
        {
            int halfL = 0;
            int halfR = array.Length - 1;
            int middle = (halfL + halfR) / 2;


            while (halfL <= halfR)
            {
                middle = (halfL + halfR) / 2;

                if (num == array[middle])
                {
                    return middle;
                }
                else if (num < array[middle])
                {
                    halfL = middle + 1;

                }
                else
                {
                    halfR = middle - 1;

                }
            }
            return -1;
        }
    }
}