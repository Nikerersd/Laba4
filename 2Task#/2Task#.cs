using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        Random random = new Random();
        //1-2
        int N = 10;
        List<int> randNum = new List<int>();

        for (int i = 0; i < N; i++)
        {
            randNum.Add(random.Next(100, 201));
        }
        randNum.Sort();
        Console.Write("Массив с случайными значениями: ");
        foreach (int n in randNum)
        {
            Console.Write(n + " ");
        }
        Console.WriteLine();
        Console.WriteLine("Второй по величине элемент: " + randNum[N - 2]);
        int sum = 0;
        randNum.RemoveAt(randNum.Count - 1);
        randNum.RemoveAt(randNum.Count - 1);
        randNum.RemoveAt(0);
        foreach (int i in randNum)
        {
            sum += i;
        }
        Console.WriteLine("Сумма: " + sum);

        randNum.Clear();
        //3
        List<int> randNum1 = new List<int>();
        List<int> New = new List<int>();

        for (int i = 0; i < N; i++)
        {
            randNum.Add(random.Next(-50, 51));
        }

        for (int i = 0; i < N; i++)
        {
            randNum1.Add(random.Next(-50, 51));
        }

        int ind = 0;
        foreach (int n in randNum)
        {
            if (ind % 2 == 0)
            {
                New.Add(n + randNum1[ind]);
            }
            else
            {
                New.Add(n - randNum1[ind]);
            }
            ind++;
        }
        Console.Write("Первый массив с случайными значениями: ");
        foreach (int n in randNum)
        {
            Console.Write(n + " ");
        }
        Console.WriteLine();
        Console.Write("Второй массив с случайными значениями: ");
        foreach (int n in randNum1)
        {
            Console.Write(n + " ");
        }
        Console.WriteLine();
        Console.Write("Новый массив: ");
        foreach (int n in New)
        {
            Console.Write(n + " ");
        }
        Console.WriteLine();
        Dictionary<int, int> povtor = new Dictionary<int, int>();
        foreach (int n in New)
        {
            if (povtor.ContainsKey(n))
            {
                povtor[n]++;
            }
            else
            {
                povtor[n] = 1;
            }
        }
        foreach (KeyValuePair<int, int> n in povtor)
        {
            Console.WriteLine("Элемент: " + n.Key + " Количество повторов: " + n.Value);
        }
        int a, b;
        Console.Write("Введите начальный и конечный год: ");
        var inputs = Console.ReadLine().Split();
        a = int.Parse(inputs[0]);
        b = int.Parse(inputs[1]);
        List<int> visokYears = new List<int>();
        for (int i = a; i <= b; i++)
        {
            if (i % 4 == 0)
            {
                visokYears.Add(i);
            }
        }
        Console.Write("Високосные годы: ");
        foreach (int n in visokYears)
        {
            Console.Write(n + " ");
        }
    }
}