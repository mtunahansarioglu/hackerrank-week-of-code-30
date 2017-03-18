using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
public static class Program
{

    public static List<int> x;//poles
    public static List<int> y;//weights
    static void Main(String[] args)
    {
        string[] tokens_n = Console.ReadLine().Split(' ');
        int n = Convert.ToInt32(tokens_n[0]);
        int k = Convert.ToInt32(tokens_n[1]);
        x = new List<int>();
        y = new List<int>();
        for (int a0 = 0; a0 < n; a0++)
        {
            string[] tokens_x_i = Console.ReadLine().Split(' ');
            int x_i = Convert.ToInt32(tokens_x_i[0]);
            int w_i = Convert.ToInt32(tokens_x_i[1]);
            x.Add(x_i);
            y.Add(w_i);
        }

        var result = Combinations(x.ToArray(), k);

        List<int> retP = new List<int>();
        foreach (IEnumerable<int> asd in result)
        {
            List<int> aaa = asd.ToList();
            if (aaa[0] == x[0])
            {
                retP.Add(Calcul(aaa));
            }
        }

        Console.WriteLine(retP.Min().ToString());
        string[] waitforit = Console.ReadLine().Split(' ');
    }

    public static int Calcul(List<int> param)
    {
        int retv = 0;
        List<int> k = new List<int>();
        foreach (int i in param)
        {
            k.Add(x.IndexOf(i));
        }
        for (int i = 0; i < k.Count; i++)
        {
            if (i + 1 == k.Count)
                retv += CalcOneStack(k[i], x.Count);
            else
                retv += CalcOneStack(k[i], k[i + 1]);
        }
        return retv;
    }

    public static int CalcOneStack(int Current, int NextInd)
    {
        int ret = 0;
        for (int i = Current; i < NextInd; i++)
        {
            ret += diff(Current, i);
        }
        return ret;

    }

    public static int diff(int xa, int ya)
    {
        return ((x[ya] - x[xa]) * y[ya]);
    }

    public static IEnumerable<IEnumerable<T>> Combinations<T>(this IEnumerable<T> elements, int k)
    {
        return k == 0 ? new[] { new T[0] } :
            elements.SelectMany((e, i) =>
                                elements.Skip(i + 1).Combinations(k - 1).Select(c => (new[] { e }).Concat(c)));
    }


}
