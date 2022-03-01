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
        public Node FinalObjective { get; private set; }

        public Objective(List<Node> rules, Node finalObjective)
        {
            Rules = rules;
            FinalObjective = finalObjective;
        }

        public List<Type> EvaluateTypes()
        {
            var res = Rules.Select(i => i.EvaluateType()).ToList();
            res.Add(FinalObjective.EvaluateType());
            return res;
        }
        public List<object> EvaluateValues(GridState state) => Rules.Select(i => i.Evaluate(state)).ToList();

        public bool IsMet(GridState state) => IsMet(EvaluateValues(state));
        public bool IsMet(List<object> rules)
        {
            var parts = rules.Select(i => (bool)i).ToList();
            return (bool)FinalObjective.Evaluate(new GridState(parts));
        }

        public string ToCode()
        {
            string res = String.Join("\r\n", Rules.Select(i => i.ToCode().FirstLetterToUpper() + "."));
            string obj = FinalObjective.ToCode();
            if (obj != "Each rule is met.")
                res += "\r\n" + obj;
            return res;
        }
    }
}
