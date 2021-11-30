using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleGame
{
    public class ASTBinary : ASTNode
    {
        public ASTNode Arg1 { get; private set; }
        public ASTNode Arg2 { get; private set; }
        public string Op { get; private set; }

        public ASTBinary(LexToken token, ASTNode arg1, ASTNode arg2, string op)
        {
            Token = token;
            if ((arg1.IsSpaceLeaf() || arg2.IsSpaceLeaf()) && !Operators.GetPrototype(op).AcceptsSpaces)
            {
                throw new ParsingException(Token, $"Operator {op} does not accept empty arguments."); //TODO token, position
            }
            Arg1 = arg1;
            Arg2 = arg2;
            Op = op;
        }

        public override LangValue Evaluate(NameDomain domain)
        {
            throw new NotImplementedException();
        }

        public override string ToString() => ToString(0);

        public override string ToString(int offset)
        {
            if ((Arg1.ToString() + Arg2.ToString()).Length < 50)
            {
                string result = new String(' ', 4 * offset) + "(";
                return result + Arg1.ToString() + " " + Op + " " + Arg2.ToString() + ")";
            }
            else
            {
                string result = new String(' ', 4 * offset) + "(\n";
                result += Arg1.ToString(offset+1) + "\n" + new String(' ', 4 * offset + 4) + Op + "\n" + Arg2.ToString(offset+1);
                return result + "\n" + new String(' ', 4 * offset) + ")";
            }
        }
    }
}
