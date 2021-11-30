using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleGame
{
    public class LangFunctionSet : LangSet
    {
        public LangSet Domain { get; private set; }
        public LangSet Range { get; private set; }

        public LangFunctionSet(LangSet domain, LangSet range)
        {
            Domain = domain;
            Range = range;
        }

        public override bool Contains(LangValue value)
        {
            if (value.GetType() != typeof(LangFunction))
            {
                return false;
            }
            LangFunction val = value as LangFunction;
            return false;// val.FindSignature(this) != null;
        }
    }
}
