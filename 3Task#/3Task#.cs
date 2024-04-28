using System;
using System.Collections.Generic;

class Program
{
    static void RandomFill(List<int> fillList)
    {
        Random random = new Random();
        for (int i = 0; i < fillList.Count; i++)
        {
            fillList[i] = random.Next(1, 101); // Generates numbers between 1 and 100
        }
    }

    static int CountEl(List<int> list, int element)
    {
        int count = 0;
        foreach (int el in list)
        {
            if (el == element) count++;
        }
        return count;
    }

    static double RealExp(List<int> list)
    {
        double sum = 0.0;
        foreach (int n in list)
        {
            sum += n;
        }
        return sum / list.Count;
    }

    static double ExpectedExp(List<int> list)
    {
        double sum = 0.0;
        foreach (int n in list)
        {
            sum += n;
        }
        return sum / 125.0;
    }

    static double Dispersion(List<int> list)
    {
        double mathReal = RealExp(list);
        double sum = 0.0;
        foreach (int value in list)
        {
            sum += Math.Pow(value - mathReal, 2);
        }
        return sum / (list.Count - 1);
    }

    static double Laplas(double i)
    {
        return 0.5 * (1.0 + Erf(i / Math.Sqrt(2.0)));
    }

    static double ChiKv(List<int> list)
    {
        double result = 0.0;
        double mathReal = RealExp(list);
        double Dispers = Math.Sqrt(Dispersion(list));

        for (int i = 1; i <= 125; i++)
        {
            double realIncidence = CountEl(list, i);
            double expIncidence = list.Count * (Laplas((i - mathReal) / Dispers) - Laplas((i - 1 - mathReal) / Dispers));
            if (expIncidence != 0)
            {
                result += Math.Pow(realIncidence - expIncidence, 2) / expIncidence;
            }
        }
        return result;
    }

    static double Erf(double x)
    {
        // An approximation of the error function (erf)
        double t = 1.0 / (1.0 + 0.5 * Math.Abs(x));
        double tau = t * Math.Exp(-Math.Pow(x, 2) - 1.26551223 + 1.00002368 * t + 0.37409196 * Math.Pow(t, 2) + 0.09678418 * Math.Pow(t, 3) - 0.18628806 * Math.Pow(t, 4) + 0.27886807 * Math.Pow(t, 5) - 1.13520398 * Math.Pow(t, 6) + 1.48851587 * Math.Pow(t, 7) - 0.82215223 * Math.Pow(t, 8) + 0.17087277 * Math.Pow(t, 9));
        return x >= 0 ? (1 - tau) : (tau - 1);
    }

    static void Main(string[] args)
    {
        List<int> vector50 = new List<int>(new int[50]);
        List<int> vector100 = new List<int>(new int[100]);
        List<int> vector1000 = new List<int>(new int[1000]);
        RandomFill(vector50);
        RandomFill(vector100);
        RandomFill(vector1000);

        double crit = 156.69; // For 125 degrees of freedom and significance level 0.05

        // Analysis for 50 values
        double chiKvZnach = ChiKv(vector50);
        double mathReal = RealExp(vector50);
        double mathExp = ExpectedExp(vector50);

        Console.WriteLine("Chi-square value: " + chiKvZnach);
        if (chiKvZnach <= crit)
        {
            Console.WriteLine("The hypothesis of a normal distribution of the sample is correct.");
        }
        else
        {
            Console.WriteLine("The hypothesis of a normal distribution of the sample is incorrect.");
        }
        Console.WriteLine("Expected mathematical expectation: " + mathExp);
        Console.WriteLine("Real mathematical expectation: " + mathReal);
        Console.WriteLine();

        // Analysis for 100 values
        chiKvZnach = ChiKv(vector100);
        mathReal = RealExp(vector100);
        mathExp = ExpectedExp(vector100);

        Console.WriteLine("Chi-square value: " + chiKvZnach);
        if (chiKvZnach <= crit)
        {
            Console.WriteLine("The hypothesis of a normal distribution of the sample is correct.");
        }
        else
        {
            Console.WriteLine("The hypothesis of a normal distribution of the sample is incorrect.");
        }
        Console.WriteLine("Expected mathematical expectation: " + mathExp);
        Console.WriteLine("Real mathematical expectation: " + mathReal);
        Console.WriteLine();

        // Analysis for 1000 values
        chiKvZnach = ChiKv(vector1000);
        mathReal = RealExp(vector1000);
        mathExp = ExpectedExp(vector1000);

        Console.WriteLine("Chi-square value: " + chiKvZnach);
        if (chiKvZnach <= crit)
        {
            Console.WriteLine("The hypothesis of a normal distribution of the sample is correct.");
        }
        else
        {
            Console.WriteLine("The hypothesis of a normal distribution of the sample is incorrect.");
        }
        Console.WriteLine("Expected mathematical expectation: " + mathExp);
        Console.WriteLine("Real mathematical expectation: " + mathReal);
        Console.WriteLine();
    }
}
