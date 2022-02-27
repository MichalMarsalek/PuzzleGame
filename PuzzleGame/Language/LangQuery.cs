using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleGame.Language
{
    public class LangQuery : LangNode
    {
        public string Name { get; private set; }
        public List<QueryParam> Params { get; private set; }
        public bool IsSingularValue { get; private set; }
        public LangQuery(string name, List<QueryParam> parameters, Token token = null)
        {
            Name = name;
            Params = parameters;
            var selectors = Params.Where(i => i is SelectionParam).Select(i => (SelectionParam)i).ToList();
            if(selectors.Count == 0)
            {
                IsSingularValue = true;
            }
            else
            {
                IsSingularValue = selectors[0].SingleSelection;
            }
            Token = token;
        }

        public override object Evaluate(GridState state)
        {
            var func = typeof(GridState).GetMethod(Name, Params.Select(i => i.GetType()).ToArray());
            var result = func.Invoke(state, Params.ToArray());
            if (IsSingularValue)
            {
                return result.GetType().GetMethod("One").Invoke(result, null);
            }
            return result;
        }

        public override Type EvaluateType()
        {
            var func = typeof(GridState).GetMethod(Name, Params.Select(i => i.GetType()).ToArray());
            if (IsSingularValue)
            {
                return func.ReturnType.GetGenericArguments()[0];
            }
            return func.ReturnType;
        }
    }
}
