using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution
{

    static void Main(String[] args)
    {
        string[] tokens_n = Console.ReadLine().Split(' ');
        int n = Convert.ToInt32(tokens_n[0]);
        int q = Convert.ToInt32(tokens_n[1]);
        string[] a_temp = Console.ReadLine().Split(' ');
        int[] a = Array.ConvertAll(a_temp, Int32.Parse);
        for (int a0 = 0; a0 < q; a0++)
        {
            string[] tokens_left = Console.ReadLine().Split(' ');
            int left = Convert.ToInt32(tokens_left[0]);
            int right = Convert.ToInt32(tokens_left[1]);
            int x = Convert.ToInt32(tokens_left[2]);
            int y = Convert.ToInt32(tokens_left[3]);

            int result = calculationFunction(left, right, x, y, a);
            Console.WriteLine(result + "");
            
        }
    }
    public static int calculationFunction(int left, int right, int x, int y, int[] mArray)
    {
        int result = 0;
        int i = 0;
        foreach (int val in mArray)
        {
            if (isBetween(left, right, i))
            {
                if (isModEquals(x, y, val))
                {
                    result++;
                }
            }
            i++;
        }
        return result;
    }

    public static bool isBetween(int left, int right, int index)
    {
        if (left <= index && index <= right)
            return true;
        else
            return false;
    }

    public static bool isModEquals(int x, int y, int val)
    {
        if (val % x == y)
            return true;
        else
            return false;
    }
}
