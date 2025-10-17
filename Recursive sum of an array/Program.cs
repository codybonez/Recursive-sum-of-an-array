using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace Recursive_sum_of_an_array
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();

            int[] Numbers =
            {
                1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20,
               21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38,
               39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50
          };

            int[] ReverseNumbers =
            {
                50, 49, 48, 47, 46, 45, 44, 43, 42, 41, 
                40, 39, 38, 37, 36, 35, 34, 33, 32, 31, 
                30, 29, 28, 27, 26, 25, 24, 23, 22, 21, 
                20, 19, 18, 17, 16, 15, 14, 13, 12, 11, 
                10, 9, 8, 7, 6, 5, 4, 3, 2, 1
            };
            int[] PartialSorted =
            {
                1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,35,34,33, 32, 31,
                30, 29, 28, 27, 26, 25, 24, 23, 22, 21,
                20, 19, 18, 17,  37,41, 36, 39,47,50, 38, 45, 40, 46, 49, 42,48, 44, 43
            };




            int[] largeArr = GenerateRandomArray(100000, 1, 1000);
            Console.WriteLine("Array Randomized");


            TestSort(largeArr);





            // usage 100 thousand values












            // Write your function to test each algorithm here
            // algo for function


            // Menu to chose what sort method you want to use.
            void TestSort(int[] arr)
            {

                string menu = " ";

                while (menu != "Exit")
                {
                    Console.WriteLine("\nSelect what type of sorting algorithm to sort data with.\nType /Help to get a list of commands.\n");
                    menu = Console.ReadLine();
                    switch (menu)
                    {

                        case "/Help":

                            Console.WriteLine("BubbleSort, MergeSort, QuickSort, InsertionSort, Exit");
                            break;

                        case "BubbleSort":
                            stopwatch.Start();
                            bubbleSort(largeArr, largeArr.Length);
                            stopwatch.Stop();
                            Console.WriteLine("Algorithm: BubbleSort");
                            DisplayRuntime(stopwatch);
                            stopwatch.Reset();
                            largeArr = GenerateRandomArray(100000, 1, 1000);

                            break;

                        case "MergeSort":
                            stopwatch.Start();
                            // Merge Sort Algorithm
                            mergeSort(largeArr, 1, largeArr.Length - 1);
                            stopwatch.Stop();
                            Console.WriteLine("Algorithm: MergeSort");
                            DisplayRuntime(stopwatch);
                            stopwatch.Reset();
                            largeArr = GenerateRandomArray(100000, 1, 1000);
                            break;

                        case "QuickSort":
                            // fastest Sorting method uses partition. Both merge and quick sort use Divide and Conquer method.
                            stopwatch.Start();
                            // Quick Sort Algorithm
                            quickSort(largeArr, 1, largeArr.Length - 1);
                        
                            stopwatch.Stop();
                            DisplayRuntime(stopwatch);
                            Console.WriteLine("Algorithm: QuickSort");
                            
                            stopwatch.Reset();
                            largeArr = GenerateRandomArray(100000, 1, 1000);
                            break;

                        case "InsertionSort":
                            stopwatch.Start();
                            // Insertion Sort Algorithm
                            insertionSort(largeArr);
                            stopwatch.Stop();
                            Console.WriteLine("Algorithm: InsertionSort");
                            DisplayRuntime(stopwatch);
                            stopwatch.Reset();
                            largeArr = GenerateRandomArray(100000, 1, 1000);
                            break;
                        case "Exit":
                            Console.WriteLine("Exiting Program.");
                            break;

                        default:
                            Console.WriteLine("Not an option, try again");
                            break;
                    }







                }





            }


            // Write individual functions for each algorithm here (Bubble, Insertion, Merge, and Quick sort)

         


            static void bubbleSort(int[] arr, int n)
            {
                int i, j, temp;
                bool swapped;
                // outer loop
                for (i = 0; i < n - 1; i++)
                {
                    swapped = false;
                    // inner loop
                    for (j = 0; j < n - i - 1; j++)
                    {
                        // compare if the biggest is bigger than the next number in the array
                        if (arr[j] > arr[j + 1])
                        {

                            // Swap arr[j] and arr[j+1]

                            temp = arr[j];
                            arr[j] = arr[j + 1];
                            arr[j + 1] = temp;
                            swapped = true;
                        }
                    }

                    // If no two elements were
                    // swapped by inner loop, then break
                    if (swapped == false)
                        break;
                }
            }
        }

            // Insertion Sort

            public static void insertionSort(int[] arr)
        {

            int n = arr.Length;


            for (int i = 1; i < n; i++)
            {
                int key = arr[i];
                int j = i - 1;

            
                while (j >= 0 && arr[j] > key)
                {
                    arr[j + 1] = arr[j];
                    j = j - 1;
                }
                arr[j + 1] = key;
            }

        }

        // Merge Sort

        static void merge(int[] arr, int l, int m, int r)
        {

            // Find sizes of two
            // subarrays to be merged
            int n1 = m - l + 1;
            int n2 = r - m;

            // Create temp arrays
            int[] L = new int[n1];
            int[] R = new int[n2];
            int i, j;

            // Copy data to temp arrays
            for (i = 0; i < n1; ++i)
                L[i] = arr[l + i];
            for (j = 0; j < n2; ++j)
                R[j] = arr[m + 1 + j];

            // Merge the temp arrays

            // Initial indexes of first
            // and second subarrays
            i = 0;
            j = 0;

            // Initial index of merged
            // subarray array
            int k = l;
            while (i < n1 && j < n2)
            {
                if (L[i] <= R[j])
                {
                    arr[k] = L[i];
                    i++;
                }
                else
                {
                    arr[k] = R[j];
                    j++;
                }
                k++;
            }

            // Copy remaining elements
            // of L[] if any
            while (i < n1)
            {
                arr[k] = L[i];
                i++;
                k++;
            }

            // Copy remaining elements
            // of R[] if any
            while (j < n2)
            {
                arr[k] = R[j];
                j++;
                k++;
            }
        }

        // Main function that sorts arr[l..r] using merge()
        static void mergeSort(int[] arr, int l, int r)
        {

            if (l < r)
            {

                // Find the middle point
                int m = l + (r - l) / 2;

                // Sort first and second halves
                mergeSort(arr, l, m);
                mergeSort(arr, m + 1, r);

                // Merge the sorted halves
                merge(arr, l, m, r);
            }
        }



        //Quick Sort

        static int partition(int[] arr, int low, int high)
        {

            // choose the pivot
            int pivot = arr[high];

            // index of smaller element and indicates 
            // the right position of pivot found so far
            int i = low - 1;

            // traverse arr[low..high] and move all smaller
            // elements to the left side. Elements from low to 
            // i are smaller after every iteration
            for (int j = low; j <= high - 1; j++)
            {
                if (arr[j] < pivot)
                {
                    i++;
                    swap(arr, i, j);
                }
            }

            // move pivot after smaller elements and
            // return its position
            swap(arr, i + 1, high);
            return i + 1;
        }

        // swap function
        static void swap(int[] arr, int i, int j)
        {
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
            
        }

        // The QuickSort function implementation
        static void quickSort(int[] arr, int low, int high)
        {
            if (low < high)
            {

                // pi is the partition return index of pivot
                int pi = partition(arr, low, high);

                // recursion calls for smaller elements
                // and greater or equals elements
                quickSort(arr, low, pi - 1);
                quickSort(arr, pi + 1, high);
            }
        }



        // function
        static int[] GenerateRandomArray(int length, int minValue, int maxValue)
            {
                Random rand = new Random();
                int[] array = new int[length];

                for (int i = 0; i < length; i++)
                {
                    array[i] = rand.Next(minValue, maxValue); // Generates a random integer within the specified range
                }
                
                return array;
            }

            static void DisplayRuntime(Stopwatch stopwatch)
            {
                TimeSpan ts = stopwatch.Elapsed;

                // Format and display the TimeSpan value.
                string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                    ts.Hours, ts.Minutes, ts.Seconds,
                    ts.Milliseconds / 10);
                Console.WriteLine("Time Taken: " + elapsedTime);
            }



          
        
            int linearAdding(int total)
            {
                total = 0;
                for (int i = 0; i < Numbers.Length; i++)
                {
                   total += Numbers[i];

                    Console.WriteLine($"Counter at {i}");

                }

                return total;

            }


             int RecursiveADDING(int t )
             {
                // Issue: Indecies of the array do not go down so the base case does not catch it 
                // fixed the array going up

              
                if (t < 0)
                {
                    return 0;
                }
                Console.WriteLine($"Counter at {t}");
                return Numbers[t] + RecursiveADDING(t-1);
             }


            // Sorting Algorithms




         









        //    static void DisplayRuntime(Stopwatch stopwatch)
        //    {
        //        TimeSpan ts = stopwatch.Elapsed;

        //        // Format and display the TimeSpan value.
        //        string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
        //            ts.Hours, ts.Minutes, ts.Seconds,
        //            ts.Milliseconds / 10);
        //        Console.WriteLine("Time Taken: " + elapsedTime);
        //        stopwatch.Reset();
        //    }

        //    stopwatch.Start();
           
        //    Console.WriteLine(RecursiveADDING(Numbers.Length -1 ));
        //    stopwatch.Stop();
        //    Console.WriteLine("Recursive");
        //    DisplayRuntime(stopwatch);
        //    stopwatch.Start();
           
        //Console.WriteLine(linearAdding(Numbers.Length-1));
        //    stopwatch.Stop();
        //    Console.WriteLine("Linear");
        //    DisplayRuntime(stopwatch);


        }
    }

