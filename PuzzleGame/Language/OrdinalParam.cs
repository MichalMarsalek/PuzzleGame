using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleGame.Language
{
    public class OrdinalParam : SelectionParam
    {
        public int Order { get; private set; }
        public bool Last { get; private set; }
        public OrdinalParam(int order, bool last, Token token = null)
        {
            Order = order;
            Last = last;
            Token = token;
        }

        public override bool LinquisticPlural => false;

        public override bool SingleSelection => true;

        static List<string> Ordinal = new List<string>() { "", "first", "second", "third", "fourth", "fifth", "sixth", "seventh", "eighth", "nineth", "tenth", "eleventh", "twelveth", "thirteenth", "fourteenth", "fifteenth", "sixteenth", "seventeenth", "eighteenth", "nineteenth", "twentieth" };
        public static bool TryParse(List<Token> words, out QueryParam result)
        {
            if (words[0].Content == "last")
            {
                result = new OrdinalParam(1, true, words.Pop());
                return true;
            }
            if (Ordinal.Contains(words[0].Content))
            {
                var ord = words.Pop();
                var n = Ordinal.IndexOf(ord.Content);
                if (words.Count > 0 && words[0].Content == "last")
                {
                    var last = words.Pop();
                    var virtualToken = Token.Between(ord, last, ord.Content + " last");
                    result = new OrdinalParam(n, true, virtualToken);
                }
                else
                {
                    result = new OrdinalParam(n, false, ord);
                }
                return true;
            }
            result = null;
            return false;
        }

        public static new List<PriorityName> ValuesStartingWith(string prefix = "")
        {
            var result = new List<PriorityName>(){
                new PriorityName("first", 0),
                new PriorityName("last", 0),
            };


            for (int i = 2; i <= 20; i++)
            {
                result.Add(new PriorityName(Ordinal[i], i * 2));

                result.Add(new PriorityName(Ordinal[i] + " last", i * 2 + 1));

            }
            return result.Where(i => i.Name.StartsWith(prefix)).ToList();
        }
    }
}
