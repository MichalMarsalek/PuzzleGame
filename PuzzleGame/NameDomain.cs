using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleGame
{
    public class NameDomain : Dictionary<string, LangValue>
    {
        public NameDomain() : base() { }
        public NameDomain(Dictionary<string, LangValue> old) : base(old) { }
    }
}
