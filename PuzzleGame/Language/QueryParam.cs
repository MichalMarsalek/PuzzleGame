using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleGame.Language
{
    public abstract class QueryParam
    {
        public Token Token { get; protected set; }

        public static QueryParam ParseParam(List<Token> words)
        {
            if (words.Count == 0) return null;
            QueryParam result, result2, result3;
            if (ColorParam.TryParse(words, out result)) return result;
            if (OrdinalParam.TryParse(words, out result))
            {
                if (words.Any() && ColorParam.TryParse(words, out result2))
                {
                    return new OrdinalColorParam((OrdinalParam)result, (ColorParam)result2);
                }
                return result;
            }
            if (CardinalParam.TryParse(words, out result))
            {
                if (words.Any() && ColorParam.TryParse(words, out result2))
                {
                    return new CardinalColorParam((CardinalParam)result, (ColorParam)result2);
                }
                if (words.Any() && OrdinalParam.TryParse(words, out result3))
                {
                    return new CardinalOrdinalParam((CardinalParam)result, (OrdinalParam)result3);
                }
                return result;
            }
            if (AnglePropertyParam.TryParse(words, out result)) return result;
            if (PolygonPropertyParam.TryParse(words, out result)) return result;
            if (ClosednessParam.TryParse(words, out result)) return result;
            //if (TransformPropertyParam.TryParse(words, out result)) return result; TODO
            //if (SamenessParam.TryParse(words, out result)) return result;
            return null;
        }

        public static string NameUnknownFunction(List<Token> words)
        {
            FindAndMatchFunctionQuery(words);
            var res = new List<string>();
            while (words.Any())
            {
                var temp = ParseParam(words);
                if (temp != null)
                {
                    res.Add("_");
                }
                if (words.Any())
                {
                    res.Add(words.Pop().Content);
                }
            }
            return String.Join(" ", res);
        }

        public static List<List<Token>> MatchFunctionQuery(List<Token> words, List<List<string>> function)
        {//TODO
            int i = 0; // index of part of function
            int prevw = 0; // index of last word that was part of the function name
            int w = 0; // index of word
            var result = new List<List<Token>>();
            while (w < words.Count)
            {
                if (words.Skip(w).Take(function[i].Count).Select(j => j.Content).ToList().SequenceEqual(function[i]))
                {
                    if (i > 0)
                    {
                        result.Add(words.Skip(prevw).Take(w - prevw).ToList());
                    }
                    w += function[i].Count;
                    prevw = w;
                    i++;
                }
                w++;
            }
            return result;
        }

        public static List<List<Token>> FindAndMatchFunctionQuery(List<Token> words)
        {
            List<List<List<string>>> functions = new List<List<List<string>>>()
            {
                new List<List<string>>()
                {
                    new List<string>(){},
                    new List<string>(){"line is"},
                    new List<string>(){},
                }
            };
            foreach(var function in functions)
            {
                var temp = MatchFunctionQuery(words, function);
                if(temp != null)
                {
                    return temp;
                }
            }
            return null;
        }

        public static List<PriorityName> GetAllValuesStartingWith(string prefix)
        {
            var names = new List<PriorityName>();
            foreach (var name in ColorParam.ValuesStartingWith(prefix)) names.Add(name);
            foreach (var name in CardinalParam.ValuesStartingWith(prefix)) names.Add(name);
            foreach (var name in OrdinalParam.ValuesStartingWith(prefix)) names.Add(name);
            foreach (var name in CardinalColorParam.ValuesStartingWith(prefix)) names.Add(name);
            foreach (var name in OrdinalColorParam.ValuesStartingWith(prefix)) names.Add(name);
            foreach (var name in CardinalOrdinalParam.ValuesStartingWith(prefix)) names.Add(name);
            foreach (var name in AnglePropertyParam.ValuesStartingWith(prefix)) names.Add(name);
            foreach (var name in PolygonPropertyParam.ValuesStartingWith(prefix)) names.Add(name);
            foreach (var name in ClosednessParam.ValuesStartingWith(prefix)) names.Add(name);
            return names.OrderBy(i => i.Priority).ToList();
        }
    }
}
