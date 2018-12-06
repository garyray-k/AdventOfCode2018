using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode
{
    class Program
    {
        static void Main(string[] args) {
            // Day1 Challenge - FrequencyCalibration(args);
            //string[] inputLines = ParseLinesFromInput(args);
            // Day2TChallenge1CharCounting(inputLines);
            // Day2Challenge2CharDupeTripCounting(inputLines);
            // int answer = Day3Challenges2DFabricArrayStuff(inputLines);
            //Day4Challenges(inputLines);
            if (args.Length == 0) {
                throw new NullReferenceException("Must use console argument for input.");
            }
            string input = System.IO.File.ReadAllText(args[0]);
            StartOver:
            for (int i = 0; i < input.Length - 1; i++) {
                bool isUpperAndLower = (Char.IsUpper(input[i]) && Char.IsLower(input[i + 1])) || (Char.IsUpper(input[i + 1]) && Char.IsLower(input[i]));
                if (isUpperAndLower) {
                    if (Char.ToLower(input[i]) == Char.ToLower(input[i + 1])) {
                        Console.WriteLine("Removing: {0} {1}", input[i], input[i + 1]);
                        input.Remove(i, 2);
                        goto StartOver;
                    }
                }
            }
            Console.WriteLine("The answer is: {0}", input.Length);
            Console.WriteLine("Finished! Press Enter to continue.");

            Console.ReadKey();
        }

        private static void Day4Challenges(string[] inputLines) {
            List<WatchObservationEntry> watchSchedule = ParseWatchSchedule(inputLines);
            List<WatchObservationEntry> chronologicalWatchSchedule = watchSchedule.OrderBy(z => z.observationTime).ToList();
            List<Guard> guards = new List<Guard> { };
            foreach (WatchObservationEntry entry in chronologicalWatchSchedule) {
                if (entry.activityObserved.Contains("Guard")) {
                    string guardNumber = entry.activityObserved.Split(' ')[2];
                    if (guards.Any(x => x.guardID == guardNumber)) {
                        continue;
                    }
                    guards.Add(new Guard(guardNumber));
                }
            }
            string activeGuard = " ";
            for (int x = 0; x < chronologicalWatchSchedule.Count(); x++) {
                Console.WriteLine("Current entry is {0} {1}", chronologicalWatchSchedule[x].observationTime, chronologicalWatchSchedule[x].activityObserved);
                if (chronologicalWatchSchedule[x].activityObserved.Contains("Guard")) {
                    activeGuard = chronologicalWatchSchedule[x].activityObserved.Split(' ')[2];
                }
                if (chronologicalWatchSchedule[x].activityObserved.Contains("asleep")) {
                    int diff = Convert.ToInt32(chronologicalWatchSchedule[x + 1].observationTime.Subtract(chronologicalWatchSchedule[x].observationTime).TotalMinutes);
                    int index = guards.FindIndex(c => c.guardID == activeGuard);
                    guards.Find(i => i.guardID == activeGuard).minutesAsleep += diff;
                    for (int min = chronologicalWatchSchedule[x].observationTime.Minute; min < (chronologicalWatchSchedule[x].observationTime.Minute + diff); min++) {
                        guards.Find(i => i.guardID == activeGuard).minuteMostAsleep.Add(min);
                    }

                }
                if (chronologicalWatchSchedule[x].activityObserved.Contains("wakes")) {
                    continue;
                }
            }
            guards = guards.OrderByDescending(x => x.minutesAsleep).ToList();
            int maxTimes = 0;
            foreach (Guard guard in guards) {
                // next line used for first challenge.
                // Console.WriteLine("Guard {0} is asleep {1}", guard.guardID, guard.minutesAsleep);
                var guardMinutes = guard.minuteMostAsleep.GroupBy(i => i);
                foreach (var minute in guardMinutes) {
                    if (minute.Count() > maxTimes) {
                        maxTimes = minute.Count();
                        Console.WriteLine("Guard {0} at minute {1} is asleep {2} times.", guard.guardID, minute.Key, minute.Count());
                    }
                }
            }
        }

        //private static List<WatchObservationEntry> OrderObservationsChronologically(List<WatchObservationEntry> observationEntries) {

        //}

        //private static string FindGuardMostAsleep(List<WatchObservationEntry> observations) {

        //}

        private static List<WatchObservationEntry> ParseWatchSchedule(string[] watchSchedule) {
            List<WatchObservationEntry> watchObservations = new List<WatchObservationEntry> { };
            foreach (string entry in watchSchedule) {
                string[] splitEntry = entry.Split('[', ']');
                WatchObservationEntry watchObservationEntry = new WatchObservationEntry(splitEntry[1], splitEntry[2]);
                watchObservations.Add(watchObservationEntry);
            }
            return watchObservations;
        }

        private static int Day3Challenges2DFabricArrayStuff(string[] inputLines) {
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

            return answer;
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

    internal class Guard {
        public int minutesAsleep { get; set; }
        public List<int> minuteMostAsleep { get; set; }
        public string guardID { get; set; }

        public Guard(string guardId) {
            guardID = guardId;
            minutesAsleep = 0;
            minuteMostAsleep = new List<int> { };
        }
    }

    internal class WatchObservationEntry {
        public DateTime observationTime { get; set; }
        public string activityObserved { get; set; }

        public WatchObservationEntry(string dateAndTime, string activity) {
            observationTime = Convert.ToDateTime(dateAndTime);
            activityObserved = activity;
        }
    }
}
