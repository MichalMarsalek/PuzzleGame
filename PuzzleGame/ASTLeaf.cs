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
            if(Value.Type == "Number")
            {
                return new LangNumber(Value.Value);
            }
            if (domain.ContainsKey(Value.Value))
            {
                return domain[Value.Value];
            }
            else
            {
                throw new ExecutionException($"Uknown name {Value.Value}.");
            }
        }

        public override string ToString()
        {
            return Value.Value.ToString();
        }

        public override string ToString(int offset)
        {
            return new String(' ', 4 * offset) + Value.Value.ToString();
        }
    }
}
