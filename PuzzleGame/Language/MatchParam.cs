using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleGame.Language
{
    public class MatchParam : QueryParam
    {
        public bool Matching { get; private set; }
        public MatchParam(bool matching, Token token = null)
        {
            Matching = matching;
            Token = token;
        }
        public static bool TryParse(List<Token> words, out QueryParam result)
        {
            if (words[0].Content == "matching")
            {
                result = new MatchParam(false, words.Pop());
                return true;
            }
            if (words[0].Content == "unmachthing")
            {
                result = new MatchParam(true, words.Pop());
                return true;
            }
            result = null;
            return false;
        }
        public static List<PriorityName> ValuesStartingWith(string prefix = "")
            => new List<PriorityName>() { new PriorityName("matching", 0), new PriorityName("unmatching", 0) }
            .Where(i => i.Name.StartsWith(prefix)).ToList();
    }
}
