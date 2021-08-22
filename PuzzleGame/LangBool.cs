using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleGame
{
    public class LangBool : LangValue
    {
        public bool Value { get; private set; }

        public LangBool(bool val)
        {
            Value = val;
        }

        public override string ToString()
        {
            return Value.ToString();
        }

        public LangBool opAnd(LangBool right) => new LangBool(Value && right.Value);
        public LangBool opOr(LangBool right) => new LangBool(Value || right.Value);
    }
}
