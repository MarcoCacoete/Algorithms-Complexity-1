using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms_assessment_1
{
    class Search
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
                    int counter = 0;
                    int adjNumber = 0;
                    if (foundNumber == -1)
                    {
                        counter++;
                        adjNumber = number - counter;
                        Console.WriteLine("Number " + number + " not found, attempting to find closest number.");
                        foundNumber = binSearch(road, adjNumber);
                        number--;
                    }
                    Console.WriteLine("The number " + number + " was found at index " + foundNumber);
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
                        foundNumber = binSearchR(road, adjNumber);
                        number--;
                    }
                    Console.WriteLine("The number " + number + " was found at index " + foundNumber);
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