using System;
using System.IO;
using System.Collections.Generic;

namespace zad3
{
    class Program
    {
        static void Main(string[] args)
        {
            //Part1();
            Part2();
        }

        static void Part2()
        {
            //Reading the test input
            string[] input = File.ReadAllLines("input.txt");
            List<string> selectedFew = new List<string>();

            List<string> lines = new List<string>();
            for (int i = 0; i < input.Length; i++)
                lines.Add(input[i]);

            //Getting the oxygenGeneratorRating
            List<string> selectedLines = new List<string>();
            int NumOf1s;
            int NumOf0s;
            for (int i = 0; i < 12; i++)
            {
                NumOf1s = 0;
                NumOf0s = 0;
                foreach (string line in lines)
                {
                    if (line[i] == '1')
                        NumOf1s++;
                    else
                        NumOf0s++;
                }
                if (NumOf1s > NumOf0s || NumOf1s == NumOf0s)
                    foreach (string line in lines)
                    {
                        if (line[i] == '1')
                            selectedLines.Add(line);
                    }
                else if (NumOf0s > NumOf1s)
                {
                    foreach (string line in lines)
                    {
                        if (line[i] == '0')
                            selectedLines.Add(line);
                    }
                }

                if (selectedLines.Count == 1)
                {
                    break;
                }
                else
                {
                    lines.Clear();
                    foreach (string line in selectedLines)
                        lines.Add(line);
                    selectedLines.Clear();
                }

            }
            string oxygenGeneratorRating = selectedLines[0]; //oxygenGeneratorRating in binary form

            Console.WriteLine($"oxygenGeneratorRating: {oxygenGeneratorRating}");

            //Getting the CO2ScrubberRating
            lines.Clear();
            for (int i = 0; i < input.Length; i++)
                lines.Add(input[i]);
            selectedLines.Clear();

            for (int i = 0; i < 12; i++)
            {
                NumOf1s = 0;
                NumOf0s = 0;
                foreach (string line in lines)
                {
                    if (line[i] == '1')
                        NumOf1s++;
                    else
                        NumOf0s++;
                }
                if (NumOf1s < NumOf0s)
                    foreach (string line in lines)
                    {
                        if (line[i] == '1')
                            selectedLines.Add(line);
                    }
                else if (NumOf0s < NumOf1s || NumOf1s == NumOf0s)
                {
                    foreach (string line in lines)
                    {
                        if (line[i] == '0')
                            selectedLines.Add(line);
                    }
                }

                if (selectedLines.Count == 1)
                {
                    break;
                }
                else
                {
                    lines.Clear();
                    foreach (string line in selectedLines)
                        lines.Add(line);
                    selectedLines.Clear();
                }

            }
            string CO2ScrubberRating = selectedLines[0];    //CO2ScrubberRating in binary form

            Console.WriteLine($"CO2Scrubber: {CO2ScrubberRating}");
        }

        static void Part1()
        {
            //Reading the test input
            string[] lines = File.ReadAllLines("input.txt");

            //Figuring out gammaRate and epsilonRate from the input
            int NumOf1s, NumOf0s;
            string gammaRate = "";
            string epsilonRate = "";
            for (int i = 0; i < 12; i++)
            {
                NumOf1s = 0;
                NumOf0s = 0;
                foreach (string line in lines)
                {
                    if(line[i] == '1')
                    {
                        NumOf1s++;
                    }
                    else
                    {
                        NumOf0s++;
                    }
                }
                if(NumOf1s > NumOf0s)
                {
                    gammaRate += '1';
                    epsilonRate += '0';
                }
                else
                {
                    gammaRate += '0';
                    epsilonRate += '1';
                }
            }
            Console.WriteLine(gammaRate);
            Console.WriteLine(epsilonRate);

            //Converting gammaRate and epsilonRate from binary to decimal and multiplying them

            /*uses online converter because laziness*/
        }


    }
}
