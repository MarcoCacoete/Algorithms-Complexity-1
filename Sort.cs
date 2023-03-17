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
        public static (int[], int) BackSorter(int[] IntArray, int Direction)
        {
            int Count = IntArray.Count();
            int Counter = 0;
            int Temporary;
            if (Direction == 1)                                            //Direction 1 sorts in ascending mode
            {
                try
                {
                    while (Counter != IntArray.Count() - 1)                    //Counter to prevent out of index
                    {
                        if (IntArray[Counter] > IntArray[Counter + 1])         //Checks number 1 index in front of index 0 and if larger, shifts positions
                        {
                            Temporary = IntArray[Counter];
                            IntArray[Counter] = IntArray[Counter + 1];
                            IntArray[Counter + 1] = Temporary;
                            Counter++;                                      //Whenever a shift happens it is registered in this Counter, this advances the operation
                            Count--;
                        }
                        if (Counter >= 2 && IntArray[Counter - 1] < IntArray[Counter - 2])  //Second if to check if previous numbers are also higher than new number
                        {
                            Temporary = IntArray[Counter - 1];
                            IntArray[Counter - 1] = IntArray[Counter - 2];          //same algorithm repeats 
                            IntArray[Counter - 2] = Temporary;
                            Counter -= 2;                                   //resets Counter everytime to retroactively go back to check all previous values
                            Count--;
                        }
                        if (IntArray[Counter] <= IntArray[Counter + 1])             //this prevents an infinite loop by advancing Count
                            Counter++;
                    }
                }
                catch
                {
                    Console.WriteLine("Fail");
                    Console.ReadLine();
                }                
                Console.WriteLine("Successfully completed.");
                return (IntArray, Direction);
            }
            else                                                                    //same algorithm as above but for descending sort, small changs made to operators
            {                                                                       //to make it work
            try
            {
                while (Counter != IntArray.Count() - 1)
                {
                    if (IntArray[Counter] < IntArray[Counter + 1])
                    {
                        Temporary = IntArray[Counter];
                        IntArray[Counter] = IntArray[Counter + 1];
                        IntArray[Counter + 1] = Temporary;
                        Counter++;
                        Count--;
                    }
                    if (Counter >= 2 && IntArray[Counter - 1] > IntArray[Counter - 2])
                    {
                        Temporary = IntArray[Counter - 1];
                        IntArray[Counter - 1] = IntArray[Counter - 2];
                        IntArray[Counter - 2] = Temporary;
                        Counter -= 2;
                        Count--;
                    }
                    if (IntArray[Counter] >= IntArray[Counter + 1])
                        Counter++;
                }
            }
            catch
            {
                Console.WriteLine("Fail");
                Console.ReadLine();
            }
            Console.WriteLine("Successfully completed.");
            return (IntArray, Direction);
            }
        }
        public static (int[], int) PushSorter(int[] IntArray, int Direction)
        {
            if (Direction == 1)
            {
                PusherA(IntArray);
            }
            if (Direction == 2)
            {
                PusherD(IntArray);  
            }

            (int[], int) PusherA(int[] IntArray)
            {
                int Count = IntArray.Count();
                int Counter = 0;
                int Operations = 0;
                while (Counter < IntArray.Count() - 1)
                {
                    if (IntArray[Counter] > IntArray[Counter + 1])
                    {
                        int Temporary = IntArray[Counter];
                        IntArray[Counter] = IntArray[Counter + 1];
                        IntArray[Counter + 1] = Temporary;
                        Operations = 1;
                    }
                    Counter++;
                }                
                if (Operations == 1)
                {
                    PusherA(IntArray);
                }                
                return (IntArray, Direction);
            }     
        
            (int[], int) PusherD(int[] IntArray)
            {
                int Count = IntArray.Count();
                int Counter = 0;
                int Operations = 0;
                while (Counter != IntArray.Count() - 1)
                {
                    if (IntArray[Counter] < IntArray[Counter + 1])
                    {
                        int Temporary = IntArray[Counter];
                        IntArray[Counter] = IntArray[Counter + 1];
                        IntArray[Counter + 1] = Temporary;
                        Operations = 1;
                    }
                    Counter++;
                }               
                if (Operations == 1)
                {
                    PusherD(IntArray);
                }               
                return (IntArray, Direction);
            }
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
                if (LeftTemporaryArray[i] <= RightTemporaryArray[j])
                {
                    IntArray[k++] = LeftTemporaryArray[i++];
                }
                else
                {
                    IntArray[k++] = RightTemporaryArray[j++];
                }
            }
            while (i < LeftArrayLength)
            {
                IntArray[k++] = LeftTemporaryArray[i++];
            }
            while (j < RightArrayLength)
            {
                IntArray[k++] = RightTemporaryArray[j++];
            }
        }
        public static void SortArray(int[] IntArray,int Direction)
        {
            if (Direction == 1)
                SortArrayAscending(IntArray, 0, IntArray.Length - 1);
            else
                SortArrayDescending(IntArray, 0, IntArray.Length - 1);
        }
        public static int[] SortArrayAscending(int[] IntArray, int Left, int Right)
        {
            if (Left < Right)
            {
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
                int Middle = Left + (Right - Left) / 2;
                SortArrayDescending(IntArray, Left, Middle);
                SortArrayDescending(IntArray, Middle + 1, Right);
                MergeArrayR(IntArray, Left, Middle, Right);
            }
            return IntArray;
        }
        public static void MergeArrayR(int[] IntArray, int Left, int Middle, int Right)
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
                if (LeftTemporaryArray[i] >= RightTemporaryArray[j])
                {
                    IntArray[k++] = LeftTemporaryArray[i++];
                }
                else
                {
                    IntArray[k++] = RightTemporaryArray[j++];
                }
            }
            while (i < LeftArrayLength)
            {
                IntArray[k++] = LeftTemporaryArray[i++];
            }
            while (j < RightArrayLength)
            {
                IntArray[k++] = RightTemporaryArray[j++];
            }
        }
        public static void QuickSort(int[] IntArray,int Direction)
        {
            if (Direction == 1)
                QuickSortAscending(IntArray, 0, IntArray.Length - 1);
            else
                QuickSortDescending(IntArray, 0, IntArray.Length - 1);

            static int[] QuickSortAscending(int[] IntArray, int LeftIndex, int RightIndex)
            {
                var i = LeftIndex;
                var j = RightIndex;
                var Pivot = IntArray[LeftIndex];
                while (i <= j)
                {
                    while (IntArray[i] < Pivot)
                    {
                        i++;
                    }
                    while (IntArray[j] > Pivot)
                    {
                        j--;
                    }
                    if (i <= j)
                    {
                        int Temporary = IntArray[i];
                        IntArray[i] = IntArray[j];
                        IntArray[j] = Temporary;
                        i++;
                        j--;
                    }
                }
                if (LeftIndex < j)
                    QuickSortAscending(IntArray, LeftIndex, j);
                if (i < RightIndex)
                    QuickSortAscending(IntArray, i, RightIndex);
                return IntArray;
            }
            static int[] QuickSortDescending(int[] IntArray, int LeftIndex, int RightIndex)
            {
                var i = LeftIndex;
                var j = RightIndex;
                var Pivot = IntArray[LeftIndex];
                while (i <= j)
                {
                    while (IntArray[i] > Pivot)
                    {
                        i++;
                    }
                    while (IntArray[j] < Pivot)
                    {
                        j--;
                    }
                    if (i <= j)
                    {
                        int Temporary = IntArray[i];
                        IntArray[i] = IntArray[j];
                        IntArray[j] = Temporary;
                        i++;
                        j--;
                    }
                }
                if (LeftIndex < j)
                    QuickSortDescending(IntArray, LeftIndex, j);
                if (i < RightIndex)
                    QuickSortDescending(IntArray, i, RightIndex);
                return IntArray;
            }
        }
    }
}


