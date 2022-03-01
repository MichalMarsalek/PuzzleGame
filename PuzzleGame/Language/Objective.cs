using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleGame.Language
{
    public class Objective
    {
        public List<Node> Rules {get; private set;}

        public Objective(List<Node> rules)
        {
            Rules = rules;
        }

        public List<Type> EvaluateTypes() => Rules.Select(i => i.EvaluateType()).ToList();
        public List<object> EvaluateValues(GridState state) => Rules.Select(i => i.Evaluate(state)).ToList();

        public string ToCode()
        {
            return String.Join("\r\n", Rules.Select(i => i.ToCode().FirstLetterToUpper() + "."));
        }
    }
}
