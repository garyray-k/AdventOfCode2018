using System;

namespace AdventOfCode
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0) {
                throw new NullReferenceException("Must use console argument for input.");
            }
            string[] inputLines = System.IO.File.ReadAllLines(args[0]);
            int total = 0;
            foreach (string line in inputLines) {
                total += Convert.ToInt32(line);
                System.Console.WriteLine("Adding: " + line);
                System.Console.WriteLine("Total: " + total);
            }
            Console.WriteLine("Finished! Press Enter to continue.");
            Console.ReadKey();

        }
    }
}
