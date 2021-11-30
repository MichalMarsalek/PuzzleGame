using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleGame
{
    public class LangStringsSet : LangSet
    {
        public override bool Contains(LangValue value)
        {
            return value.GetType() == typeof(string);
        }
    }
}
