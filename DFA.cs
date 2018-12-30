using System;
using System.Collections.Generic;

namespace dfa
{
    class DFA
    {
        public IList<IDictionary<string, int>> Transitions { get; set; }
        public int Initial { get; set; }
        public IList<int> Acceptings { get; set; }
        public int States { get; set; }
    }
}
