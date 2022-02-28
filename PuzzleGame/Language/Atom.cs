using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleGame.Language
{
    public class Atom : Node
    {
        public object Value { get; private set; }

        public Atom(object value, Token token = null)
        {
            Value = value;
            Token = token;
        }

        public override object Evaluate(GridState state) => Value;

        public override Type EvaluateType() => Value.GetType();
    }
}
