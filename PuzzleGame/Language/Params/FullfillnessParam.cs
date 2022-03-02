using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleGame.Language
{
    public class FullfillnessParam : QueryParam
    {
        public bool Fullfilled { get; private set; }
        public FullfillnessParam(bool fullfilled, Token token = null)
        {
            Fullfilled = fullfilled;
            Token = token;
        }
        public static bool TryParse(List<Token> words, out QueryParam result)
        {
            if (words[0].Content == "met")
            {
                result = new FullfillnessParam(true, words.Pop());
                return true;
            }
            if (words[0].Content == "broken")
            {
                result = new FullfillnessParam(false, words.Pop());
                return true;
            }
            result = null;
            return false;
        }
        public static List<PriorityName> ValuesStartingWith(string prefix = "")
            => new List<PriorityName>() { new PriorityName("met", 0), new PriorityName("broken", 0) }
            .Where(i => i.Name.StartsWith(prefix)).ToList();

        public override string ToCode() => Fullfilled ? "met" : "broken";
    }
}
