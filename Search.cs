using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Algorithms_assessment_1
{
   public class Search
   {
        public static void search(int[] road,int rev,int searchAlgo)
        {
            Console.WriteLine();
            Console.WriteLine("What number would you like to search for? ");
            int number = int.Parse(Console.ReadLine());
            Console.WriteLine();
            if (rev == 1)
            {
                if (number > road[road.Count() - 1])                                    //if statements prevent search of out of index values
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
                    int foundNumber = 0;

                    if (searchAlgo == 1)
                    {
                         foundNumber = BinSearch(road, number);   //calls up binary search for value selected on array selected
                    }
                    if(searchAlgo ==2)
                    {
                        foundNumber = SeqSearch(road, number);
                    }
                    else
                    {
                        Console.WriteLine("Pick correct option.");
                    }
                       
                    int adjNumber = 0;

                    while (foundNumber == -1)                                   //when search fails to find value, value is adjusted to closest value to be found
                    {
                        adjNumber = number - 1;
                        Console.WriteLine("Number " + number + " not found, attempting to find closest number.");
                        Console.WriteLine();
                        if (searchAlgo == 1)
                        {                        
                            foundNumber = BinSearch(road, adjNumber);
                            number--;
                        }
                        if (searchAlgo == 2)
                        {
                            foundNumber = SeqSearch(road, adjNumber);
                            number--;
                        }
                    }
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("The number " + number + " was first found at index " + foundNumber);     //value is found
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine();
                    Console.WriteLine("Searching for more locations for same value.");
                    Console.WriteLine();

                    while (true)
                    {
                        int up = 0;
                        int down = 0;
                        int reset = 0;

                        try                                                                              //next few blocks of code are for finding all occurences of a value in array
                        {
                            if (road[foundNumber - 1] == number && up == 0)
                            {
                                while (road[foundNumber - 1] == number)                         //first it checks up the array for more of the same value
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
                                while (road[foundNumber + 1] == number)                             //then it starts going down to check for same
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
                        Console.WriteLine("Total occurrences of number found: " + totalFound);  //prints count for total values found
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine();
                        break;
                    }
                }
            }
            if (rev == 2)                                                                       // same exact methods only for descending sort
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
                    var foundNumber = BinSearchR(road, number);
                    int counter = 0;
                    int adjNumber = 0;
                    if (foundNumber == -1)
                    {
                        counter++;
                        adjNumber = number - counter;
                        Console.WriteLine("Number " + number + " not found, attempting to find closest number.");
                        Console.WriteLine();

                        foundNumber = BinSearchR(road, adjNumber);
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
                        Console.WriteLine("Total occorrunces of number found: " + totalFound);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine();
                        break;
                    }
                }
            }
        }
        static int BinSearch(int[] array, int num)    //the only algorithm I got working so far for searching basic binary search
        {
            int halfL = 0;
            int halfR = array.Length - 1;
            int middle = (halfL + halfR) / 2;


            while (halfL<=halfR)                            
            {
                middle = (halfL + halfR) / 2;           //finds middle point of array

                if (num == array[middle])               //best case result if value is middle of array or when it eventually is the middle result or not
                {
                    return middle;
                }
                else if (num < array[middle])           //if not it checks if it's larger or smaller than middle, and adjusts middle to new middle
                {
                    halfR = middle - 1;
                    //halfL = middle + 1;

                }
                else
                {
                    halfL = middle + 1;                 //same as above
                   // halfR = middle - 1;

                }
            }
            return -1;                                  //return for when it doesn't find the value
        }
        static int BinSearchR(int[] array, int num)     //same search as above but for reverse sorting
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
      static int SeqSearch(int[] x,int y)
        {
            int counter = 0;
            int occurences = 0;

            while (counter <= x.Count()-1)
            {
                foreach (int i in x)
                {

                    if (i == y)
                    {
                        occurences++;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("The number " + y + " was first found at index " + counter);
                        Console.ForegroundColor= ConsoleColor.White;
                        Console.WriteLine();
                        while (x[counter + 1] == y)
                        {
                            occurences++;
                            counter++;
                            Console.WriteLine("The number " + y + " was also found at index " + counter);                            
                        }
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Total occurences of found value: " + occurences);
                        Console.ForegroundColor = ConsoleColor.White;
                        System.Environment.Exit(0);
                    }
                    
                    counter++;
                }
            }
            return -1;
        }
    }
}