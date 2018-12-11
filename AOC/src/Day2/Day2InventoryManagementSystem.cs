using System;
using System.Linq;

namespace AdventOfCode.src.Day2 {
    public class Day2InventoryManagementSystem {
        public Day2InventoryManagementSystem() {
        }
        private static void Day2Challenge1CharCounting(string[] inputLines) {
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

        private static void Day2Challenge2CharDupeTripCounting(string[] inputLines) {
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
    }
}
