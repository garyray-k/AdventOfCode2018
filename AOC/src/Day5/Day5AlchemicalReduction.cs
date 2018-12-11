using System;
using AdventOfCode.src.Utilities;

namespace AdventOfCode.src.Day5 {
    public class Day5AlchemicalReduction : IChallengeAnswerer {
        public Day5AlchemicalReduction() {
        }

        // Day 5 I only completed 1 gold star and did not finish the second challenge of the day
        private static void Day5Challenge(string[] inputLines) {
            if (inputLines.Length == 0) {
                throw new NullReferenceException("Must use console argument for input.");
            }
            string input = System.IO.File.ReadAllText(inputLines[0]);
            string defaultInput = System.IO.File.ReadAllText(inputLines[0]);
            string alphabet = "abcdefghijklmnopqrstuvwxyz";
            Dictionary<char, int> maxLetter = new Dictionary<char, int> { };
            foreach (var letter in alphabet) {
                input = System.IO.File.ReadAllText(inputLines[0]).Trim();
                maxLetter.Add(letter, 0);
                Console.WriteLine("Begin length ({0}): {1}", letter, input.Length);
                for (int i = 0; i < input.Length; i++) {
                    if (Char.ToLower(letter) == input[i]) {
                        input = input.Remove(i, 1);
                    }
                    if (Char.ToUpper(letter) == input[i]) {
                        input = input.Remove(i, 1);
                    }
                }
            //Console.WriteLine("Remove {0} length: {1}", letter, input.Length);
            StartOver:
                for (int i = 0; i < input.Length - 1; i++) {
                    bool isUpperAndLower = (Char.IsUpper(input[i]) && Char.IsLower(input[i + 1])) || (Char.IsUpper(input[i + 1]) && Char.IsLower(input[i]));
                    if (isUpperAndLower) {
                        if (Char.ToLower(input[i]) == Char.ToLower(input[i + 1])) {
                            //Console.WriteLine("Removing: {0} {1}", input[i], input[i + 1]);
                            input = input.Remove(i, 2);
                            goto StartOver;
                        }
                    }
                }
                maxLetter[letter] = input.Length;
                Console.WriteLine("The letter {0} gives us a length of: {1}", letter, input.Length);
            }

            Console.WriteLine("The answer is: {0}", maxLetter.Values.Min());
        }

        public string ProvideAnswer() {
            throw new NotImplementedException();
        }

        public string[] ReceiveInput() {
            throw new NotImplementedException();
        }
    }
}
