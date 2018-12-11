using System;
namespace AdventOfCode.src.Utilities {
    public class InputLinesParser {
        public static string[] ParseLinesFromInput(string[] args) {
            if (args.Length == 0) {
                throw new NullReferenceException("Must use console argument for input.");
            }
            string[] inputLines = System.IO.File.ReadAllLines(args[0]);
            return inputLines;
        }
    }
}
