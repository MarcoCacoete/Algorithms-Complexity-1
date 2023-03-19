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
    {                   // First algorithm I created for sorting. I thought I was being original but it seems it's just an insertion sorter.

        public static int Efficiency = 0;   // Class variable used as a counter for amount of steps taken by methods to resolve.
        public static (int[], int) BackSorter(int[] IntArray, int Direction)
        {
            int Counter = 0;
            Efficiency = 0;
            int Temporary;
            if (Direction == 1)                                            // Direction 1 sorts in ascending mode
            {
                Efficiency++;               // Increments when a step happens.
                try
                {
                    while (Counter != IntArray.Count() - 1)                    // Counter to prevent out of index
                    {
                        Efficiency++;
                        if (IntArray[Counter] > IntArray[Counter + 1])         // Checks number 1 index in front of index 0 and if larger, shifts positions
                        {
                            Efficiency++;
                            Temporary = IntArray[Counter];
                            IntArray[Counter] = IntArray[Counter + 1];
                            IntArray[Counter + 1] = Temporary;
                            Counter++;                                          // Whenever a shift happens it is registered in this Counter, this advances the operation
                        }
                        if (Counter >= 2 && IntArray[Counter - 1] < IntArray[Counter - 2])  // Second if to check if previous numbers are also higher than new number
                        {
                            Efficiency++;
                            Temporary = IntArray[Counter - 1];
                            IntArray[Counter - 1] = IntArray[Counter - 2];          // Same algorithm repeats 
                            IntArray[Counter - 2] = Temporary;
                            Counter -= 2;                                   // Resets Counter everytime to retroactively go back to check all previous values
                        }
                        if (IntArray[Counter] <= IntArray[Counter + 1])
                        {
                            Efficiency++;
                            Counter++;                                      // This prevents an infinite loop by advancing Count
                        }           
                    }
                }
                catch
                {
                    Console.WriteLine("Fail");
                    Console.ReadLine();
                }                
                
                return (IntArray, Direction);
            }
            else                                                     // Same algorithm as above but for descending sort, small changes made to operators
            {                                                        // to make it work
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
                return (IntArray, Direction);
            }
        }
        
                    // Method for sorting I created, turned out to be like a bubble sort.
        public static (int[], int) PushSorter(int[] IntArray, int Direction)
        {
            Efficiency = 0;
            if (Direction == 1)
            {
                Efficiency++;
                PusherA();
            }
            if (Direction == 2)     // Push sorter method picks algorithm depending on sort order.
            {
                Efficiency++;
                PusherD();  
            }

            void PusherA()          // Ascending order algorithm.
            {
                int Counter = 0;        // Counter using to determine index.
                int Operations = 0;
                while (Counter < IntArray.Count() - 1)      // While loop iterates without going out of index.
                {
                    Efficiency++;
                    if (IntArray[Counter] > IntArray[Counter + 1])      // Conditional to check if next index value is higher than current index.
                    {
                        Efficiency++;
                        int Temporary = IntArray[Counter];
                        IntArray[Counter] = IntArray[Counter + 1];      // Code block stores current index in temporary variable then
                        IntArray[Counter + 1] = Temporary;              // replaces first index with next index value, finally replaces second index value with original index value.
                        Operations = 1;     // Switches on if an operation has occured.
                    }
                    Counter++;      // Steps to next index for analysis.
                }                
                if (Operations == 1)    // If operations occured above the method recursively calls itself, if not it returns sorted array and direction..
                {
                    Efficiency++;
                    PusherA();
                }                
            }     
                        // Same method as above with logic values swapped around to work in reverse sort order.
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
            return (IntArray, Direction);
        }
        
        // Array merging method, used for both Sort merge algorithm and quick sort.
        public static void MergeArray(int[] IntArray, int Left, int Middle, int Right)
        {
            var LeftArrayLength = Middle - Left + 1;            // Defines size of left array and right array,
            var RightArrayLength = Right - Middle;
            var LeftTemporaryArray = new int[LeftArrayLength];      // Creates respective temporary arrays using size defined above.
            var RightTemporaryArray = new int[RightArrayLength];
            int i, j;                                               // Declares 2 variables.
            for (i = 0; i < LeftArrayLength; ++i)                   
                LeftTemporaryArray[i] = IntArray[Left + i];         // We copy data into those temporary arrays using two loops.

            for (j = 0; j < RightArrayLength; ++j)                  
                RightTemporaryArray[j] = IntArray[Middle + 1 + j];
            i = 0;
            j = 0;
            int k = Left;
            while (i < LeftArrayLength && j < RightArrayLength)  // We then proceed to compare the elements in the temporary array 
            {                                                    // objects and swap their positions if the element in the left array index  is less than or equal
                Efficiency++;                                    // to the element in the right array index object while storing them in the in the array k index in the merged array:
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
                Efficiency++;                                   // The process completes by copying remaining elements from the left temporary array index  and the right temporary index objects into the merged array:
                IntArray[k++] = LeftTemporaryArray[i++];
            }
            while (j < RightArrayLength)
            {
                Efficiency++;
                IntArray[k++] = RightTemporaryArray[j++];
            }
        }
        
                    // Method starts sort array methods with sort order ascending or descending.
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
        
                    // Entry point for sorting method. First, the method uses the left and right integer values to define the index of the element in the middle of the array.
                    // The method recursively calls itself to subdivide the right and left sub arrays. The merging process commences after each array has one element.
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
        
                    // Same as above for descending order.
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
        
                     // Same logic as above Merge array method but for Descending sorting order.
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
        
                    // Helper method for to call quicksort in ascending and descending sorting order.
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
                    // Quick sort method takes three arguments for array, left and right index.
            static int QuickSortAscending(int[] IntArray, int LeftIndex, int RightIndex)
            {           
                var i = LeftIndex;                  // starts by assigning the values of the leftIndex and rightIndex to new variables i and j, which are going to be used when iterating.
                var j = RightIndex;
                var Pivot = IntArray[LeftIndex];    // Next, we set the pivot as the leftmost element in the array:

                while (i <= j)                         // The algorithm starts placing the pivot element at its correct position in the sorted array
                {                                      // by dividing the array into two lists in the outermost while loop. Our goal is to place all
                    Efficiency++;                      // smaller elements (smaller than the pivot) to the left of the pivot and all greater elements to the right of the pivot. 
                    while (IntArray[i] < Pivot)        // If the elements to the left of the pivot are less than the pivot element, we skip their positions.
                    {
                        Efficiency++;
                        i++;
                    }
                    while (IntArray[j] > Pivot)
                    {
                        Efficiency++;                   // If the elements to the right of the pivot are greater than the pivot element, we skip their positions as we loop through the right subarray:
                        j--;
                    }
                    if (i <= j)
                    {
                        Efficiency++;
                        int Temporary = IntArray[i];    // If we find an element in the left subarray that is greater than the pivot and
                        IntArray[i] = IntArray[j];      // an element in the right subarray which is less than the pivot, we swap their positions.  
                        IntArray[j] = Temporary;
                        i++;                            // We then update the index counters accordingly.
                        j--;
                    }
                }
                        
                if (LeftIndex < j)
                {
                    Efficiency++;
                    QuickSortAscending(IntArray, LeftIndex, j);
                }
                                                        // The method calls itself recursively to sort the left and right sub arrays and returns a sorted array when the process is complete.
                if (i < RightIndex)
                {
                    Efficiency++;
                    QuickSortAscending(IntArray, i, RightIndex);
                }
                return Efficiency;
            }       
                        
                            // Same as above but in descending order.
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


