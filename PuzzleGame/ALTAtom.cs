using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleGame
{
    public class ALTAtom : ALTNode
    {
        public LexToken LexToken { get; set; }
        public ALTAtom(LexToken token)
        {
            LexToken = token;
        }

        public override string ToString()
        {
            return LexToken.ToString();
        }
    }
}
