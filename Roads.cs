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
    static class Roads
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

            int[] arrayRoad1256 = new int[256];
            int iterator = 0;
            while (iterator < 256)
            {
                foreach (string s in roadsArray1256)
                {
                    int number = int.Parse(s);

                    arrayRoad1256[iterator] = number;

                    //Console.WriteLine(number);

                    iterator++;
                }
            }
            Console.WriteLine("end");
            Console.WriteLine();
             backSorter(arrayRoad1256);
           // pushSorter(arrayRoad1256);
        }
        static void backSorter(int[] road)
        {
            int count = road.Count();
            int counter = 0;
            int temp;
            try
            {
                while (counter != road.Count() - 1)
                {
                    if (road[counter] > road[counter + 1])
                    {
                        temp = road[counter];

                        road[counter] = road[counter + 1];

                        road[counter + 1] = temp;
                        counter++;
                        count--;
                    }
                    if (counter > 2 && road[counter - 1] < road[counter - 2])
                    {
                        temp = road[counter - 1];

                        road[counter - 1] = road[counter - 2];

                        road[counter - 2] = temp;

                        counter -= 3;

                        count--;
                    }
                    if (road[counter] <= road[counter + 1])
                        counter++;
                }
            }
            catch
            {
                Console.WriteLine("Fail");
                return;               
            }
            foreach (int i in road)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("Successfully completed.");

        }
        /* static void pushSorter(int[] road)
         {
             pusher(road);
             static void pusher(int[] road)
             {
                 int count = road.Count();
                 int counter = 0;
                 int operations = 0;
                 while (counter != road.Count() - 1)
                 {
                     if (road[counter + 1]<road.Count() && road[counter] > road[counter + 1])
                     {
                         int temp = road[counter];
                         road[counter] = road[counter + 1];
                         road[counter + 1] = temp;
                         operations=1;
                     }
                     elseif(road[counter+1]!=null)
                     if (road[counter + 2]<road.Count() && road[counter] + 1 > road[counter + 2])
                     {
                         int temp = road[counter + 1];
                         road[counter + 1] = road[counter + 2];
                         road[counter + 2] = temp;
                         counter++;
                         operations=1;
                     }
                     counter++;
                 }
                 foreach (int i in road)
                 {
                     Console.WriteLine("Success!" + i);
                 }
                 if (operations == 1)
                 {
                     pusher(road);


                 }
                 else
                 {
                     foreach (int i in road)
                     {
                         Console.WriteLine("Success!" + i);
                     }
                     Console.WriteLine("end");
                 }

             }

         }*/

    }
}
