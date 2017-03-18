using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace WeekOfCode30
{
    class Solution
    {

        static void Main(String[] args)
        {
            string[] tokens_n = Console.ReadLine().Split(' ');
            int n = Convert.ToInt32(tokens_n[0]);
            int t = Convert.ToInt32(tokens_n[1]);
            string[] c_temp = Console.ReadLine().Split(' ');
            int[] c = Array.ConvertAll(c_temp, Int32.Parse);
            // your code goes here
            int k = n;
            int retval = 0;
            for (int i = 0; i < t; i++)
            {
                if ((k - c[i] < 5) && i != (t - 1))
                {
                    retval = retval + n - k + c[i];
                    k = n;
                }
                else
                {
                    k = k - c[i];
                }
            }
            Console.WriteLine(retval);
        }
    }

}
