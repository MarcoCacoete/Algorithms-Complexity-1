using Assessment_1_Algo;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment_1_Algo
{
    class Sort
    {                   //sorting methods

        public static int Efficiency = 0;
        public static (int[], int) BackSorter(int[] IntArray, int Direction)
        {
            int Counter = 0;
            Efficiency = 0;
            int Temporary;
            if (Direction == 1)                                            //Direction 1 sorts in ascending mode
            {
                Efficiency++;
                try
                {
                    while (Counter != IntArray.Count() - 1)                    //Counter to prevent out of index
                    {
                        Efficiency++;
                        if (IntArray[Counter] > IntArray[Counter + 1])         //Checks number 1 index in front of index 0 and if larger, shifts positions
                        {
                            Efficiency++;
                            Temporary = IntArray[Counter];
                            IntArray[Counter] = IntArray[Counter + 1];
                            IntArray[Counter + 1] = Temporary;
                            Counter++;                                      //Whenever a shift happens it is registered in this Counter, this advances the operation
                        }
                        if (Counter >= 2 && IntArray[Counter - 1] < IntArray[Counter - 2])  //Second if to check if previous numbers are also higher than new number
                        {
                            Efficiency++;
                            Temporary = IntArray[Counter - 1];
                            IntArray[Counter - 1] = IntArray[Counter - 2];          //same algorithm repeats 
                            IntArray[Counter - 2] = Temporary;
                            Counter -= 2;                                   //resets Counter everytime to retroactively go back to check all previous values
                        }
                        if (IntArray[Counter] <= IntArray[Counter + 1])
                        {
                            Efficiency++;
                            Counter++;                                      //this prevents an infinite loop by advancing Count
                        }           
                    }
                }
                catch
                {
                    Console.WriteLine("Fail");
                    Console.ReadLine();
                }                
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Total amount of steps: "+Efficiency);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Press any key to continue.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadLine();
                return (IntArray, Direction);
            }
            else                                                     //same algorithm as above but for descending sort, small changes made to operators
            {                                                        //to make it work
                Efficiency++;
                try
                {
                    while (Counter != IntArray.Count() - 1)
                    {
                        Efficiency++;
                        if (IntArray[Counter] < IntArray[Counter + 1])
                        {
                            Efficiency++;
                            Temporary = IntArray[Counter];
                            IntArray[Counter] = IntArray[Counter + 1];
                            IntArray[Counter + 1] = Temporary;
                            Counter++;
                        }
                        if (Counter >= 2 && IntArray[Counter - 1] > IntArray[Counter - 2])
                        {
                            Efficiency++;
                            Temporary = IntArray[Counter - 1];
                            IntArray[Counter - 1] = IntArray[Counter - 2];
                            IntArray[Counter - 2] = Temporary;
                            Counter -= 2;
                        }
                        if (IntArray[Counter] >= IntArray[Counter + 1])
                        {
                            Efficiency++;
                            Counter++;
                        }
                    }
                }
                catch
                {
                    Console.WriteLine("Fail");
                    Console.ReadLine();
                }
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Total amount of steps: "+Efficiency);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Press any key to continue.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadLine();          
                return (IntArray, Direction);
            }
        }
        public static (int[], int) PushSorter(int[] IntArray, int Direction)
        {
            Efficiency = 0;
            if (Direction == 1)
            {
                Efficiency++;
                PusherA();
            }
            if (Direction == 2)
            {
                Efficiency++;
                PusherD();  
            }

            void PusherA()
            {
                int Counter = 0;
                int Operations = 0;
                while (Counter < IntArray.Count() - 1)
                {
                    Efficiency++;
                    if (IntArray[Counter] > IntArray[Counter + 1])
                    {
                        Efficiency++;
                        int Temporary = IntArray[Counter];
                        IntArray[Counter] = IntArray[Counter + 1];
                        IntArray[Counter + 1] = Temporary;
                        Operations = 1;
                    }
                    Counter++;
                }                
                if (Operations == 1)
                {
                    Efficiency++;
                    PusherA();
                }                
            }     
        
            void PusherD()
            {
                int Counter = 0;
                int Operations = 0;
                while (Counter != IntArray.Count() - 1)
                {
                    Efficiency++;
                    if (IntArray[Counter] < IntArray[Counter + 1])
                    {
                        Efficiency++;
                        int Temporary = IntArray[Counter];
                        IntArray[Counter] = IntArray[Counter + 1];
                        IntArray[Counter + 1] = Temporary;
                        Operations = 1;
                    }
                    Counter++;
                }               
                if (Operations == 1)
                {
                    Efficiency++;
                    PusherD();
                }               
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Total amount of steps: "+Efficiency);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Press any key to continue.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadLine();  
            return (IntArray, Direction);
        }
        public static void MergeArray(int[] IntArray, int Left, int Middle, int Right)
        {
            var LeftArrayLength = Middle - Left + 1;
            var RightArrayLength = Right - Middle;
            var LeftTemporaryArray = new int[LeftArrayLength];
            var RightTemporaryArray = new int[RightArrayLength];
            int i, j;
            for (i = 0; i < LeftArrayLength; ++i)
                LeftTemporaryArray[i] = IntArray[Left + i];
            for (j = 0; j < RightArrayLength; ++j)
                RightTemporaryArray[j] = IntArray[Middle + 1 + j];
            i = 0;
            j = 0;
            int k = Left;
            while (i < LeftArrayLength && j < RightArrayLength)
            {
                Efficiency++;
                if (LeftTemporaryArray[i] <= RightTemporaryArray[j])
                {
                    Efficiency++;
                    IntArray[k++] = LeftTemporaryArray[i++];
                }
                else
                {
                    Efficiency++;
                    IntArray[k++] = RightTemporaryArray[j++];
                }
            }
            while (i < LeftArrayLength)
            {
                Efficiency++;
                IntArray[k++] = LeftTemporaryArray[i++];
            }
            while (j < RightArrayLength)
            {
                Efficiency++;
                IntArray[k++] = RightTemporaryArray[j++];
            }
        }
        public static void SortArray(int[] IntArray,int Direction)
        {
            if (Direction == 1)
            {
                Efficiency++;
                SortArrayAscending(IntArray, 0, IntArray.Length - 1);
            }
            else
            {
                Efficiency++;
                SortArrayDescending(IntArray, 0, IntArray.Length - 1);
            }
        }
        public static int[] SortArrayAscending(int[] IntArray, int Left, int Right)
        {
            if (Left < Right)
            {
                Efficiency++;
                int Middle = Left + (Right - Left) / 2;
                SortArrayAscending(IntArray, Left, Middle);
                SortArrayAscending(IntArray, Middle + 1, Right);
                MergeArray(IntArray, Left, Middle, Right);
            }
            return IntArray;
        }
        public static int[] SortArrayDescending(int[] IntArray, int Left, int Right)
        {
            if (Left < Right)
            {
                Efficiency++;
                int Middle = Left + (Right - Left) / 2;
                SortArrayDescending(IntArray, Left, Middle);
                SortArrayDescending(IntArray, Middle + 1, Right);
                MergeArrayR(IntArray, Left, Middle, Right);
            }
            return IntArray;
        }
        public static int MergeArrayR(int[] IntArray, int Left, int Middle, int Right)
        {
            var LeftArrayLength = Middle - Left + 1;
            var RightArrayLength = Right - Middle;
            var LeftTemporaryArray = new int[LeftArrayLength];
            var RightTemporaryArray = new int[RightArrayLength];
            int i, j;
            for (i = 0; i < LeftArrayLength; ++i)
                LeftTemporaryArray[i] = IntArray[Left + i];
            for (j = 0; j < RightArrayLength; ++j)
                RightTemporaryArray[j] = IntArray[Middle + 1 + j];
            i = 0;
            j = 0;
            int k = Left;
            while (i < LeftArrayLength && j < RightArrayLength)
            {
                Efficiency++;
                if (LeftTemporaryArray[i] >= RightTemporaryArray[j])
                {
                    Efficiency++;
                    IntArray[k++] = LeftTemporaryArray[i++];
                }
                else
                {
                    Efficiency++;
                    IntArray[k++] = RightTemporaryArray[j++];
                }
            }
            while (i < LeftArrayLength)
            {
                Efficiency++;
                IntArray[k++] = LeftTemporaryArray[i++];
            }
            while (j < RightArrayLength)
            {
                Efficiency++;
                IntArray[k++] = RightTemporaryArray[j++];
            }

            return Efficiency;
        }
        public static int QuickSort(int[] IntArray,int Direction)
        {
            if (Direction == 1)
            {
                Efficiency++;
                QuickSortAscending(IntArray, 0, IntArray.Length - 1);
            }
            else
            {
                Efficiency++;
                QuickSortDescending(IntArray, 0, IntArray.Length - 1);
            }
            
            static int QuickSortAscending(int[] IntArray, int LeftIndex, int RightIndex)
            {
                var i = LeftIndex;
                var j = RightIndex;
                var Pivot = IntArray[LeftIndex];
                while (i <= j)
                {
                    Efficiency++;
                    while (IntArray[i] < Pivot)
                    {
                        Efficiency++;
                        i++;
                    }
                    while (IntArray[j] > Pivot)
                    {
                        Efficiency++;
                        j--;
                    }
                    if (i <= j)
                    {
                        Efficiency++;
                        int Temporary = IntArray[i];
                        IntArray[i] = IntArray[j];
                        IntArray[j] = Temporary;
                        i++;
                        j--;
                    }
                }

                if (LeftIndex < j)
                {
                    Efficiency++;
                    QuickSortAscending(IntArray, LeftIndex, j);
                }

                if (i < RightIndex)
                {
                    Efficiency++;
                    QuickSortAscending(IntArray, i, RightIndex);
                }
                return Efficiency;
            }
            static int QuickSortDescending(int[] IntArray, int LeftIndex, int RightIndex)
            {
                var i = LeftIndex;
                var j = RightIndex;
                var Pivot = IntArray[LeftIndex];
                while (i <= j)
                {
                    Efficiency++;
                    while (IntArray[i] > Pivot)
                    {
                        Efficiency++;
                        i++;
                    }
                    while (IntArray[j] < Pivot)
                    {
                        Efficiency++;
                        j--;
                    }
                    if (i <= j)
                    {
                        Efficiency++;
                        int Temporary = IntArray[i];
                        IntArray[i] = IntArray[j];
                        IntArray[j] = Temporary;
                        i++;
                        j--;
                    }
                }

                if (LeftIndex < j)
                {
                    Efficiency++;
                    QuickSortDescending(IntArray, LeftIndex, j);
                }

                if (i < RightIndex)
                {
                    Efficiency++;
                    QuickSortDescending(IntArray, i, RightIndex);
                }
                return Efficiency;
            }
            return Efficiency;
        }
    }
}


