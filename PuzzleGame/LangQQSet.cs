using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleGame
{
    class LangQQSet : LangSet
    {
        public override bool Contains(LangValue value)
        {
            return value.GetType() == typeof(LangNumber);
        }
    }
}
