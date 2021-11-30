using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleGame
{
    public enum OperatorArity { Postfix, Prefix, Infix, Ternary, Group }
    public enum OperatorAssociativity { Left, Right, Chain, None, Forbidden }

    public class OperatorPrototype
    {
        public string Name { get; private set; }
        public int Precedence { get; private set; }
        public OperatorArity Arity { get; private set; }
        public OperatorAssociativity Associativity { get; private set; }
        public bool Overwritable { get; private set; }
        public bool Extendable { get; private set; }
        public bool AcceptsSpaces { get; private set; }

        public OperatorPrototype(string name, int precedence, OperatorArity arity, OperatorAssociativity associativity, bool overwritable = true, bool extendable = true, bool spaces = false)
        {
            Name = name;
            Precedence = precedence;
            Arity = arity;
            Associativity = associativity;
            Overwritable = overwritable;
            Extendable = extendable;
            AcceptsSpaces = spaces;
        }
    }
}
