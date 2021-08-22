using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleGame
{
    public static class OperatorsData
    {
        private static readonly string[] _opPrecedence = { ":=", "ifelse", "or", "and", "not", "= != > >= < <= in notin", ",", "\\ & |", "+ -", "call", "... ...<", "* / // %", "u- u+", "°", "^ left^", "." }; //TODO if else
        public static readonly List<string> Operators = _opPrecedence.SelectMany(i => i.Split(' ')).ToList();
        public static readonly List<List<string>> _precedence = _opPrecedence.Select(i => i.Split(' ').ToList()).ToList();
        public static readonly Dictionary<string, int> Precedence =
            (from i in Enumerable.Range(0, _precedence.Count())
            from op in _precedence[i]
            select new KeyValuePair<string, int>(op, i)).ToDictionary(i => i.Key, i => i.Value);
        public static readonly List<string> Unary = new List<string> { "u+", "u-"};

        public static readonly Dictionary<string, string> Map = new Dictionary<string, string>()
        {
            { "or", "opOr"},
            { "and", "opAnd"},
            { "=", "opEquals"},
            { "!=", "opNotEquals"},
            { ">", "opGreaterThan"},
            { ">=", "opAtLeast"},
            { "<", "opLessThan"},
            { "<=", "opAtMost"},
            { "in", "opIn"},
            { "notin", "opNotIn"},
            { "\\", "opSetMinus"},
            { "&", "opSetAnd"},
            { "|", "opSetOr"},
            { "+", "opPlus"},
            { "-", "opMinus"},
            { "*", "opTimes"},
            { "/", "opDivide"},
            { "//", "opDiv"},
            { "%", "opMod"},
            { "left^", "opPow"},
            { "u-", "opUnMinus"},
            { "u+", "opUnPlus"},
            { ":=", "opAssign"},
            { ",", "opComma"},
            { ".", "opCall"},
            { "...", "opDots"},
            { "...<", "opDotsLess"},
            { "ifelse", "opIfElse"},
        };

        public static readonly List<string> MagicFunctions = new List<string>() { "all", "allOther", "some", "someOther" };
    }
}
