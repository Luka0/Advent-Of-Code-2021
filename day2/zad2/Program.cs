using System;
using System.Collections.Generic;
using System.IO;

namespace zad2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Part1();
            Part2();
        }

        static void Part1()
        {
            int horisontalPosition = 0;
            int depth = 0;

            string[] lines = File.ReadAllLines("input.txt"); //reads the file by lines

            foreach(string line in lines)
            {
                char numberAsString = line[line.Length - 1];
                int value = numberAsString - 48;

                if(line[0] == 'f')
                {
                    horisontalPosition += value;
                }
                else if(line[0] == 'd')
                {
                    depth += value;
                }
                else
                {
                    depth -= value;
                }
            }

            Console.WriteLine(horisontalPosition * depth);
        }


        static void Part2()
        {
            int horisontalPosition = 0;
            int depth = 0;
            int aim = 0;

            string[] lines = File.ReadAllLines("input.txt");

            foreach (string line in lines)
            {
                char numberAsString = line[line.Length - 1];
                int value = numberAsString - 48;

                if (line[0] == 'f')
                {
                    horisontalPosition += value;
                    depth += aim * value;
                }
                else if (line[0] == 'd')
                {
                    aim += value;
                }
                else
                {
                    aim -= value;
                }
            }

            Console.WriteLine(horisontalPosition * depth);
        }

    }
}
