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
            Console.WriteLine("Finished! Press Enter to continue.");
            Console.ReadKey();
        }

        private static void FrequencyCalibration(string[] args) {
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
