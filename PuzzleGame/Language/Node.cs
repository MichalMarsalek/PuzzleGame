using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleGame.Language
{
    public abstract class Node
    {
        public Token Token { get; protected set; }

        public abstract object Evaluate(GridState state);
        public abstract Type EvaluateType();
    }

    
}
