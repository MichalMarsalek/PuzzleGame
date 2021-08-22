using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleGame
{
    public abstract class LangValue
    {
        public LangTuple opComma(LangValue left)
        {
            LangValue right = this;
            if (!(left is LangTuple))
            {
                left = new LangTuple(left);
            }
            if (!(right is LangTuple))
            {
                right = new LangTuple(right);
            }
            return new LangTuple((left as LangTuple).Values.Concat((right as LangTuple).Values).ToList());
        }
    }
}
