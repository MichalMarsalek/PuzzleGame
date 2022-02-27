using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleGame.Language
{
    public class Number
    {
        public double Value { get; private set; }
        public Number(double value)
        {
            Value = value;
        }

        public Number Add(Number other) => new Number(Value + other.Value);

        public override string ToString() => Value.ToString();
    }
}
