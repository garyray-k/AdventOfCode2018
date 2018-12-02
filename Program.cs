using System;
using System.Collections.Generic;
using System.Linq;

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
            long total = 0;
            List<long> totals = new List<long> {};
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

            Console.WriteLine("The total is: " + total);
            Console.WriteLine("Finished! Press Enter to continue.");
            Console.ReadKey();

        }
    }
}
