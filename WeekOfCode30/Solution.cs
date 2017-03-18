using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution
{

    static void Main(String[] args)
    {
        int n = Convert.ToInt32(Console.ReadLine());
        string endPar = "";
        string minint = "";
        for (int i = 1; i < n; i++)
        {
            minint += "min(int, ";
            endPar += ")";
        }
        Console.WriteLine(minint + "int" + endPar);
    }
}
