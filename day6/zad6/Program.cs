using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace zad6
{
    class Program
    {
        static void Main(string[] args)
        {
            //Reading the test input
            string[] input = File.ReadAllLines("input.txt")[0].Split(',');
            List<ulong> ulaz = new List<ulong>();
            foreach (string i in input) ulaz.Add(ulong.Parse(i));

            ulong[] ribe = new ulong[9];
            foreach (ulong i in ulaz) ribe[i]++;

            // Main loop
            ulong x0;
            for(int i  = 0; i < 256; i++)
            {
                x0 = ribe[0];
                for(int j = 0; j < 8; j++)
                {
                    ribe[j] = ribe[j + 1];
                }
                ribe[6] += x0;
                ribe[8] = x0;
            }

            // Ispis ukupnog broja riba
            ulong suma = 0;
            foreach (ulong i in ribe) suma += i;
            Console.WriteLine(suma);
        }
    }
}
