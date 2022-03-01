using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleGame.Language
{
    public class ClosednessParam : QueryParam
    {
        public bool Closed { get; private set; }
        public ClosednessParam(bool closed, Token token = null)
        {
            Closed = closed;
            Token = token;
        }
        public static bool TryParse(List<Token> words, out QueryParam result)
        {
            if (words[0].Content == "opened")
            {
                result = new ClosednessParam(false, words.Pop());
                return true;
            }
            if (words[0].Content == "closed")
            {
                result = new ClosednessParam(true, words.Pop());
                return true;
            }
            result = null;
            return false;
        }
        public static List<PriorityName> ValuesStartingWith(string prefix = "")
            => new List<PriorityName>() { new PriorityName("closed", 0), new PriorityName("opened", 0) }
            .Where(i => i.Name.StartsWith(prefix)).ToList();

        public override string ToCode() => Closed ? "closed" : "opened";
    }
}
