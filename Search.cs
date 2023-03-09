using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms_assessment_1
{
    class Search
    {
       public static void search(int[] road)
        {
            Console.WriteLine();
            Console.WriteLine("What number would you like to search for? ");
            int number = int.Parse(Console.ReadLine());
            Console.WriteLine();
            var foundNumber = binSearch(road, number);
            int counter = 0;
            int adjNumber = 0;
            while (foundNumber == -1)
            {
                counter++;
                adjNumber = number - counter;
                Console.WriteLine("Number not found, attempting to find closest number.");
                foundNumber = binSearch(road, adjNumber);
            }
            Console.WriteLine("The number " + adjNumber + " was found at index " + foundNumber);
        }
        static int binSearch(int[] array, int num)
        {
            int halfL = 0;
            int halfR = array.Count() - 1;
            int middle = (halfL + halfR) / 2;


            while (array[middle] != num && halfL < halfR)
            {

                if (num < array[middle])
                {
                    halfR = middle - 1;
                }
                else
                {
                    halfL = middle + 1;
                }

                middle = (halfL + halfR) / 2;
            }

            return (array[middle] != num) ? -1 : middle;
        }
    }
}
