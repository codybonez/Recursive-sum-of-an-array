using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Recursive_sum_of_an_array
{
    public class arrayBuilder
    {
        public static int[] noDuplicates()
        {
            int[] array  = new int[500000];
            
            return array;
        }
        public static int[] halfDuplicates()
        {
            int j = 0; 
            int[] array1 = new int[250000];
            int[] array2 = new int[250000];
            int[] combine = new int[array1.Length + array2.Length];
            for (int i = 0; i < combine.Length-1; i++)
            {

           


                if (combine[i] == combine[j])
                    {
                     
                    j++;

                }
                   
               

            }
          
            return combine;
        }

        public static int[] oneThroughTenDuplicate()
        {
            int[] array3 = new int[500000];
       
            for(int i = 0; i < array3.Length;i++)
            {
                array3[i] = (i % 10) + 1;
              
            }
            return array3;
        }
}


}
