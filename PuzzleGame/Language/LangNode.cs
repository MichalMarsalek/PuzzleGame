using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleGame.Language
{
    public abstract class LangNode
    {
        public abstract object Evaluate();
        public abstract Type EvaluateType();
    }

    
}
