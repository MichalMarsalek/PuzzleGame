using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleGame
{
    public class ASTUnary : ASTNode
    {
        public ASTNode Arg { get; private set; }
        public string Op { get; private set; }

        public ASTUnary(LexToken token, ASTNode arg, string op)
        {
            Token = token;
            if (arg.IsSpaceLeaf() && !Operators.GetPrototype(op).AcceptsSpaces)
            {
                throw new ParsingException(Token, $"Operator {op} does not accept empty arguments."); //TODO token, position
            }
            Arg = arg;
            Op = op;
        }

        public override LangValue Evaluate(NameDomain domain)
        {
            throw new NotImplementedException();
        }

        public override string ToString() => ToString(0);

        public override string ToString(int offset)
        {
            if (Arg.ToString().Length < 50)
            {
                string result = new String(' ', 4 * offset) + "(";
                return result + Op + " " + Arg.ToString() + ")";
            }
            else
            {
                string result = new String(' ', 4 * offset) + "(\n";
                result += new String(' ', 4 * offset + 4) + Op + "\n" + Arg.ToString(offset + 1);
                return result + "\n" + new String(' ', 4 * offset) + ")";
            }
        }
    }
}
