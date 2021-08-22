using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleGame
{
    public class LangNumber : LangValue
    {
        public int Numerator { get; private set; }
        public int Denominator { get; private set; }

        public LangNumber(int numerator, int denominator)
        {
            Numerator = numerator;
            Denominator = denominator;
        }

        public LangNumber(string val)
        {
            var parts = val.Split('.');
            Numerator = int.Parse(val.Replace(".", ""));
            Denominator = 1;
            if (parts.Length != 1)
            {
                Denominator = (int)Math.Pow(10, parts[1].Length);
            }
            Simplify();
        }

        public void Simplify()
        {
            int gcd = GCD(Numerator, Denominator);
            Numerator /= gcd;
            Denominator /= gcd;
        }

        public bool IsIntegral() => Denominator == 1;
        public bool IsPositive() => Numerator > 0;
        public bool IsNegative() => Numerator < 0;
        public bool IsNonpositive() => Numerator >= 0;
        public bool IsNonnegative() => Numerator >= 0;

        public static LangNumber operator +(LangNumber a) => a;
        public static LangNumber operator -(LangNumber a) => new LangNumber(-a.Numerator, a.Denominator);
        public static LangNumber operator +(LangNumber a, LangNumber b)
        {
            var res = new LangNumber(a.Numerator * b.Denominator + b.Numerator * a.Denominator, a.Denominator * b.Denominator);
            res.Simplify();
            return res;
        }
        public static LangNumber operator -(LangNumber a, LangNumber b) => a + (-b);
        public static LangNumber operator *(LangNumber a, LangNumber b)
        {
            var res = new LangNumber(a.Numerator * b.Numerator, a.Denominator * b.Denominator);
            res.Simplify();
            return res;
        }
        public static LangNumber operator /(LangNumber a, LangNumber b)
        {
            if (b.Numerator == 0)
            {
                throw new DivideByZeroException();
            }
            var res = new LangNumber(a.Numerator * b.Denominator, a.Denominator * b.Numerator);
            res.Simplify();
            return res;
        }

        public static bool operator ==(LangNumber a, LangNumber b)
        => a.Numerator * b.Denominator == a.Denominator * b.Numerator;

        public static bool operator !=(LangNumber a, LangNumber b)
        => !(a == b);

        public static bool operator <(LangNumber a, LangNumber b)
        => a.Numerator * b.Denominator < a.Denominator * b.Numerator;

        public static bool operator <=(LangNumber a, LangNumber b)
        => a.Numerator * b.Denominator <= a.Denominator * b.Numerator;

        public static bool operator >(LangNumber a, LangNumber b)
        => a.Numerator * b.Denominator > a.Denominator * b.Numerator;

        public static bool operator >=(LangNumber a, LangNumber b)
        => a.Numerator * b.Denominator >= a.Denominator * b.Numerator;

        public LangNumber Div(LangNumber right)
        {
            LangNumber q = this / right;
            return new LangNumber(q.Numerator / q.Denominator, 1);
        }

        public static LangNumber operator %(LangNumber a, LangNumber b) => a - a.Div(b) * b;


        public override string ToString()
        {
            if(Denominator == 1)
            {
                return Numerator.ToString();
            }
            int rest = Denominator;
            int v2 = 0;
            while(rest % 2 == 0)
            {
                rest /= 2;
                v2 += 1;

            }
            int v5 = 0;
            while (rest % 5 == 0)
            {
                rest /= 5;
                v5 += 1;

            }
            if (rest == 1)
            {
                int b = (int)Math.Pow(10, Math.Max(v2, v5));
                int num = Numerator * (b / Denominator);
                return $"{num / b}.{num % b}";
            }
            return $"{Numerator}/{Denominator}";
        }

        public int GCD(int a, int b)
        {
            while (a != 0 && b != 0)
            {
                if (a > b)
                    a %= b;
                else
                    b %= a;
            }

            return a | b;
        }

        public LangBool opEquals(LangNumber right) => new LangBool(this == right);
        public LangBool opNotEquals(LangNumber right) => new LangBool(this != right);
        public LangBool opGreaterThan(LangNumber right) => new LangBool(this > right);
        public LangBool opAtLeast(LangNumber right) => new LangBool(this >= right);
        public LangBool opLessThan(LangNumber right) => new LangBool(this < right);
        public LangBool opAtMost(LangNumber right) => new LangBool(this <= right);

        public LangNumber opPlus(LangNumber right) => this + right;
        public LangNumber opMinus(LangNumber right) => this - right;
        public LangNumber opUnPlus() => this;
        public LangNumber opUnMinus() => -this;
        public LangNumber opTimes(LangNumber right) => this* right;
        public LangNumber opDivide(LangNumber right) {
            try
            {
                return this / right;
            }
            catch(DivideByZeroException)
            {
                throw new ExecutionException("Cannot divide by zero");
            }
        }

        public LangNumber opDiv(LangNumber right) => this.Div(right);
        public LangNumber opMod(LangNumber right) => this % right;

        public LangNumber opPow(LangNumber bas)
        {
            if (IsIntegral())
            {
                var exp = this;
                if (exp.IsNegative())
                {
                    bas = new LangNumber(1,1) / bas;
                    exp = -exp;
                }
                if(exp.Numerator > 1000)
                {
                    throw new ExecutionException($"Exponent {ToString()} is too large.");
                }
                var res = new LangNumber(1,1);
                for(int i = 0; i < exp.Numerator; i++)
                {
                    res *= bas;
                }
                return res;
            }
            throw new ExecutionException($"Cannot raise to a nonintegral power {ToString()}.");
        }

        public LangValue revopCall(LangTuple left)
        {
            if(IsIntegral() && IsNonnegative())
            {
                try
                {
                    return left.Values[Numerator];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new ExecutionException($"Index {ToString()} is out of range.");
                }
            }
            throw new ExecutionException("Only natural numbers can be used as indeces.");
        }

        public LangValue revopCall(LangList left)
        {
            if (IsIntegral() && IsNonnegative())
            {
                try
                {
                    return left.Values[Numerator];
                }
                catch (ArgumentOutOfRangeException)
                {
                    throw new ExecutionException($"Index {ToString()} is out of range.");
                }
            }
            throw new ExecutionException("Only natural numbers can be used as indeces.");
        }

        public LangList opDots(LangNumber right)
        {
            if (IsIntegral() && right.IsIntegral() && this <= right)
            {
                int a = Numerator;
                int b = right.Numerator;
                List<LangValue> values = Enumerable.Range(a, b - a + 1).Select(i => new LangNumber(i, 1)).ToList<LangValue>();
                return new LangList(values);
            }
            throw new ExecutionException("Range operands must be integral and in order");
        }

        public LangList opDotsLess(LangNumber right)
        {
            return opDots(right - new LangNumber(1, 1));
        }

    }
}
