using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment_1_Algo
{
    class Printing
    {
        public static void print(int[] sortedArray)
        {
            try                                                                             //method for printing every nth value (10th or 50th)
            {
                int number = 10;
                int increment = 10;
                if (sortedArray.Length > 512)
                {
                    number = 50;
                    increment = 50;
                }
                foreach (int i in sortedArray)
                {
                    Console.WriteLine(i);
                }
                Console.WriteLine("end");
                while (true)
                {

                    Console.WriteLine("Value " + sortedArray[0 + number] + " found at index " + number);
                    number += increment;

                }               
            }
            catch
            {
                
                Console.WriteLine();
                Console.WriteLine("Finished writing nth values.");
            }
        }
    }
}
