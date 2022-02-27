using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleGame.Language
{
    public class Atom : LangNode
    {
        public object Value { get; private set; }

        public Atom(object value)
        {
            Value = value;
        }

        public override object Evaluate() => Value;

        public override Type EvaluateType() => Value.GetType();
    }
}
