using System;
using System.Collections.Generic;

namespace dfa
{
    class DFA
    {
        public DFA(int tn, int sn, int initial, IList<int> acceptings)
        {
            Transitions = new Dictionary<int, IDictionary<string, int>>(tn);
            States = sn;
            Initial = initial;
            Acceptings = new List<int>(acceptings);
        }
        public IDictionary<int, IDictionary<string, int>> Transitions { get; set; }
        public int Initial { get; set; }
        public IList<int> Acceptings { get; set; }
        public int States { get; set; }

        public bool Accepts(string input, int initial = 0)
        {
            var s = initial;
            foreach (var c in input)
            {
                if (!Transitions.TryGetValue(s, out var v) || !v.TryGetValue(c.ToString(), out s))
                {
                    return false;
                }
            }
            return Acceptings.Contains(s);
        }
    }
}
