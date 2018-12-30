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
            var dfa = new DFA();
            int.TryParse(lines[2], out var tn);
            int.TryParse(lines[1], out var sn);
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

            Log(ts);
        }

        static void Log(IDictionary<int, Dictionary<string, int>> d)
        {
            foreach (var item in d)
            {
                Console.WriteLine($"{item.Key}: ");
                foreach (var entry in item.Value)
                {
                    Console.WriteLine($"    {entry.Key} : {entry.Value}");
                }
            }
        }
    }
}
