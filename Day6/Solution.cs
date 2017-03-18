using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
public static class Solution
{
    public static int[] resultArray;//stores index of selected nodes
    public static int[][] g;
    public static int n;

    static void Main(String[] args)
    {
        n = Convert.ToInt32(Console.ReadLine());
        g = new int[n][];
        for (int g_i = 0; g_i < n; g_i++)
        {
            string[] g_temp = Console.ReadLine().Split(' ');
            g[g_i] = Array.ConvertAll(g_temp, Int32.Parse);
        }

        List<int> indexList = new List<int>();
        for(int b = 0; b < n; b++)
            indexList.Add(b);

        var asd = GetAllCombosREC(indexList);
        double RETVAL = 0.0;
        resultArray = new int[0];
        for (int i = 0; i < asd.Count; i++)
        {
            if (asd[i].Count >= 3)
            {
                double not = (double)numberOfTriangles(asd[i]);
                double cou = (double)asd[i].Count;
                double tempRETVAL = not / cou;
                if (tempRETVAL > RETVAL)
                {
                    RETVAL = tempRETVAL;
                    resultArray = asd[i].ToArray();
                }
            }
        }
        resultTostring();
        //int xasdaf = numberOfTriangles(indexList);

        // your code goes here
    }

    //seçili indexler
    public static int numberOfTriangles(List<int> indexList)
    {
        int count = 0;
        var triplets = Combinations(indexList, 3);
        foreach (IEnumerable<int> temptriplet in triplets)
        {
            List<int> triplet = temptriplet.ToList();
            if (isTriangle(triplet[0], triplet[1], triplet[2]))
                count++;
        }
        triplets = null;
        return count;
    }

    //returns true, if given three indexes represent a triangle.
    public static bool isTriangle(int index1, int index2, int index3)
    {
        if (g[index1][index2] == 1 && g[index1][index3] == 1 && g[index2][index3] == 1)
            return true;
        else
            return false;
    }


    public static void resultTostring()
    {
        string resultAsLine = "";
        Console.WriteLine(resultArray.Length.ToString());
        foreach (int i in resultArray.OrderBy(i => i).ToArray())
        {
            resultAsLine += (i + 1) + " ";
        }
        resultAsLine = resultAsLine.Substring(0, resultAsLine.Length - 1);
        Console.WriteLine(resultAsLine);
    }

    public static IEnumerable<IEnumerable<T>> Combinations<T>(this IEnumerable<T> elements, int k)
    {
        return k == 0 ? new[] { new T[0] } :
            elements.SelectMany((e, i) =>
                                elements.Skip(i + 1).Combinations(k - 1).Select(c => (new[] { e }).Concat(c)));
    }

    public static int coubtOfPossibleTriangles<T>(this IEnumerable<T> elements, int k)
    {
        return k == 0 ? 0 :
            elements.SelectMany((e, i) =>
                                elements.Skip(i + 1).Combinations(k - 1).Select(c => (new[] { e }).Concat(c))).Count();
    }

    // Recursive
    public static List<List<T>> GetAllCombosREC<T>(List<T> list)
    {
        List<List<T>> result = new List<List<T>>();
        // head
        result.Add(new List<T>());
        result.Last().Add(list[0]);
        if (list.Count == 1)
            return result;
        // tail
        List<List<T>> tailCombos = GetAllCombosREC(list.Skip(1).ToList());
        tailCombos.ForEach(combo =>
        {
            result.Add(new List<T>(combo));
            combo.Add(list[0]);
            result.Add(new List<T>(combo));
        });
        return result;
    }

    // Iterative, using 'i' as bitmask to choose each combo members
    public static List<List<T>> GetAllCombos<T>(List<T> list)
    {
        int comboCount = (int)Math.Pow(2, list.Count) - 1;
        List<List<T>> result = new List<List<T>>();
        for (int i = 1; i < comboCount + 1; i++)
        {
            // make each combo here
            result.Add(new List<T>());
            for (int j = 0; j < list.Count; j++)
            {
                if ((i >> j) % 2 != 0)
                    result.Last().Add(list[j]);
            }
        }
        return result;
    }
    
}
