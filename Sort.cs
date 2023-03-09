using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms_assessment_1
{
   class Sort
   {
       public static int[] backSorter(int[] road)
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
            Search.search(road);

            return road;

        }
    }
}
