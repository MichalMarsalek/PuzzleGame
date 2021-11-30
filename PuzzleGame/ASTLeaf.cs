using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleGame
{
    public class ASTLeaf : ASTNode
    {
        public LexToken Value { get; private set; }

        public ASTLeaf(LexToken token)
        {
            Value = token;
        }

        public override LangValue Evaluate(NameDomain domain)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return Value.ToShortString();
        }

        public override string ToString(int offset)
        {
            return new String(' ', 4 * offset) + Value.ToShortString();
        }
    }
}
