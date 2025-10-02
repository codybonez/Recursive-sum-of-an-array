using System.Runtime.CompilerServices;
using System.Diagnostics;
namespace Recursive_sum_of_an_array
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();


            // usage 100 thousand values
          



      

          
            
            int[] Numbers =
            {
                1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20,
               21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38,
               39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50
          };
          
        
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

            static void DisplayRuntime(Stopwatch stopwatch)
            {
                TimeSpan ts = stopwatch.Elapsed;

                // Format and display the TimeSpan value.
                string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                    ts.Hours, ts.Minutes, ts.Seconds,
                    ts.Milliseconds / 10);
                Console.WriteLine("Time Taken: " + elapsedTime);
                stopwatch.Reset();
            }

            stopwatch.Start();
           
            Console.WriteLine(RecursiveADDING(Numbers.Length -1 ));
            stopwatch.Stop();
            Console.WriteLine("Recursive");
            DisplayRuntime(stopwatch);
            stopwatch.Start();
           
        Console.WriteLine(linearAdding(Numbers.Length-1));
            stopwatch.Stop();
            Console.WriteLine("Linear");
            DisplayRuntime(stopwatch);


        }
    }
}
