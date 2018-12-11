namespace AdventOfCode {
    class Coordinate {
        public int XCoord { get; set; }
        public int YCoord { get; set; }
        public int ClosestSpace { get; set; }
        public char GUID { get; set; }

        public Coordinate(int x, int y, char guid) {
            XCoord = x;
            YCoord = y;
            GUID = guid;
        }
    }
}
