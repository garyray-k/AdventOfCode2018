using System;

namespace AdventOfCode {
    internal class WatchObservationEntry {
        public DateTime observationTime { get; set; }
        public string activityObserved { get; set; }

        public WatchObservationEntry(string dateAndTime, string activity) {
            observationTime = Convert.ToDateTime(dateAndTime);
            activityObserved = activity;
        }
    }
}
