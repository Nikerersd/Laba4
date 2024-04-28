using System;
using System.Collections.Generic;
using System.IO;

public class Program
{
    static double f(double x)
    {
        return x * Math.Log(x + 1) - 1;
    }

    static double df(double x)
    {
        return Math.Log(x + 1) + x / (x + 1);
    }

    static double g(double x)
    {
        if (x < 0.0) return Math.Exp(1.0 / x) - 1;
        else return 1.0 / Math.Log(x + 1);
    }

    static void bisectionMethod(double a, double b, double eps, List<Tuple<int, double, double, double>> bisection, ref double res) {
        int N = 0;
        while ((b - a) >= eps && N < 100)
        {
            double c = (a + b) / 2;
            bisection.Add(Tuple.Create(N, a, b, b - a));
            if (f(c) == 0)
            {
                break;
            }
            else if (f(a) * f(c) < 0)
            {
                b = c;
            }
            else
            {
                a = c;
            }
            N++;
            res = c;
        }
    }

    static void NewtonMethod(double x0, double eps, List<Tuple<int, double, double, double>> newton, ref double res)
    {
        int N = 0;
        while (Math.Abs(f(x0)) >= eps && N < 100)
        {
            double x1 = x0 - f(x0) / df(x0);
            double razn = Math.Abs(x1 - x0);
            if (razn < 0.0001) razn = 0.0001;
            newton.Add(Tuple.Create(N, x0, x1, razn));
            if (Math.Abs(x1 - x0) <= eps)
            {
                break;
            }
            x0 = x1;
            N++;
            res = x0;
        }
    }

    static void simpleMethod(double x0, double eps, List<Tuple<int, double, double, double>> simple, ref double res)
    {
        int N = 0;
        while (Math.Abs(g(x0)) >= eps && N < 100)
        {
            double x1 = g(x0);
            if (Math.Abs(x1 - x0) < eps)
            {
                break;
            }
            simple.Add(Tuple.Create(N, x0, x1, Math.Abs(x1 - x0)));
            x0 = x1;
            N++;
            res = x0;
        }
    }

    static void Main(string[] args)
    {
        double a = -1, b = 2, eps = 0.0001;
        double res = 0;
        List<Tuple<int, double, double, double>> bisection = new List<Tuple<int, double, double, double>>();
        List<Tuple<int, double, double, double>> newton = new List<Tuple<int, double, double, double>>();
        List<Tuple<int, double, double, double>> simple = new List<Tuple<int, double, double, double>>();

        using (StreamWriter outfile = new StreamWriter("FunctionsResult#.txt"))
        {
            //Первый корень
            bisectionMethod(a, b, eps, bisection, ref res);
            outfile.WriteLine("Метод половинного деления(первый корень):");
            outfile.WriteLine("{0,20}{1,20}{2,20}{3,20}", "N", "a", "b", "b - a");
            foreach (Tuple<int, double, double, double> i in bisection)
            {
                outfile.WriteLine("{0,20}{1,20}{2,20}{3,20}", i.Item1, i.Item2, i.Item3, i.Item4);
            }
            outfile.WriteLine();
            outfile.WriteLine("Корень: " + res);
            outfile.WriteLine();
            double x0 = -0.5;
            NewtonMethod(x0, eps, newton, ref res);
            outfile.WriteLine("Метод Ньютона(первый корень):");
            outfile.WriteLine("{0,20}{1,20}{2,20}{3,20}", "N", "x0", "x1", "x1 - x0");
            foreach (Tuple<int, double, double, double> i in newton)
            {
                outfile.WriteLine("{0,20}{1,20}{2,20}{3,20}", i.Item1, i.Item2, i.Item3, i.Item4);
            }
            outfile.WriteLine();
            outfile.WriteLine("Корень: " + res);
            outfile.WriteLine();
            simpleMethod(x0, eps, simple, ref res);
            outfile.WriteLine("Метод простых итераций(первый корень):");
            outfile.WriteLine("{0,20}{1,20}{2,20}{3,20}", "N", "x0", "x1", "x1 - x0");
            foreach (Tuple<int, double, double, double> i in simple)
            {
                outfile.WriteLine("{0,20}{1,20}{2,20}{3,20}", i.Item1, i.Item2, i.Item3, i.Item4);
            }
            outfile.WriteLine();
            outfile.WriteLine("Корень: " + res);
            outfile.WriteLine();
            outfile.WriteLine("--------------------------------------------------------------");
            //Второй корень
            bisection.Clear();
            newton.Clear();
            simple.Clear();
            a = 0; b = 2;
            bisectionMethod(a, b, eps, bisection, ref res);
            outfile.WriteLine("Метод половинного деления(Второй корень):");
            outfile.WriteLine("{0,20}{1,20}{2,20}{3,20}", "N", "a", "b", "b - a");
            foreach (Tuple<int, double, double, double> i in bisection)
            {
                outfile.WriteLine("{0,20}{1,20}{2,20}{3,20}", i.Item1, i.Item2, i.Item3, i.Item4);
            }
            outfile.WriteLine();
            outfile.WriteLine("Корень: " + res);
            outfile.WriteLine();
            x0 = 0.5;
            NewtonMethod(x0, eps, newton, ref res);
            outfile.WriteLine("Метод Ньютона(Второй корень):");
            outfile.WriteLine("{0,20}{1,20}{2,20}{3,20}", "N", "x0", "x1", "x1 - x0");
            foreach (Tuple<int, double, double, double> i in newton)
            {
                outfile.WriteLine("{0,20}{1,20}{2,20}{3,20}", i.Item1, i.Item2, i.Item3, i.Item4);
            }
            outfile.WriteLine();
            outfile.WriteLine("Корень: " + res);
            outfile.WriteLine();
            simpleMethod(x0, eps, simple, ref res);
            outfile.WriteLine("Метод простых итераций(Второй корень):");
            outfile.WriteLine("{0,20}{1,20}{2,20}{3,20}", "N", "x0", "x1", "x1 - x0");
            foreach (Tuple<int, double, double, double> i in simple)
            {
                outfile.WriteLine("{0,20}{1,20}{2,20}{3,20}", i.Item1, i.Item2, i.Item3, i.Item4);
            }
            outfile.WriteLine();
            outfile.WriteLine("Корень: " + res);
        }
    }
}