using System;
using System.IO;
using System.Collections.Generic;

namespace dfa
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("dfa.txt");
            int.TryParse(lines[1], out var sn);
            int.TryParse(lines[2], out var tn);
            var ts = new Dictionary<int, Dictionary<string, int>>(sn);
            for (int i = 0; i < tn; i++)
            {
                var lineParts = lines[i + 3].Split(" ");
                int.TryParse(lineParts[0], out var src);
                int.TryParse(lineParts[2], out var dst);
                if (ts.ContainsKey(src))
                {
                    ts.GetValueOrDefault(src).Add(lineParts[1], dst);
                } else {
                    ts.Add(src, new Dictionary<string, int> { { lineParts[1], dst } });
                }
            }

            var acceptingsLineParts = lines[lines.Length - 2].Split(" ");
            int.TryParse(acceptingsLineParts[0], out var acceptingsCount);
            var acceptings = new List<int>(acceptingsCount);
            for (int i = 1; i < acceptingsLineParts.Length; i++)
            {
                int.TryParse(acceptingsLineParts[i], out var accepting);
                acceptings.Add(accepting);
            }

            var dfa = new DFA(tn, sn, 0, acceptings);
            foreach (var t in ts)
            {
                dfa.Transitions.Add(t.Key, t.Value);
            }

            Console.WriteLine("string to check ($ to end):");
            while (true)
            {
                Console.Write("  =: ");
                var input = Console.ReadLine();
                if (input == "$") { Console.WriteLine("\nExiting..."); break; }
                var res = "Rejected";
                Console.ForegroundColor = ConsoleColor.Red;
                if (dfa.Accepts(input, 0))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    res = "Accepted";
                } 
                Console.WriteLine($"  => {res}");
                Console.ResetColor();
                Console.WriteLine();
                Console.WriteLine();
            }
        }
    }
}
