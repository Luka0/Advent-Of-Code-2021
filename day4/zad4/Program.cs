using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace zad4
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
            // READING THE INPUT
            string[] lines = File.ReadAllLines("input.txt");

            string[] chosenNumbers = lines[0].Split(','); // Separating the chosen numbers

            int brTablica = (lines.Length - 1) / 6;
            int trenutnaTablica, trenutniRed;
            string[,,] tablice = new string[brTablica, 5, 5];
            string[] rowToAppend = new string[5];
            string row;
            for (int i = 2; i < lines.Length; i++)// Separating the tables into a 3D array
            {
                row = lines[i];
                if (row == "")
                {
                    continue;
                }
                rowToAppend[0] = row[0].ToString() + row[1].ToString();
                rowToAppend[1] = row[3].ToString() + row[4].ToString();
                rowToAppend[2] = row[6].ToString() + row[7].ToString();
                rowToAppend[3] = row[9].ToString() + row[10].ToString();
                rowToAppend[4] = row[12].ToString() + row[13].ToString();

                trenutnaTablica = (i - 1) / 6;
                trenutniRed = (i - 1) % 6 - 1;

                for (int j = 0; j < 5; j++)
                    tablice[trenutnaTablica, trenutniRed, j] = rowToAppend[j];

            }



            // Pozovi JeDobitna za svaki izvučeni broj
            int[] izvuceniBrojevi = new int[chosenNumbers.Length];
            for (int i = 0; i < chosenNumbers.Length; i++)
            {
                izvuceniBrojevi[i] = -1;
            }

            int winCount = 0;
            int currentWinInd;
            int[] allWinIndexes = new int[brTablica];
            for (int i = 0; i < brTablica; i++) allWinIndexes[i] = -1;

            string[,] dobitnaTablica = new string[5, 5];
            for (int i = 0; i < chosenNumbers.Length; i++)
            {
                izvuceniBrojevi[i] = int.Parse(chosenNumbers[i]);

                while (JeDobitna(tablice, izvuceniBrojevi) > -1) //Tu ide while jer vise tablica moze postat dobitno na istom izvucenom broju
                {
                    currentWinInd = JeDobitna(tablice, izvuceniBrojevi);
                    if (!allWinIndexes.Contains(currentWinInd))
                    {
                        for (int j = 0; j < brTablica; j++)
                        {
                            if (allWinIndexes[j] == -1)
                            {
                                allWinIndexes[j] = currentWinInd;
                                break;
                            }
                        }
                    }

                    //Ispiši score dobitne tablice
                    for (int j = 0; j < 5; j++)
                    {
                        for (int k = 0; k < 5; k++)
                        {
                            dobitnaTablica[j, k] = tablice[currentWinInd, j, k];
                        }
                    }
                    Console.WriteLine($"skor: {scoreCalculator(dobitnaTablica, izvuceniBrojevi)}");

                    //Neutraliziraj trenutnu dobivenu tablicu
                    for(int j = 0; j < 5; j++)
                    {
                        for(int k = 0; k < 5; k++)
                        {
                            tablice[currentWinInd, j, k] = "-2";
                        }
                    }
                }
            }

            //Provjera za indexe
            //for (int i = 0; i < allWinIndexes.Length; i++) Console.WriteLine(allWinIndexes[i]);
        }









        /* PRVI DIO ZADATKA */
        static void Part1()
        {
            // Reading the input
            string[] lines = File.ReadAllLines("input.txt");

            // Separating the chosen numbers
            string[] chosenNumbers = lines[0].Split(',');

            // Separating the tables into a 3D array
            int brTablica = (lines.Length - 1) / 6;
            int trenutnaTablica, trenutniRed;
            string[,,] tablice = new string[brTablica, 5, 5];
            string[] rowToAppend = new string[5];
            string row;
            for (int i = 2; i < lines.Length; i++) { //za svaku liniju u input fajlu
                row = lines[i];
                if (row == "")
                {
                    continue;
                }
                rowToAppend[0] = row[0].ToString() + row[1].ToString(); 
                rowToAppend[1] = row[3].ToString() + row[4].ToString();
                rowToAppend[2] = row[6].ToString() + row[7].ToString();
                rowToAppend[3] = row[9].ToString() + row[10].ToString();
                rowToAppend[4] = row[12].ToString() + row[13].ToString();

                trenutnaTablica = (i - 1) / 6;
                trenutniRed = (i - 1) % 6 - 1;

                for (int j = 0; j < 5; j++)
                    tablice[trenutnaTablica, trenutniRed, j] = rowToAppend[j];

            }

            // Pozovi JeDobitna za svaki izvučeni broj
            int[] izvuceniBrojevi = new int[chosenNumbers.Length];
            for(int i = 0; i < chosenNumbers.Length; i++)
            {
                izvuceniBrojevi[i] = -1;
            }

            for (int i = 0; i < chosenNumbers.Length; i++)
            {
                izvuceniBrojevi[i] = int.Parse(chosenNumbers[i]);
                //Console.WriteLine(JeDobitna(tablice, izvuceniBrojevi));
                if (JeDobitna(tablice, izvuceniBrojevi) > -1) {
                    //Console.WriteLine($"Dobitni broj je {izvuceniBrojevi[i]}");
                    string[,] dobitnaTablica = new string[5, 5];
                    for(int j = 0; j < 5; j++)
                    {
                        for(int k = 0; k < 5; k++)
                        {
                            dobitnaTablica[j, k] = tablice[JeDobitna(tablice, izvuceniBrojevi), j, k];
                        }
                    }
                    for (int j = 0; j < 5; j++)
                    {
                        for (int k = 0; k < 5; k++)
                            Console.Write(dobitnaTablica[j, k] + " ");

                        Console.WriteLine();
                    }

                    Console.WriteLine($"Final score: {scoreCalculator(dobitnaTablica, izvuceniBrojevi)}");
                    break;
                }
            }

        }

        static int JeDobitna(string[,,] tablice, int[] chosenNumbers) //vraća indeks dobitne tablice ili -1 ako nije nijedna
        {
            //pazi!!! -> chosenNumbers su samo dosad izvučeni brojevi
            string[,] trenutnaTablica = new string[5, 5];
            for(int i = 0; i < tablice.Length / 25; i++)
            {
                // trenutnaTablica = tablice[i];
                for(int j = 0; j < 5; j++)
                {
                    for(int k = 0; k < 5; k++)
                    {
                        trenutnaTablica[j, k] = tablice[i, j, k];
                    }
                }

                // hoizontalna provjera
                bool dobitniRed;
                for(int j = 0; j < 5; j++)
                {
                    dobitniRed = true;
                    for(int k = 0; k < 5; k++)
                    {
                        if(!chosenNumbers.Contains(int.Parse(trenutnaTablica[j, k]))) //chosenNumbers su samo dosad izvučeni !!!
                        {
                            dobitniRed = false;
                            break;
                        }
                    }
                    if (dobitniRed)
                        return i;
                }

                //vertikalna provjera - transponirali smo
                for (int j = 0; j < 5; j++)
                {
                    for (int k = 0; k < 5; k++)
                    {
                        trenutnaTablica[j, k] = tablice[i, k, j];
                    }
                }

                for (int j = 0; j < 5; j++)
                {
                    dobitniRed = true;
                    for (int k = 0; k < 5; k++)
                    {
                        if (!chosenNumbers.Contains(int.Parse(trenutnaTablica[j, k]))) //chosenNumbers su samo dosad izvučeni !!!
                        {
                            dobitniRed = false;
                            break;
                        }
                    }
                    if (dobitniRed)
                        return i;
                }
            }
            return -1;
        }

        static int scoreCalculator(string[,] tablica, int[] chosenNumbers)
        {
            int score = 0;
            int zadnjiIzvucen = 0;
            for(int i = 0; i < chosenNumbers.Length-1; i++)
            {
                if(chosenNumbers[i+1] == -1 || i == chosenNumbers.Length - 2)
                {
                    zadnjiIzvucen = chosenNumbers[i];
                    break;
                }
            }
            for(int i = 0; i < 5; i++)
            {
                for(int j = 0; j < 5; j++)
                {
                    
                    if(!chosenNumbers.Contains(int.Parse(tablica[i, j])))
                    {
                        score = score + int.Parse(tablica[i, j]);
                    }
                }
            }

            score = score * zadnjiIzvucen;

            return score;
        }

    }
}
