using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution
{

    public static char[] alpha = "ABCDEFGHIJKLMNOPQRSTUVWXZ".ToLower().ToCharArray();
    public static int[] ind = new int[] { 0, 4, 8, 14, 20 };
    public static string[] indstr = new string[] { "a", "e", "i", "o", "u" };

    static void Main(String[] args)
    {
        int n = Convert.ToInt32(Console.ReadLine());


        List<string> list = new List<string>();

        for (int i = 0; i < alpha.Length; i++)
        {
            list.Add(alpha[i].ToString());
        }
        for (int i = 0; i < n - 1; i++)
            addHarf(ref list);

        for (int i = 0; i < list.Count; i++)
        {
            Console.WriteLine(list[i]);
        }
    }

    public static void addHarf(ref List<string> sList)
    {
        Console.WriteLine("co : " + sList.Count);
        List<string> temp = new List<string>();
        for (int i = 0; i < sList.Count; i++)
        {
            int a = sList[i].Length;
            if (indstr.Contains(sList[i].Substring(a - 1, 1)))
                addsesli(sList[i], ref temp);
            else
            {
                addsessiz(sList[i], ref temp);

            }
        }
        sList = temp;
    }

    public static void addsesli(string old, ref List<string> sList)
    {
        for (int i = 0; i < alpha.Length; i++)
        {
            if (!ind.Contains(i))
                sList.Add(old + alpha[i].ToString());
        }
    }

    public static void addsessiz(string old, ref List<string> sList)
    {
        for (int i = 0; i < alpha.Length; i++)
        {
            if (ind.Contains(i))
                sList.Add(old + alpha[i].ToString());
        }
    }
}
