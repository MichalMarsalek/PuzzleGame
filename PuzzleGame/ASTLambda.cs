using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleGame
{
    public class ASTLambda : ASTNode
    {
        public List<string> Args { get; private set; }
        public ASTNode Value { get; private set; }

        public ASTLambda(LexToken token, List<string> args, ASTNode val)
        {
            Token = token;
            Args = args;
            Value = val;
        }

        public override LangValue Evaluate(NameDomain domain)
        {
            throw new NotImplementedException();
        }

        public override string ToString() => ToString(0);

        public override string ToString(int offset)
        {
            string result = new String(' ', 4 * offset) + "(\n" + new String(' ', 4 * offset + 4);
            result += String.Join(", ", Args.Select(i => i.ToString())) + " --> \n";
            result +=Value.ToString(offset + 1);
            return result + "\n" + new String(' ', 4 * offset) + ")";
        }
    }
}
