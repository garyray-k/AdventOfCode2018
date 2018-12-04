﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode
{
    class Program
    {
        static void Main(string[] args) {
            // Day1 Testing - FrequencyCalibration(args);
            string[] inputLines = ParseLinesFromInput(args);
            // Day2Test1CharCounting(inputLines);
            // Day2Test2CharDupeTripCounting(inputLines);
            char[] delimiterChars = { '#', '@', ',', ':', 'x' };
            int[,] fabric = new int[1000, 1000];
            int answer = 0;
            foreach (string line in inputLines) {
                string[] words = line.Split(delimiterChars);
                int uniqueId = Convert.ToInt32(words[1].Trim());
                int xAxisStart = Convert.ToInt32(words[2].Trim());
                int yAxisStart = Convert.ToInt32(words[3].Trim());
                int width = Convert.ToInt32(words[4].Trim());
                int length = Convert.ToInt32(words[5].Trim());
                for (int x = (xAxisStart); x < (xAxisStart + width); x++) {
                    for (int y = (yAxisStart); y < (yAxisStart + length); y++) {
                        fabric[x, y]++; 
                    }
                }
            }
            // NOT DRY AT ALL!! Gross... Sorry.
            foreach (string line in inputLines) {
                string[] words = line.Split(delimiterChars);
                int uniqueId = Convert.ToInt32(words[1].Trim());
                int xAxisStart = Convert.ToInt32(words[2].Trim());
                int yAxisStart = Convert.ToInt32(words[3].Trim());
                int width = Convert.ToInt32(words[4].Trim());
                int length = Convert.ToInt32(words[5].Trim());
                int total = 0;
                for (int x = (xAxisStart); x < (xAxisStart + width); x++) {
                    for (int y = (yAxisStart); y < (yAxisStart + length); y++) {
                        total += fabric[x, y];
                    }
                }
                if (total == (width * length)) {
                    answer = uniqueId;
                }
            }
            Console.WriteLine("The answer is: {0}", answer);
            Console.WriteLine("Finished! Press Enter to continue.");

            Console.ReadKey();
        }

        private static void Day2Test2CharDupeTripCounting(string[] inputLines) {
            foreach (string line in inputLines) {
                char[] charsInLine = line.ToCharArray();
                foreach (string comparisonLine in inputLines) {
                    if (comparisonLine == line) {
                        continue;
                    }
                    char[] charsInComparison = comparisonLine.ToCharArray();
                    if (charsInLine.Length != charsInComparison.Length) {
                        continue;
                    }
                    int numberOfSameChars = 0;
                    for (int x = 0; x < charsInLine.Length; x++) {
                        if (charsInLine[x] == charsInComparison[x]) {
                            numberOfSameChars++;
                        }
                    }
                    if (numberOfSameChars == charsInLine.Length - 1) {
                        Console.WriteLine(line);
                        Console.WriteLine(comparisonLine);
                        for (int x = 0; x < charsInLine.Length; x++) {
                            if (charsInLine[x] == charsInComparison[x]) {
                                Console.Write(charsInLine[x]);
                            }
                        }
                        Console.WriteLine("");
                        break;
                    }
                }
            }
        }

        private static void Day2Test1CharCounting(string[] inputLines) {
            int twoCharCounter = 0;
            int threeCharCounter = 0;
            foreach (string line in inputLines) {
                Console.WriteLine(line);
                char[] letters = line.ToCharArray();
                bool hasTwoLetters = letters.GroupBy(z => z).Where(z => z.Count() == 2).Any();
                if (hasTwoLetters) {
                    Console.WriteLine("{0} has duplicate letter(s)", line);
                    twoCharCounter++;
                }
                bool hasThreeLetters = letters.GroupBy(z => z).Where(z => z.Count() == 3).Any();
                if (hasThreeLetters) {
                    Console.WriteLine("{0} has triplicate letter(s)", line);
                    threeCharCounter++;
                }
            }
            Console.WriteLine("{0} instances of duplicates and {1} instances of triplicates.", twoCharCounter, threeCharCounter);
            Console.WriteLine("The answer is: " + (twoCharCounter * threeCharCounter));
        }

        private static void FrequencyCalibrationDay1(string[] args) {
            string[] inputLines = ParseLinesFromInput(args);
            long total = 0;
            List<long> totals = new List<long> { };
            long answer = 0;
            while (answer == 0) {
                foreach (string line in inputLines) {
                    total += Convert.ToInt64(line);
                    if (totals.Contains(total)) {
                        answer = total;
                        Console.WriteLine("The answer is: " + total);
                        break;
                    }
                    totals.Add(total);
                    Console.WriteLine("Adding: " + line);
                    Console.WriteLine("Total currently: " + total);
                }
            }
        }

        private static string[] ParseLinesFromInput(string[] args) {
            if (args.Length == 0) {
                throw new NullReferenceException("Must use console argument for input.");
            }
            string[] inputLines = System.IO.File.ReadAllLines(args[0]);
            return inputLines;
        }
    }
}
