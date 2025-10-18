using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace Recursive_sum_of_an_array
{
    public class Program
    {
        static void Main(string[] args)
        {

            // Smaller data;

            int[] StandardNumbers =
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
            int[] PartialNumbers =
            {
                1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,35,34,33, 32, 31,
                30, 29, 28, 27, 26, 25, 24, 23, 22, 21,
                20, 19, 18, 17,  37,41, 36, 39,47,50, 38, 45, 40, 46, 49, 42,48, 44, 43
            };




            Menu();

            // TODO: Select which array do you want to use for testing

        


            // Menu to chose what sort method you want to use.
            void Menu()
            {

                Stopwatch stopwatch = Stopwatch.StartNew();
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
                            stopwatch.Restart();
                            stopwatch.Start();  
                            bubbleSort(GenerateRandomArray(100000, 1, 100000));
                            // ALL DATA IS 100 THOUSAND INTEGERS AND IS DISPLAYING
                            // results vary depending on usage of console write line
                            // Fully Random Array Time: 34.66 
                            // Partial Array Time: 12.74
                            // Reverse Array Time: 4.81
                            // Standard Array Time: 4.78

                            Console.WriteLine("Algorithm: BubbleSort");
                            stopwatch.Stop();
                            DisplayRuntime(stopwatch);
                            stopwatch.Reset();


                            break;

                        case "MergeSort":
                            stopwatch.Restart();
                            stopwatch.Start();
                            // Merge Sort Algorithm

                            mergeSort(StandardArray(), 1, 99999);
                            // ALL DATA IS 100 THOUSAND INTEGERS AND IS DISPLAYING
                            // results vary depending on usage of console write line
                            // Fully Random Array Time: 04.90
                            // Partial Array Time: 04.73
                            // Reverse Array Time: 04.62
                            // Standard Array Time: 04.67
                            stopwatch.Stop();
                            Console.WriteLine("Algorithm: MergeSort");
                            DisplayRuntime(stopwatch);
                            stopwatch.Reset();

                            break;

                        case "QuickSort":
                            stopwatch.Restart();
                            // fastest Sorting method uses partition. Both merge and quick sort use Divide and Conquer method.
                            stopwatch.Start();
                            // Quick Sort Algorithm
                            QuickSort(ReverseArray(), 1, 5000);
                            // DOES NOT WORK WITH BIGGER THAN 20 THOUNSAND INTEGERS
                           
                            // ALL DATA IS 100 THOUSAND INTEGERS AND IS DISPLAYING
                            // results vary depending on usage of console write line
                            // Fully Random Array Time: 
                            // Partial Array Time: 
                            // Reverse Array Time: 
                            // Standard Array Time: 
                            stopwatch.Stop();
                            DisplayRuntime(stopwatch);
                            Console.WriteLine("Algorithm: QuickSort");

                            stopwatch.Reset();

                            break;

                        case "InsertionSort":
                            stopwatch.Restart();
                            stopwatch.Start();
                            // Insertion Sort Algorithm
                            insertionSort(GenerateRandomArray(100000, 1, 100000));
                            // ALL DATA IS 100 THOUSAND INTEGERS AND IS DISPLAYING
                            // results vary depending on usage of console write line
                            // Fully Random Array Time: 11.35
                            // Partial Array Time: 05.58
                            // Reverse Array Time: 04.69
                            // Standard Array Time: 04.83
                            stopwatch.Stop();
                            Console.WriteLine("Algorithm: InsertionSort");
                            DisplayRuntime(stopwatch);
                            stopwatch.Reset();
                            //  largeArr = GenerateRandomArray(100000, 1, 1000);
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


            #region functions  
            int linearAdding(int total)
            {
                total = 0;
                for (int i = 0; i < StandardNumbers.Length; i++)
                {
                    total += StandardNumbers[i];

                    Console.WriteLine($"Counter at {i}");

                }

                return total;

            }


            int RecursiveADDING(int t)
            {
                // Issue: Indecies of the array do not go down so the base case does not catch it 
                // fixed the array going up


                if (t < 0)
                {
                    return 0;
                }
                Console.WriteLine($"Counter at {t}");
                return StandardNumbers[t] + RecursiveADDING(t - 1);
            }





            // Write individual functions for each algorithm here (Bubble, Insertion, Merge, and Quick sort)




            static void bubbleSort(int[] arr)
            {
                Console.WriteLine("Sorting starts now");
                int i, j, temp;
                int n = arr.Length;
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
            Console.WriteLine("Sorting starts now");
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



        private static void QuickSort(int[] arr, int left, int right)
        {
            // Check if there are elements to sort
            if (left < right)
            {
                // Find the pivot index
                int pivot = Partition(arr, left, right);

                // Recursively sort elements on the left and right of the pivot
                if (pivot > 1)
                {
                    QuickSort(arr, left, pivot - 1);
                }
                if (pivot + 1 < right)
                {
                    QuickSort(arr, pivot + 1, right);
                }
            }
        }

        // Method to partition the array
        public static int Partition(int[] arr, int left, int right)
        {
            // Select the pivot element
            int pivot = arr[left];

            // Continue until left and right pointers meet
            while (true)
            {
                // Move left pointer until a value greater than or equal to pivot is found
                while (arr[left] < pivot)
                {
                    left++;
                }

                // Move right pointer until a value less than or equal to pivot is found
                while (arr[right-1] > pivot)
                {
                    right--;
                }

                // If left pointer is still smaller than right pointer, swap elements
                if (left < right)
                {
                    if (arr[left] == arr[right-1]) return right;

                    int temp = arr[left];
                    arr[left] = arr[right];
                    arr[right] = temp;
                }
                else
                {
                    // Return the right pointer indicating the partitioning position
                    return right;
                }
            }
        }









        // function
        static public int[] GenerateRandomArray(int length, int minValue, int maxValue)
        {
            Random rand = new Random();
            int[] array = new int[length];

            for (int i = 0; i < length; i++)
            {
                array[i] = rand.Next(minValue, maxValue); // Generates a random integer within the specified range
                Console.WriteLine(array[i]);
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







        // Sorting Algorithms



        public static int[] PartialArray()
        {

            int[] arrPartial = new int[100000];
            for (int i = 0; i <= 33333; i++)
            {
                Console.WriteLine(i);
            }
            for (int j = 66666; j >= 33334; j--)
            {
                Console.WriteLine(j);

            }
            Random rand = new Random();
            for (int k = 66667; k < 100000; k++)
            {

                arrPartial[k] = rand.Next(66667, 100000);
                Console.WriteLine(arrPartial[k]);

            }

            return arrPartial;
        }




        public static int[] ReverseArray()
        {
            int[] arrReverse = new int[100000];
            for (int j = 100000; j >= 0; j--)
            {
                Console.WriteLine(j);

            }
            return arrReverse;
        }
        public static int[] StandardArray()
        {
            int[] arrNormal = new int[100000];
            for (int i = 0; i <= 100000; i++)
            {
                Console.WriteLine(i);
            }
            return arrNormal;
        }




        #endregion




    
    }
}
    

