using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Algorithms_assessment_1
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

            roadsArray1256 = File.ReadAllLines("Road_1_256.txt");
            roadsArray2256 = File.ReadAllLines("Road_2_256.txt");
            roadsArray3256 = File.ReadAllLines("Road_3_256.txt");
            roadsArray12048 = File.ReadAllLines("Road_1_2048.txt");
            roadsArray22048 = File.ReadAllLines("Road_2_2048.txt");
            roadsArray32048 = File.ReadAllLines("Road_3_2048.txt");

            Console.WriteLine("Which array would you like to load? ");
            Console.WriteLine("1: Road 1 256.");
            Console.WriteLine("2: Road 2 256.");
            Console.WriteLine("3: Road 3 256.");
            Console.WriteLine("4: Road 1 2048.");
            Console.WriteLine("5: Road 2 2048.");
            Console.WriteLine("6: Road 3 2048.");
            Console.WriteLine("7: Merged 1 and 3");
            Console.WriteLine("8: Merged 4 and 6");

            string Choice = Console.ReadLine();

            if( Choice == "1")
                converter(roadsArray1256,256);
            if( Choice == "2")
                converter(roadsArray2256,256);
            if( Choice == "3")
                converter(roadsArray3256, 256);
            if( Choice == "4")
                converter(roadsArray12048,2048);
            if( Choice == "5")
                converter(roadsArray22048,2048);
            if( Choice == "6")
                converter(roadsArray32048,2048);
            if (Choice == "7")
            {
                string[] merged = roadsArray1256.Concat(roadsArray3256).ToArray();
                converter(merged, merged.Length);
            }
            if (Choice == "8")
            {
                string[] merged = roadsArray12048.Concat(roadsArray32048).ToArray();
                converter(merged, merged.Length);
            }

            //converts strings to ints in 256 index arrays
            int[] converter(string[]array,int size)
           {                
                int[] intArray = new int[size];
                int iterator = 0;

                while (iterator < size)      
                {
                    foreach (string s in array)
                    {
                        int number = int.Parse(s);

                        intArray[iterator] = number;

                        //Console.WriteLine(number);

                        iterator++;
                    }
                }
                Console.WriteLine("end");

                Console.WriteLine();

                Console.WriteLine("Would you like to sort ascending or descending?");

                Console.WriteLine();

                Console.WriteLine("1: Ascending.");

                Console.WriteLine("2: Descending.");

                int choice = int.Parse(Console.ReadLine());
               
                Sort.backSorter(intArray,choice);

                // pushSorter(arrayRoad1256);

                return intArray;
            }
        }       
    }
}
