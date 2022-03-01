using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleGame.Language
{
    public class Number
    {
        const double prec = 1e-10;
        public double Value { get; private set; }
        public Number(double value)
        {
            Value = value;
        }
        public Number(float value)
        {
            Value = (double)value;
        }
        public Number(string value)
        {
            Value = double.Parse(value);
        }

        public Number Add(Number other) => new Number(Value + other.Value);
        public Number Sub(Number other) => new Number(Value - other.Value);
        public Number Mul(Number other) => new Number(Value * other.Value);
        public Number Div(Number other) => new Number(Value / other.Value);
        public Number Mod(Number other) => new Number(Value % other.Value);
        public Number FloorDiv(Number other) => new Number((Value - Value % other.Value) / other.Value);

        public bool Equal(Number other) => Math.Abs(Value - other.Value) < prec;
        public bool NotEqual(Number other) => !Equal(other);
        public bool LessThan(Number other) => Value < other.Value;
        public bool AtMost(Number other) => Equal(other) || LessThan(other);
        public bool GreaterThan(Number other) => Value > other.Value;
        public bool AtLeast(Number other) => Equal(other) || GreaterThan(other);

        public override string ToString() => Value.ToString();

        public bool IsInteger
        {
            get => Math.Abs(Value - Math.Round(Value)) < prec;
        }

        public bool IsEven
        {
            get => IsInteger && (int)Value % 2 == 0;
        }
        public bool IsOdd
        {
            get => IsInteger && !IsEven;
        }

        public bool IsPrime
        {
            get
            {
                if (this.Equal(new Number(2))) return true;
                if (!IsInteger || Value > 1000000) return false;
                int a = (int)Value;
                for(int i=3; i < 1000; i+=2)
                {
                    if (a % i == 0) return false;
                }
                return true;
            }
        }
    }
}
