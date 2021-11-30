using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleGame
{
    public class ALTOperator : ALTNode
    {
        public string Operator { get; set; }
        public OperatorPrototype Prototype { get; set; }
        public ALTGroup Data { get; set; }

        public ALTOperator(LexToken token, string op, ALTGroup data = null)
        {
            Token = token;
            Operator = op;
            Prototype = Operators.GetPrototype(op);
            Data = data;
        }

        public override string ToString()
        {
            return Operator;
        }

        public override ASTNode ToAST()
        {
            throw new NotImplementedException(); //should not go here ever
        }
    }
}
