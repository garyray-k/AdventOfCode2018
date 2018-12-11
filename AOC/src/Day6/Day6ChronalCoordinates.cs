using System;
using System.Collections.Generic;
using AdventOfCode.src.Utilities;

namespace AdventOfCode.src.Day6 {
    public class Day6ChronalCoordinates : IChallengeAnswerer {

        private void Execute() {
            List<Coordinate> coords = new List<Coordinate> { };
            int mapX = 0;
            int mapY = 0;
            char guid = 'a';
            foreach (string line in inputLines) {
                int inputX = Convert.ToInt32(line.Split(' ', ',')[0].Trim());
                int inputY = Convert.ToInt32(line.Split(' ', ',')[2].Trim());
                Coordinate coord = new Coordinate(inputX, inputY, guid);
                guid++;
                if (inputX > mapX) mapX = inputX + 1;
                if (inputY > mapY) mapY = inputY + 1;
                coords.Add(coord);
                Console.WriteLine("{0}: {1}", coord.GUID, line);
            }

            int[,] answerMap = new int[mapX, mapY];

            for (int y = 0; y < mapX; y++) {
                for (int x = 0; x < mapY; x++) {
                    int minDistance = Math.Max(mapX, mapY);
                    char answer = '.';
                    foreach (Coordinate coord in coords) {
                        if (coord.XCoord == x && coord.YCoord == y) {
                            answer = (coord.GUID);
                        }
                    }
                    foreach (Coordinate coord in coords) {
                        int absoluteX = Math.Abs(x - coord.XCoord);
                        int absoluteY = Math.Abs(y - coord.YCoord);
                        int taxiCabDistance = absoluteX + absoluteY;
                        if (answer == coord.GUID) {
                            continue;
                        }
                        if (minDistance < taxiCabDistance) {

                        }
                    }
                    Console.Write("{0}.", answer);
                }
                Console.WriteLine();
            }

            Console.WriteLine("Finished! Press Enter to continue.");

            Console.ReadKey();
        }

        public string ProvideAnswer() {
            throw new NotImplementedException();
        }

        public string[] ReceiveInput() {
            throw new NotImplementedException();
        }
    }
}
