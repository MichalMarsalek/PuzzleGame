using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleGame
{
    public class LangList : LangValue
    {
        public List<LangValue> Values { get; private set; }

        public LangList()
        {
            Values = new List<LangValue>();
        }

        public LangList(LangValue val)
        {
            Values = new List<LangValue>() { val };
        }

        public LangList(List<LangValue> vals)
        {
            Values = new List<LangValue>(vals);
        }

        public override string ToString()
        {
            return "[" + String.Join(", ", Values.Select(i => i.ToString())) + "]";
        }

        public LangBool revopIn(LangNumber left)
            => new LangBool(this.Values.Any(i => i is LangNumber &&  (LangNumber)i == left));
    }
}
