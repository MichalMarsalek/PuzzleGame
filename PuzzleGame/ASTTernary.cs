using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleGame
{
    public class ASTTernary : ASTNode
    {
        public ASTNode Arg1 { get; private set; }
        public ASTNode Arg2 { get; private set; }
        public ASTNode Arg3 { get; private set; }
        public string Op { get; private set; }

        public ASTTernary(LexToken token, ASTNode arg1, ASTNode arg2, ASTNode arg3, string op)
        {
            Token = token;
            if ((arg1.IsSpaceLeaf() || arg2.IsSpaceLeaf() || arg3.IsSpaceLeaf()) && !Operators.GetPrototype(op).AcceptsSpaces)
            {
                throw new ParsingException(Token, $"Operator {op} does not accept empty arguments."); //TODO token, position
            }
            Arg1 = arg1;
            Arg2 = arg2;
            Arg3 = arg3;
            Op = op;
        }

        public override LangValue Evaluate(NameDomain domain)
        {
            throw new NotImplementedException();
        }

        public override string ToString() => ToString(0);

        public override string ToString(int offset)
        {
            string op1 = Operators.GetPrototype(Op).Name.Split(' ')[0];
            string op2 = Operators.GetPrototype(Op).Name.Split(' ')[1];
            if ((Arg1.ToString() + Arg2.ToString() + Arg3.ToString()).Length < 50)
            {
                string result = new String(' ', 4 * offset) + "(";
                return result + Arg1.ToString() + " " + op1 + " " + Arg2.ToString() + " " + op2 + " " + Arg3.ToString() + ")";
            }
            else
            {
                string result = new String(' ', 4 * offset) + "(\n";
                result += Arg1.ToString(offset + 1) + "\n" + new String(' ', 4 * offset + 4) + op1 + "\n" + Arg2.ToString(offset + 1);
                result +=  "\n" + new String(' ', 4 * offset + 4) + op2 + "\n" + Arg3.ToString(offset + 1);
                return result + "\n" + new String(' ', 4 * offset) + ")";
            }
        }
    }
}
