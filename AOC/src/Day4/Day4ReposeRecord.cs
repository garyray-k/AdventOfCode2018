using System;
using System.Collections.Generic;
using AdventOfCode.src.Utilities;

namespace AdventOfCode.src.Day4 {
    public class Day4ReposeRecord : IChallengeAnswerer {
        public Day4ReposeRecord() {
        }
        private static List<WatchObservationEntry> ParseWatchSchedule(string[] watchSchedule) {
            List<WatchObservationEntry> watchObservations = new List<WatchObservationEntry> { };
            foreach (string entry in watchSchedule) {
                string[] splitEntry = entry.Split('[', ']');
                WatchObservationEntry watchObservationEntry = new WatchObservationEntry(splitEntry[1], splitEntry[2]);
                watchObservations.Add(watchObservationEntry);
            }
            return watchObservations;
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

        public string[] ReceiveInput() {
            throw new NotImplementedException();
        }

        public string ProvideAnswer() {
            throw new NotImplementedException();
        }
    }
}
