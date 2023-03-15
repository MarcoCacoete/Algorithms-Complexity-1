using Assessment_1_Algo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms_assessment_1
{
    class Sort
    {//sorting method
        public static (int[], int) backSorter(int[] road, int direction, int searchType)
        {
            int count = road.Count();
            int counter = 0;
            int temp;
            if (direction == 1)                                            //direction 1 sorts in ascending mode
            {
                try
                {
                    while (counter != road.Count() - 1)                    //counter to prevent out of index
                    {
                        if (road[counter] > road[counter + 1])             //checks number 1 index in front of index 0 and if larger, shifts positions
                        {
                            temp = road[counter];

                            road[counter] = road[counter + 1];

                            road[counter + 1] = temp;

                            counter++;             
                                                                                    //whenever a shift happens it is registered in this counter, this advances the operation
                            count--;
                        }
                        if (counter >= 2 && road[counter - 1] < road[counter - 2])  //second if to check if previous numbers are also higher than new number
                        {
                            temp = road[counter - 1];

                            road[counter - 1] = road[counter - 2];          //same algorithm repeats 

                            road[counter - 2] = temp;

                            counter -= 2;                                   //resets counter everytime to retroactively go back to check all previous values

                            count--;
                        }
                        if (road[counter] <= road[counter + 1])             //this prevents an infinite loop by advancing count
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

                Printing.print(road);

                Search.search(road, direction, searchType);

                return (road, direction);
            }
            else                                                                        //same algorithm as above but for descending sort, small changs made to operators
            {                                                                           //to make it work
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

            Printing.print(road);

            Search.search(road, direction, searchType);

            return (road, direction);
            }
        }
        public static (int[], int) pushSorter(int[] road, int direction, int searchType)
        {
            if (direction == 1)
            {
                PusherA(road);
            }
            if (direction == 2)
            {
                PusherD(road);  
            }

            (int[], int) PusherA(int[] road)
            {
                int count = road.Count();
                int counter = 0;
                int operations = 0;
                while (counter != road.Count() - 1)
                {
                    if (road[counter + 1] < road.Count() && road[counter] > road[counter + 1])
                    {
                        int temp = road[counter];
                        road[counter] = road[counter + 1];
                        road[counter + 1] = temp;
                        operations = 1;
                    }
                    counter++;
                }                
                if (operations == 1)
                {
                    PusherA(road);
                }
                else
                {
                    foreach (int i in road)
                    {
                        Console.WriteLine(i);
                    }
                    Console.WriteLine("end");
                }
                return (road, direction);
            }     
        
            (int[], int) PusherD(int[] road)
            {
                int count = road.Count();
                int counter = 0;
                int operations = 0;
                while (counter != road.Count() - 1)
                {
                    if (road[counter + 1] < road.Count() && road[counter] < road[counter + 1])
                    {
                        int temp = road[counter];
                        road[counter] = road[counter + 1];
                        road[counter + 1] = temp;
                        operations = 1;
                    }

                    counter++;
                }               
                if (operations == 1)
                {
                    PusherD(road);
                }
                else
                {
                    foreach (int i in road)
                    {
                        Console.WriteLine(i);
                    }
                    Console.WriteLine("end");
                }
                return (road, direction);
            }
            Printing.print(road);
            Search.search(road, direction, searchType);
            return (road, direction);
        }        
    }
}


