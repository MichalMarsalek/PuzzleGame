using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleGame
{    
    public static class Operators
    {
        public const int LambdaPrec = 3;

        public static Dictionary<string, OperatorPrototype> Ops = new Dictionary<string, OperatorPrototype>()
        {
            { "§NL§", new OperatorPrototype("NL", -2, OperatorArity.Group,   OperatorAssociativity.None, false, false)},
            { ":",    new OperatorPrototype(":",  -1, OperatorArity.Postfix, OperatorAssociativity.Forbidden, false, false)},
            { "->",   new OperatorPrototype("->", 0, OperatorArity.Infix,   OperatorAssociativity.Forbidden, false, false)},
            { ":=",   new OperatorPrototype(":=", 0, OperatorArity.Infix,   OperatorAssociativity.Forbidden, false, false)},
            { "×",    new OperatorPrototype("×",  1, OperatorArity.Group,   OperatorAssociativity.None, false, false)},
            { ",",    new OperatorPrototype(",",  2, OperatorArity.Group,   OperatorAssociativity.None, false, false, true)},
            { "if",   new OperatorPrototype("if else",  3, OperatorArity.Ternary,   OperatorAssociativity.Right, false, false)},
            { "else", new OperatorPrototype("if else",  3, OperatorArity.Ternary,   OperatorAssociativity.Right, false, false)},
            { "or",   new OperatorPrototype("or",  4, OperatorArity.Infix,   OperatorAssociativity.Left, true, false)},
            { "and",  new OperatorPrototype("and", 5, OperatorArity.Infix,   OperatorAssociativity.Left, true, false)},
            { "not",  new OperatorPrototype("not", 6, OperatorArity.Prefix,  OperatorAssociativity.Left, true, false)},
            { "in",   new OperatorPrototype("in", 7, OperatorArity.Infix,  OperatorAssociativity.Chain, true, false)},
            { "notin",new OperatorPrototype("notin", 7, OperatorArity.Infix,  OperatorAssociativity.Chain, true, false)},
            { "=",    new OperatorPrototype("=", 7, OperatorArity.Infix,  OperatorAssociativity.Chain)},
            { "!=",   new OperatorPrototype("!=", 7, OperatorArity.Infix,  OperatorAssociativity.Chain)},
            { ">",    new OperatorPrototype(">", 7, OperatorArity.Infix,  OperatorAssociativity.Chain)},
            { "<",    new OperatorPrototype("<", 7, OperatorArity.Infix,  OperatorAssociativity.Chain)},
            { "\\",   new OperatorPrototype("\\", 8, OperatorArity.Infix,  OperatorAssociativity.Left)},
            { "&",    new OperatorPrototype("&", 8, OperatorArity.Infix,  OperatorAssociativity.Left)},
            { "|",    new OperatorPrototype("|", 8, OperatorArity.Infix,  OperatorAssociativity.Left)},
            { "+",    new OperatorPrototype("+", 9, OperatorArity.Infix,  OperatorAssociativity.Left)},
            { "-",    new OperatorPrototype("-", 9, OperatorArity.Infix,  OperatorAssociativity.Left)},
            { "..",   new OperatorPrototype("..", 10, OperatorArity.Infix,  OperatorAssociativity.Left)},
            { "--",   new OperatorPrototype("--", 10, OperatorArity.Infix,  OperatorAssociativity.Left)},
            { "@",    new OperatorPrototype("@", 11, OperatorArity.Infix,  OperatorAssociativity.Left)},
            { "*",    new OperatorPrototype("*", 11, OperatorArity.Infix,  OperatorAssociativity.Left)},
            { "/",    new OperatorPrototype("/", 11, OperatorArity.Infix,  OperatorAssociativity.Left)},
            { "div",  new OperatorPrototype("div", 11, OperatorArity.Infix,  OperatorAssociativity.Left, true, false)},
            { "mod",  new OperatorPrototype("mod", 11, OperatorArity.Infix,  OperatorAssociativity.Left, true, false)},
            { "^",    new OperatorPrototype("^", 12, OperatorArity.Infix,  OperatorAssociativity.Right)},
            { "§empty§",  new OperatorPrototype("empty", 13, OperatorArity.Infix,  OperatorAssociativity.Right, false, false)},
            { "u-",    new OperatorPrototype("-", 14, OperatorArity.Prefix,  OperatorAssociativity.None)},
            { ".",    new OperatorPrototype(".", 15, OperatorArity.Infix,  OperatorAssociativity.Left)},
            { "§priorityEmpty§",  new OperatorPrototype("priorityEmpty", 14, OperatorArity.Infix,  OperatorAssociativity.Left)},
            { "#",    new OperatorPrototype("#", 16, OperatorArity.Prefix,  OperatorAssociativity.None)},
            { "°",    new OperatorPrototype("°", 17, OperatorArity.Postfix,  OperatorAssociativity.None)},
            { "%",    new OperatorPrototype("%", 17, OperatorArity.Postfix,  OperatorAssociativity.None)},

        };

        public static OperatorPrototype GetPrototype(string op)
        {
            int maxlen = Math.Min(op.Length, Operators.Ops.Keys.Max(i => i.Length));
            for (int L = maxlen; L > 0; L--)
            {
                if (Operators.Ops.ContainsKey(op.Substring(0, L)))
                {
                    return Operators.Ops[op.Substring(0, L)];
                }
            }
            return null;
        }

        private static int uid = 0;
        public static int UID
        {
            get
            {
                return uid++;
            }
        }
    }
}
