using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleGame
{
    public class LangProductSet : LangSet
    {
        public List<LangSet> Factors { get; private set; }

        public override bool Contains(LangValue value)
        {
            if(value.GetType() != typeof(LangTuple))
            {
                return false;
            }
            LangTuple val = value as LangTuple;
            if(val.Values.Count != Factors.Count)
            {
                return false;
            }
            for(int i = 0; i < Factors.Count; i++)
            {
                if (!Factors[i].Contains(val.Values[i]))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
