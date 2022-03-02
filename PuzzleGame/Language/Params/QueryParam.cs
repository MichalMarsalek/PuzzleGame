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
            words = words.Select(i => new Token(i.Type, i.Start, i.Length, i.Content.ToLower())).ToList(); //TODO move elsewhere maybe
            var result = ParseParam0(words);
            if(words.Count > 0)
            {
                throw new Exception("Unexpected words \"" + String.Join(" ", words.Select(i => i.Content)) + "\".", words[0]);
            }
            return result;
        }

        private static QueryParam ParseParam0(List<Token> words)
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
            if (FullfillnessParam.TryParse(words, out result)) return result;
            //if (TransformPropertyParam.TryParse(words, out result)) return result; TODO
            //if (SamenessParam.TryParse(words, out result)) return result; TODO
            throw new Language.Exception("Unknown parameter \"" + String.Join(" ", words) + "\".");
        }

        public static List<PriorityName> GetAllValuesStartingWith(string prefix)
        {
            prefix = prefix.ToLower(); //TODO move elsewhere maybe
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

        public abstract string ToCode();
    }
}
