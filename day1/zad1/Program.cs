using System;

namespace zad1
{
    class Program
    {
        static void PartOne()
        {
            int[] input = new int[2000];
            for (int i = 0; i < 2000; i++)
            {
                input[i] = Convert.ToInt32(Console.ReadLine());
            }

            int increaseCount = 0;
            for (int i = 1; i < 2000; i++)
            {
                if (input[i] > input[i - 1])
                    increaseCount++;
            }

            Console.WriteLine("REZ:");
            Console.WriteLine(increaseCount);
        }

        static void PartTwo()
        {
            int[] input = new int[2000];
            for (int i = 0; i < 2000; i++)
            {
                input[i] = Convert.ToInt32(Console.ReadLine());
            }

            int[] sums = new int[1998];
            for(int i = 0; i < 1998; i++)
            {
                sums[i] = input[i] + input[i+1] + input[i+2];
            }

            int increaseCount = 0;
            for (int i = 1; i < 1998; i++)
            {
                if (sums[i] > sums[i - 1])
                    increaseCount++;
            }

            Console.WriteLine("REZ:");
            Console.WriteLine(increaseCount);
        }

        static void Main(string[] args)
        {
            //PartOne();
            //PartTwo();
        }
    }
}
