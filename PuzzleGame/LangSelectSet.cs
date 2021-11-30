using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleGame
{
    public class LangSelectSet : LangSet
    {
        public LangSet Base { get; private set; }
        public LangFunction Condition { get; private set; }
        public NameDomain Context { get; private set; }

        public override bool Contains(LangValue value)
        {
            //Condition.ApplyValue(value);
            //Base.Contains(value) && Condition.FinalEvaluation();
            return false;
        }
    }
}
