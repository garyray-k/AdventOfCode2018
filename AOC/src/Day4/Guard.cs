using System.Collections.Generic;

namespace AdventOfCode {
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
}
