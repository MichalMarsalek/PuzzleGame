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
        public ALTGroup Data { get; set; }

        public ALTOperator(string op, ALTGroup data =null)
        {
            Operator = op;
            Data = data;
        }

        public bool IsUnary
        {
            get
            {
                return OperatorsData.Unary.Contains(Operator);
            }
        }

        public bool IsTernary
        {
            get
            {
                return Operator == "ifelse";
            }
        }

        public override string ToString()
        {
            return Operator;
        }
    }
}
