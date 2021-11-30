using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleGame
{
    public class LangUnionSet : LangSet
    {
        public LangSet Left { get; private set; }
        public LangSet Right { get; private set; }

        public LangUnionSet(LangSet left, LangSet right)
        {
            Left = left;
            Right = right;
        }

        public override bool Contains(LangValue value)
        {
            return Left.Contains(value) || Right.Contains(value);
        }
    }
}
