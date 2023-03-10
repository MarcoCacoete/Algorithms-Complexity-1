using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms_assessment_1
{
   class Sort
   {
       public static (int[],int) backSorter(int[] road,int direction)
       {
            int count = road.Count();
            int counter = 0;
            int temp;
            if (direction == 1)
            {
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
                        if (counter >= 2 && road[counter - 1] < road[counter - 2])
                        {
                            temp = road[counter - 1];

                            road[counter - 1] = road[counter - 2];

                            road[counter - 2] = temp;

                            counter -= 2;

                            count--;
                        }
                        if (road[counter] <= road[counter + 1])
                            counter++;
                    }
                }
                catch
                {
                    Console.WriteLine("Fail");
                    Console.ReadLine();
                }
                foreach (int i in road)
                {
                    Console.WriteLine(i);
                }
                Console.WriteLine("Successfully completed.");

                try
                {
                    int number = 10;
                    int increment = 10;
                    if (road.Length > 512)
                    {
                        number = 50;
                        increment = 50;
                    }
                    while (true)
                    {                      
                        
                        Console.WriteLine("Value "+road[0 + number]+" found at index "+number);
                        number += increment;
                        
                    }
                }
                catch
                {
                    Console.WriteLine();
                    Console.WriteLine("Finished writing nth values.");
                }

                Search.search(road,direction);

                return (road, direction);
            }
            else
            {
                try
                {
                    while (counter != road.Count() - 1)
                    {
                        if (road[counter] < road[counter + 1])
                        {
                            temp = road[counter];

                            road[counter] = road[counter + 1];

                            road[counter + 1] = temp;
                            counter++;
                            count--;
                        }
                        if (counter >= 2 && road[counter - 1] > road[counter - 2])
                        {
                            temp = road[counter - 1];

                            road[counter - 1] = road[counter - 2];

                            road[counter - 2] = temp;

                            counter -= 2;

                            count--;
                        }
                        if (road[counter] >= road[counter + 1])
                            counter++;
                    }
                }
                catch
                {
                    Console.WriteLine("Fail");
                    Console.ReadLine();
                }
                foreach (int i in road)
                {
                    Console.WriteLine(i);
                }
                Console.WriteLine("Successfully completed.");
                try
                {
                    int number = 10;
                    int increment = 10;
                    if (road.Length > 512)
                    {
                        number = 50;
                        increment = 50;
                    }
                    while (true)
                    {

                        Console.WriteLine("Value " + road[0 + number] + " found at index " + number);
                        number += increment;

                    }
                }
                catch
                {
                    Console.WriteLine();
                    Console.WriteLine("Finished writing nth values.");
                }
                Search.search(road, direction);

                return (road,direction);
            }                    
       }
   }
}
