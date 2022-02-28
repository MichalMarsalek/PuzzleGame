using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleGame.Language
{
    public class Query : Node
    {
        public string Name { get; private set; }
        public List<QueryParam> Params { get; private set; }
        public bool IsSingularValue { get; private set; }

        public static List<List<string>> Functions = Properties.Resources.FunctionNames
            .Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None)
            .Select(i => i.Split(' ').ToList()).ToList();

        public Query(string name, List<QueryParam> parameters, Token token = null)
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
            if(func == null)
            {
                throw new Language.Exception("Wrong types. " + Name + " with types "
                    + String.Join(", ", Params.Select(i => i.GetType().ToShortString())) + " not implemented.");
            }
            if (IsSingularValue)
            {
                return func.ReturnType.GetGenericArguments()[0];
            }
            return func.ReturnType;
        }

        public static string NameUnknownFunction(List<Token> words)
        {
            var res = new List<string>();
            while (words.Any())
            {
                try
                {
                    QueryParam.ParseParam(words);
                    res.Add("_");
                }
                catch { }
                if (words.Any())
                {
                    res.Add(words.Pop().Content);
                }
            }
            return String.Join(" ", res);
        }

        public static Query ParseQuery(List<Token> words)
        {
            foreach(var function in Functions)
            {
                var args = new List<List<Token>>();
                var lastArg = new List<Token>();
                int codePtr = 0;
                int sgnPtr = 0;
                if (function.Count > words.Count) continue;
                while (codePtr < words.Count && sgnPtr < function.Count)
                {
                    if(function[sgnPtr] == "_"
                        && (sgnPtr == function.Count - 1 || words[codePtr].Content != function[sgnPtr+1]))
                    {
                        lastArg.Add(words[codePtr]);
                        codePtr++;
                    }
                    else if(function[sgnPtr] == "_"){
                        args.Add(lastArg);
                        lastArg = new List<Token>();
                        sgnPtr++;
                    }
                    else if(words[codePtr].Content == function[sgnPtr])
                    {
                        codePtr++;
                        sgnPtr++;
                    }
                    else
                    {
                        goto FunctionFailedMatch;
                    }
                }
                if(codePtr == words.Count && sgnPtr == function.Count)
                {
                    var methodName = String.Join("", function.Select(i => i.FirstLetterToUpper()));
                    List<QueryParam> parameters = args.Select(i => QueryParam.ParseParam(i)).ToList();
                    return new Query(methodName, parameters);
                }

                FunctionFailedMatch:
                continue;

            }
            var func = NameUnknownFunction(words);
            throw new Language.Exception("Unknown function \"" + func + "\".", null);
        }
    }
}
