using System;
using System.Collections.Generic;
using AdventOfCode.src.Utilities;

namespace AdventOfCode.src.Day1 {
    public class Day1ChronalCalibrator : IChallengeAnswerer {
        public Day1ChronalCalibrator() {
        }
        private static void FrequencyCalibrationDay1(string[] args) {
            string[] inputLines = InputLinesParser.ParseLinesFromInput(args);
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

        public string ProvideAnswer() {
            throw new NotImplementedException();
        }

        public string[] ReceiveInput() {
            throw new NotImplementedException();
        }
    }
}
