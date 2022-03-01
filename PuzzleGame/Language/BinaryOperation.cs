﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleGame.Language
{
    public class BinaryOperation : Node
    {
        public string Operator { get; private set; }
        public Node Arg1 { get; private set; }
        public Node Arg2 { get; private set; }
        
        private Dictionary<string, string> OperatorMethods = new Dictionary<string, string>() {
            { "<",  "LessThan" },
            { "<=", "AtMost" },
            { ">",  "GreaterThan" },
            { ">=", "AtLeast" },
            { "=",  "Equal" },
            { "!=", "NotEqual" },
            { ".", "And" },

            { "+", "Add" },
            { "-", "Sub" },
            { "*", "Mul" },
            { "/", "Div" },
            { "div","FloorDiv" },
            { "mod", "Mod" },
        };

        private Dictionary<Tuple<string, Type, Type>, Type> OpData = new Dictionary<Tuple<string, Type, Type>, Type>()
        {

            {Tuple.Create(".", typeof(bool), typeof(bool)), typeof(bool) },

            {Tuple.Create("+", typeof(Number), typeof(Number)), typeof(Number) },
            {Tuple.Create("-", typeof(Number), typeof(Number)), typeof(Number) },
            {Tuple.Create("*", typeof(Number), typeof(Number)), typeof(Number) },
            {Tuple.Create("/", typeof(Number), typeof(Number)), typeof(Number) },
            {Tuple.Create("//",typeof(Number), typeof(Number)), typeof(Number) },
            {Tuple.Create("%", typeof(Number), typeof(Number)), typeof(Number) },
            {Tuple.Create("*", typeof(Number), typeof(Vector)), typeof(Vector) },
            {Tuple.Create("*", typeof(Vector), typeof(Number)), typeof(Vector) },
            {Tuple.Create("/", typeof(Vector), typeof(Number)), typeof(Vector) },

            {Tuple.Create("+", typeof(Multival<Number>), typeof(Number)), typeof(Multival<Number>) },
            {Tuple.Create("-", typeof(Multival<Number>), typeof(Number)), typeof(Multival<Number>) },
            {Tuple.Create("*", typeof(Multival<Number>), typeof(Number)), typeof(Multival<Number>) },
            {Tuple.Create("/", typeof(Multival<Number>), typeof(Number)), typeof(Multival<Number>) },
            {Tuple.Create("//",typeof(Multival<Number>), typeof(Number)), typeof(Multival<Number>) },
            {Tuple.Create("%", typeof(Multival<Number>), typeof(Number)), typeof(Multival<Number>) },
            {Tuple.Create("*", typeof(Multival<Number>), typeof(Vector)), typeof(Multival<Vector>) },
            {Tuple.Create("*", typeof(Multival<Vector>), typeof(Number)), typeof(Multival<Vector>) },
            {Tuple.Create("/", typeof(Multival<Vector>), typeof(Number)), typeof(Multival<Vector>) },

            {Tuple.Create("+", typeof(Number), typeof(Multival<Number>)), typeof(Multival<Number>) },
            {Tuple.Create("-", typeof(Number), typeof(Multival<Number>)), typeof(Multival<Number>) },
            {Tuple.Create("*", typeof(Number), typeof(Multival<Number>)), typeof(Multival<Number>) },
            {Tuple.Create("/", typeof(Number), typeof(Multival<Number>)), typeof(Multival<Number>) },
            {Tuple.Create("//",typeof(Number), typeof(Multival<Number>)), typeof(Multival<Number>) },
            {Tuple.Create("%", typeof(Number), typeof(Multival<Number>)), typeof(Multival<Number>) },
            {Tuple.Create("*", typeof(Number), typeof(Multival<Vector>)), typeof(Multival<Vector>) },
            {Tuple.Create("*", typeof(Vector), typeof(Multival<Number>)), typeof(Multival<Vector>) },
            {Tuple.Create("/", typeof(Vector), typeof(Multival<Number>)), typeof(Multival<Vector>) },

            {Tuple.Create("=",  typeof(Vector), typeof(Vector)), typeof(bool) },
            {Tuple.Create("!=", typeof(Vector), typeof(Vector)), typeof(bool) },
            {Tuple.Create("=",  typeof(Number), typeof(Number)), typeof(bool) },
            {Tuple.Create("!=", typeof(Number), typeof(Number)), typeof(bool) },
            {Tuple.Create("<",  typeof(Number), typeof(Number)), typeof(bool) },
            {Tuple.Create("<=", typeof(Number), typeof(Number)), typeof(bool) },
            {Tuple.Create(">",  typeof(Number), typeof(Number)), typeof(bool) },
            {Tuple.Create(">=", typeof(Number), typeof(Number)), typeof(bool) },

            {Tuple.Create("=",  typeof(Multival<Vector>), typeof(Multival<Vector>)), typeof(bool) },
            {Tuple.Create("!=", typeof(Multival<Vector>), typeof(Multival<Vector>)), typeof(bool) },
            {Tuple.Create("=",  typeof(Multival<Number>), typeof(Multival<Number>)), typeof(bool) },
            {Tuple.Create("!=", typeof(Multival<Number>), typeof(Multival<Number>)), typeof(bool) },
            {Tuple.Create("<",  typeof(Multival<Number>), typeof(Multival<Number>)), typeof(bool) },
            {Tuple.Create("<=", typeof(Multival<Number>), typeof(Multival<Number>)), typeof(bool) },
            {Tuple.Create(">",  typeof(Multival<Number>), typeof(Multival<Number>)), typeof(bool) },
            {Tuple.Create(">=", typeof(Multival<Number>), typeof(Multival<Number>)), typeof(bool) },

            {Tuple.Create("=",  typeof(Vector), typeof(Multival<Vector>)), typeof(bool) },
            {Tuple.Create("!=", typeof(Vector), typeof(Multival<Vector>)), typeof(bool) },
            {Tuple.Create("=",  typeof(Number), typeof(Multival<Number>)), typeof(bool) },
            {Tuple.Create("!=", typeof(Number), typeof(Multival<Number>)), typeof(bool) },
            {Tuple.Create("<",  typeof(Number), typeof(Multival<Number>)), typeof(bool) },
            {Tuple.Create("<=", typeof(Number), typeof(Multival<Number>)), typeof(bool) },
            {Tuple.Create(">",  typeof(Number), typeof(Multival<Number>)), typeof(bool) },
            {Tuple.Create(">=", typeof(Number), typeof(Multival<Number>)), typeof(bool) },

            {Tuple.Create("=",  typeof(Multival<Vector>), typeof(Vector)), typeof(bool) },
            {Tuple.Create("!=", typeof(Multival<Vector>), typeof(Vector)), typeof(bool) },
            {Tuple.Create("=",  typeof(Multival<Number>), typeof(Number)), typeof(bool) },
            {Tuple.Create("!=", typeof(Multival<Number>), typeof(Number)), typeof(bool) },
            {Tuple.Create("<",  typeof(Multival<Number>), typeof(Number)), typeof(bool) },
            {Tuple.Create("<=", typeof(Multival<Number>), typeof(Number)), typeof(bool) },
            {Tuple.Create(">",  typeof(Multival<Number>), typeof(Number)), typeof(bool) },
            {Tuple.Create(">=", typeof(Multival<Number>), typeof(Number)), typeof(bool) },
        };

        public BinaryOperation(string op, Node arg1, Node arg2, Token token)
        {
            Operator = op;
            Arg1 = arg1;
            Arg2 = arg2;
            Token = token;
        }

        public override Type EvaluateType()
        {
            Type t1 = Arg1.EvaluateType();
            Type t2 = Arg2.EvaluateType();
            try
            {
                return OpData[Tuple.Create(Operator, t1, t2)];
            }
            catch
            {
                throw new Language.Exception(("Wrong types. " + t1.ToShortString() + Operator + t2.ToShortString() + " not supported."));
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
                .Invoke(this, new object[] { OperatorMethods[Operator], Arg1.Evaluate(state), Arg2.Evaluate(state) });
        }

        public override string ToString() => "Op(" + Operator + ", " + Arg1 + ", " + Arg2 + ")";

        public override string ToCode()
        {
            if(Operator == ".")
            {
                return Arg1.ToCode() + ". " + Arg2.ToCode().FirstLetterToUpper();
            }
            if (Operator == "-" && Arg1.ToCode() == "0")
            {
                return "-" + Arg2.ToCode();
            }
            return Arg1.ToCode() + " " + Operator + " " + Arg2.ToCode();
        }

        public override bool ContainsQuery(string name, bool include)
        {
            return Arg1.ContainsQuery(name, include) || Arg2.ContainsQuery(name, include);
        }
    }
}
