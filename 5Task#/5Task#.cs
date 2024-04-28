using System;
using System.Collections.Generic;

class Program
{
    static void Xorshift(ref uint value, List<uint> PsevdRand)
    {
        value ^= (value << 13);
        value ^= (value >> 17);
        value ^= (value << 5);
        PsevdRand.Add(value);
    }

    static void Main(string[] args)
    {
        List<uint> PsevdRand = new List<uint>();
        uint value = 12345678;
        for (int i = 0; i < 10; i++)
        {
            Xorshift(ref value, PsevdRand);
        }
        foreach (uint n in PsevdRand)
        {
            Console.Write(n + " ");
        }
        Console.WriteLine();
    }
}