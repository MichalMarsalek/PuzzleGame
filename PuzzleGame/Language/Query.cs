using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleGame.Language
{
    public class Query : Node
    {
        public QueryName Name { get; private set; }
        public List<QueryParam> Params { get; private set; }
        public bool IsSingularValue { get; private set; }

        public static List<QueryName> Functions = Properties.Resources.FunctionNames
            .Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None)
            .Select(i => new QueryName(i)).ToList();

        public Query(QueryName name, List<QueryParam> parameters, Token token = null)
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
            var func = typeof(GridState).GetMethod(Name.Method, Params.Select(i => i.GetType()).ToArray());
            var result = func.Invoke(state, Params.ToArray());
            if (IsSingularValue && func.IsGenericMethod)
            {
                return result.GetType().GetMethod("One").Invoke(result, null);
            }
            return result;
        }

        public override Type EvaluateType()
        {
            var func = typeof(GridState).GetMethod(Name.Method, Params.Select(i => i.GetType()).ToArray());
            if(func == null)
            {
                throw new Language.Exception("Wrong types. " + Name + " with types "
                    + String.Join(", ", Params.Select(i => i.GetType().ToShortString())) + " not implemented.");
            }
            if (IsSingularValue && func.IsGenericMethod)
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
                if (function.Words.Count > words.Count) continue;
                while (codePtr < words.Count && sgnPtr < function.Words.Count)
                {
                    if(function.Words[sgnPtr] == "_"
                        && (sgnPtr == function.Words.Count - 1 || (
                            words[codePtr].Content.ToLower() != function.Words[sgnPtr+1]
                         && words[codePtr].Content.ToLower() != function.WordsPlural[sgnPtr + 1]
                            )))
                    {
                        lastArg.Add(words[codePtr]);
                        codePtr++;
                        if(codePtr == words.Count)
                        {
                            args.Add(lastArg);
                            lastArg = new List<Token>();
                            sgnPtr++;
                        }
                    }
                    else if(function.Words[sgnPtr] == "_"){
                        args.Add(lastArg);
                        lastArg = new List<Token>();
                        sgnPtr++;
                    }
                    else if(words[codePtr].Content.ToLower() == function.Words[sgnPtr] ||
                        words[codePtr].Content.ToLower() == function.WordsPlural[sgnPtr])
                    {
                        codePtr++;
                        sgnPtr++;
                    }
                    else
                    {
                        goto FunctionFailedMatch;
                    }
                }
                if(codePtr == words.Count && sgnPtr == function.Words.Count)
                {
                    List<QueryParam> parameters = args.Select(i => QueryParam.ParseParam(i)).ToList();
                    return new Query(function, parameters);
                }

                FunctionFailedMatch:
                continue;

            }
            var func = NameUnknownFunction(words);
            throw new Language.Exception("Unknown function \"" + func + "\".", null);
        }

        public override string ToString()
        {
            throw new NotImplementedException();
        }

        public override string ToCode() => Name.Substitute(Params);

        public override bool ContainsQuery(string name, bool include)
        {
            return (Name.ToString() == name) == include;
        }
    }
}
