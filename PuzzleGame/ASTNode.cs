using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleGame
{
    public abstract class ASTNode
    {
        public abstract LangValue Evaluate(NameDomain domain);

        public ALTGroup Group { get; set; }

        public abstract string ToString(int offset);

        public bool IsNameLeaf()
        {
            return this is ASTLeaf && (this as ASTLeaf).Value.Type == "Name";
        }

        internal bool IsSingleCall()
        {
            if (!(this is ASTOperations))
                return false;
            var op = this as ASTOperations;
            return op.Operands.Count == 2 && op.Operators[1] == ".";
        }
    }
}
