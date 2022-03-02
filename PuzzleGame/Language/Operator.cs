using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleGame.Language
{
    public class Operator : Node
    {
        public string Name { get; private set; }
        public Node Arg1 { get; private set; }
        public Node Arg2 { get; private set; }
        
        private static Dictionary<string, string> toWords = new Dictionary<string, string>() {
            { "<",  "LessThan" },
            { "<=", "AtMost" },
            { "≤", "AtMost" },
            { ">",  "GreaterThan" },
            { ">=", "AtLeast" },
            { "≥", "AtLeast" },
            { "=",  "Equal" },
            { "!=", "NotEqual" },
            { "≠", "NotEqual" },
            { ".", "And" },

            { "+", "Add" },
            { "-", "Sub" },
            { "*", "Mul" },
            { "×", "Mul" },
            { "/", "Div" },
            { "^", "Pow" },
            { "√", "Root" },
            { "div","FloorDiv" },
            { "mod", "Mod" },
        };
        private static Dictionary<string, string> toSymbols = new Dictionary<string, string>() {
            { "LessThan", "<" },
            { "AtMost", "≤" },
            { "GreaterThan", ">" },
            { "AtLeast", "≥" },
            { "Equal", "=" },
            { "NotEqual", "≠"},
            { "And", "." },

            { "Add", "+" },
            { "Sub", "-" },
            { "Mul", "×" },
            { "Div", "/" },
            { "Pow", "^" },
            { "Root", "√" },
            { "FloorDiv", "div" },
            { "Mod", "mod" },
        };

        private Dictionary<Tuple<string, Type, Type>, Type> OpData = new Dictionary<Tuple<string, Type, Type>, Type>()
        {

            {Tuple.Create(".", typeof(bool), typeof(bool)), typeof(bool) },

            {Tuple.Create("Add", typeof(Number), typeof(Number)), typeof(Number) },
            {Tuple.Create("Sub", typeof(Number), typeof(Number)), typeof(Number) },
            {Tuple.Create("Mul", typeof(Number), typeof(Number)), typeof(Number) },
            {Tuple.Create("Div", typeof(Number), typeof(Number)), typeof(Number) },
            {Tuple.Create("FloorDiv",typeof(Number), typeof(Number)), typeof(Number) },
            {Tuple.Create("Mod", typeof(Number), typeof(Number)), typeof(Number) },
            {Tuple.Create("Root", typeof(Number), typeof(Number)), typeof(Number) },
            {Tuple.Create("Pow", typeof(Number), typeof(Number)), typeof(Number) },
            {Tuple.Create("Mul", typeof(Number), typeof(Vector)), typeof(Vector) },
            {Tuple.Create("Mul", typeof(Vector), typeof(Number)), typeof(Vector) },
            {Tuple.Create("Div", typeof(Vector), typeof(Number)), typeof(Vector) },

            {Tuple.Create("Add", typeof(Multival<Number>), typeof(Number)), typeof(Multival<Number>) },
            {Tuple.Create("Sub", typeof(Multival<Number>), typeof(Number)), typeof(Multival<Number>) },
            {Tuple.Create("Mul", typeof(Multival<Number>), typeof(Number)), typeof(Multival<Number>) },
            {Tuple.Create("Div", typeof(Multival<Number>), typeof(Number)), typeof(Multival<Number>) },
            {Tuple.Create("FloorDiv",typeof(Multival<Number>), typeof(Number)), typeof(Multival<Number>) },
            {Tuple.Create("Mod", typeof(Multival<Number>), typeof(Number)), typeof(Multival<Number>) },
            {Tuple.Create("Pow", typeof(Multival<Number>), typeof(Number)), typeof(Multival<Number>) },
            {Tuple.Create("Root", typeof(Multival<Number>), typeof(Number)), typeof(Multival<Number>) },
            {Tuple.Create("Mul", typeof(Multival<Number>), typeof(Vector)), typeof(Multival<Vector>) },
            {Tuple.Create("Mul", typeof(Multival<Vector>), typeof(Number)), typeof(Multival<Vector>) },
            {Tuple.Create("Div", typeof(Multival<Vector>), typeof(Number)), typeof(Multival<Vector>) },

            {Tuple.Create("Add", typeof(Number), typeof(Multival<Number>)), typeof(Multival<Number>) },
            {Tuple.Create("Sub", typeof(Number), typeof(Multival<Number>)), typeof(Multival<Number>) },
            {Tuple.Create("Mul", typeof(Number), typeof(Multival<Number>)), typeof(Multival<Number>) },
            {Tuple.Create("Div", typeof(Number), typeof(Multival<Number>)), typeof(Multival<Number>) },
            {Tuple.Create("FloorDiv",typeof(Number), typeof(Multival<Number>)), typeof(Multival<Number>) },
            {Tuple.Create("Mod", typeof(Number), typeof(Multival<Number>)), typeof(Multival<Number>) },
            {Tuple.Create("Pow", typeof(Number), typeof(Multival<Number>)), typeof(Multival<Number>) },
            {Tuple.Create("Root", typeof(Number), typeof(Multival<Number>)), typeof(Multival<Number>) },
            {Tuple.Create("Mul", typeof(Number), typeof(Multival<Vector>)), typeof(Multival<Vector>) },
            {Tuple.Create("Mul", typeof(Vector), typeof(Multival<Number>)), typeof(Multival<Vector>) },
            {Tuple.Create("Div", typeof(Vector), typeof(Multival<Number>)), typeof(Multival<Vector>) },

            {Tuple.Create("Equal",  typeof(Vector), typeof(Vector)), typeof(bool) },
            {Tuple.Create("NotEqual", typeof(Vector), typeof(Vector)), typeof(bool) },
            {Tuple.Create("Equal",  typeof(Number), typeof(Number)), typeof(bool) },
            {Tuple.Create("NotEqual", typeof(Number), typeof(Number)), typeof(bool) },
            {Tuple.Create("LessThan",  typeof(Number), typeof(Number)), typeof(bool) },
            {Tuple.Create("AtMost", typeof(Number), typeof(Number)), typeof(bool) },
            {Tuple.Create("GreaterThan",  typeof(Number), typeof(Number)), typeof(bool) },
            {Tuple.Create("AtLeast", typeof(Number), typeof(Number)), typeof(bool) },

            {Tuple.Create("Equal",  typeof(Multival<Vector>), typeof(Multival<Vector>)), typeof(bool) },
            {Tuple.Create("NotEqual", typeof(Multival<Vector>), typeof(Multival<Vector>)), typeof(bool) },
            {Tuple.Create("Equal",  typeof(Multival<Number>), typeof(Multival<Number>)), typeof(bool) },
            {Tuple.Create("NotEqual", typeof(Multival<Number>), typeof(Multival<Number>)), typeof(bool) },
            {Tuple.Create("LessThan",  typeof(Multival<Number>), typeof(Multival<Number>)), typeof(bool) },
            {Tuple.Create("AtMost", typeof(Multival<Number>), typeof(Multival<Number>)), typeof(bool) },
            {Tuple.Create("GreaterThan",  typeof(Multival<Number>), typeof(Multival<Number>)), typeof(bool) },
            {Tuple.Create("AtLeast", typeof(Multival<Number>), typeof(Multival<Number>)), typeof(bool) },

            {Tuple.Create("Equal",  typeof(Vector), typeof(Multival<Vector>)), typeof(bool) },
            {Tuple.Create("NotEqual", typeof(Vector), typeof(Multival<Vector>)), typeof(bool) },
            {Tuple.Create("Equal",  typeof(Number), typeof(Multival<Number>)), typeof(bool) },
            {Tuple.Create("NotEqual", typeof(Number), typeof(Multival<Number>)), typeof(bool) },
            {Tuple.Create("LessThan",  typeof(Number), typeof(Multival<Number>)), typeof(bool) },
            {Tuple.Create("AtMost", typeof(Number), typeof(Multival<Number>)), typeof(bool) },
            {Tuple.Create("GreaterThan",  typeof(Number), typeof(Multival<Number>)), typeof(bool) },
            {Tuple.Create("AtLeast", typeof(Number), typeof(Multival<Number>)), typeof(bool) },

            {Tuple.Create("Equal",  typeof(Multival<Vector>), typeof(Vector)), typeof(bool) },
            {Tuple.Create("NotEqual", typeof(Multival<Vector>), typeof(Vector)), typeof(bool) },
            {Tuple.Create("Equal",  typeof(Multival<Number>), typeof(Number)), typeof(bool) },
            {Tuple.Create("NotEqual", typeof(Multival<Number>), typeof(Number)), typeof(bool) },
            {Tuple.Create("LessThan",  typeof(Multival<Number>), typeof(Number)), typeof(bool) },
            {Tuple.Create("AtMost", typeof(Multival<Number>), typeof(Number)), typeof(bool) },
            {Tuple.Create("GreaterThan",  typeof(Multival<Number>), typeof(Number)), typeof(bool) },
            {Tuple.Create("AtLeast", typeof(Multival<Number>), typeof(Number)), typeof(bool) },
        };

        public Operator(string op, Node arg1, Node arg2, Token token)
        {
            try
            {
                Name = toWords[op];
                Arg1 = arg1;
                Arg2 = arg2;
                Token = token;
            }
            catch
            {
                throw new Exception("Unsupported operator " + op + ".");
            }
        }

        public override Type EvaluateType()
        {
            Type t1 = Arg1.EvaluateType();
            Type t2 = Arg2.EvaluateType();
            try
            {
                return OpData[Tuple.Create(Name, t1, t2)];
            }
            catch
            {
                throw new Language.Exception(("Wrong types. " + t1.ToShortString() + Name + t2.ToShortString() + " not supported."));
            }
        }
        public object EvaluateValVal<T1, T2>(string opname, T1 a, T2 b)
        {
            if (opname == "And")
                return (bool)typeof(MultivalExtensions).GetMethod("Id").Invoke(null, new object[] { a })
                 && (bool)typeof(MultivalExtensions).GetMethod("Id").Invoke(null, new object[] { b });
            var op = typeof(T1).GetMethod(opname, new Type[] { typeof(T2) });
            return op.Invoke(a, new object[] { b });
        }


        public bool EvaluateMultivaMultival<T1, T2>(string opname, Multival<T1> a, Multival<T2> b)
        {
            int target1 = a.Cardinal.IsEach ? a.Values.Count() : a.Cardinal.Amount;
            bool exact1 = a.Cardinal.IsExact;
            int sofar1 = 0;
            var op = typeof(T1).GetMethod(opname, new Type[] { typeof(T2) });
            foreach (string key1 in a.Values.Keys)
            {
                int target2 = b.Cardinal.IsEach ? (b.Values.Count() - (b.Cardinal.IsOther ? -1 : 0)) : b.Cardinal.Amount;
                bool exact2 = b.Cardinal.IsExact;
                int sofar2 = 0;
                foreach (string key2 in b.Values.Keys)
                {
                    if (b.Cardinal.IsOther && key1 == key2) continue;
                    if ((bool)op.Invoke(a.Values[key1], new object[] { b.Values[key2] }))
                    {
                        sofar2++;
                    }
                    if (sofar2 > target2) break;
                }
                if (exact2)
                {
                    if (sofar2 == target2) sofar1++;
                }
                else
                {
                    if (sofar2 >= target2) sofar1++;
                }
                if (sofar1 > target1) break;
            }
            if (exact1)
            {
                return sofar1 == target1;
            }
            else
            {
                return sofar1 >= target1;
            }
        }

        public object EvaluateMultivalVal<T1, T2>(string opname, Multival<T1> a, T2 b)
        {
            var op = typeof(T1).GetMethod(opname, new Type[] { typeof(T2) });
            var result = a.Map(i => op.Invoke(i, new object[] { b }));
            return result.ReduceIfBool();
        }

        public object EvaluateValMultival <T1, T2>(string opname, T1 b, Multival<T2> a)
        {
            var op = typeof(T1).GetMethod(opname, new Type[] { typeof(T2) });
            var result = a.Map(i => op.Invoke(b, new object[] { i }));
            return result.ReduceIfBool();
        }

        public override object Evaluate(GridState state)
        {
            Type t1 = Arg1.EvaluateType();
            Type t2 = Arg2.EvaluateType();
            bool multi1 = t1.IsGenericType;
            bool multi2 = t2.IsGenericType;
            if (multi1)
            {
                t1 = t1.GetGenericArguments()[0];
            }
            if (multi2)
            {
                t2 = t2.GetGenericArguments()[0];
            }
            string methodName = "EvaluateValVal";
            if (multi1 && multi2)
            {
                methodName = "EvaluateMultivalMultival";
            }
            else if (multi1)
            {
                methodName = "EvaluateMultivalVal";
            }
            else if (multi2)
            {
                methodName = "EvaluateValMultival";
            }
            var method = this.GetType().GetMethod(methodName).MakeGenericMethod(t1, t2);
            return method
                .Invoke(this, new object[] { Name, Arg1.Evaluate(state), Arg2.Evaluate(state) });
        }

        public override string ToString() => "Op(" + Name + ", " + Arg1 + ", " + Arg2 + ")";

        public override string ToCode()
        {
            string op = toSymbols[Name];
            string arg1 = Arg1.ToCode();
            string arg2 = Arg2.ToCode();
            if (op == ".")
            {
                return arg1 + ". " + arg2.FirstLetterToUpper();
            }
            if (op == "-" && arg1 == "0")
            {
                return "-" + arg2;
            }
            if (op == "√" && arg1 == "2")
            {
                return "√" + arg2;
            }
            if (op == "^" && arg2 == "0.5")
            {
                return "√" + arg1;
            }
            if ("√^".Contains(op))
                return arg1 + op + arg2;
            return arg1 + " " + op + " " + arg2;
        }

        public override bool ContainsQuery(string name, bool include)
        {
            return Arg1.ContainsQuery(name, include) || Arg2.ContainsQuery(name, include);
        }
    }
}
