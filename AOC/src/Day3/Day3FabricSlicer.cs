using System;
using AdventOfCode.src.Utilities;

namespace AdventOfCode.src.Day3 {
    public class Day3FabricSlicer : IChallengeAnswerer {
        public Day3FabricSlicer() {
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

        public string ProvideAnswer() {
            throw new NotImplementedException();
        }

        public string[] ReceiveInput() {
            throw new NotImplementedException();
        }
    }
}
