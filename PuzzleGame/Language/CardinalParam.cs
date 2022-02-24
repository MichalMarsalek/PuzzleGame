using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleGame.Language
{
    public class CardinalParam : QueryParam
    {
        public int Amount { get; private set; }
        public bool Exact { get; private set; }
        public bool Last { get; private set; }
        public CardinalParam(int amount, bool exact, bool last, Token token = null)
        {
            Amount = amount;
            Exact = exact;
            Last = last;
            Token = token;
        }

        static List<string> Cardinal = new List<string>() { "", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen", "twenty" };
        public static bool TryParse(List<Token> words, out QueryParam result)
        {
            if (words[0].Content == "exactly" && words.Count > 1 && Cardinal.Contains(words[1].Content))
            {
                var exactly = words.Pop();
                var card = words.Pop();
                var n = Cardinal.IndexOf(card.Content);
                var virtualToken = Token.Between(exactly, card, "exactly " + card.Content);
                result = new CardinalParam(n, true, false, virtualToken);
                return true;
            }
            if (words[0].Content == "no")
            {
                result = new CardinalParam(0, true, false, words.Pop());
                return true;
            }
            if (words[0].Content == "some")
            {
                result = new CardinalParam(1, false, false, words.Pop());
                return true;
            }
            if (words[0].Content == "each")
            {
                result = new CardinalParam(0, false, true, words.Pop());
                return true;
            }
            if (Cardinal.Contains(words[0].Content))
            {
                var card = words.Pop();

                result = new CardinalParam(Cardinal.IndexOf(card.Content), false, false, card);
                return true;
            }
            result = null;
            return false;
        }

        public static List<PriorityName> ValuesStartingWith(string prefix = "")
        {
            var result = new List<PriorityName>(){
                new PriorityName("no", 0),
                new PriorityName("each", 0),
                new PriorityName("some", 0),
                new PriorityName("exactly one", 1),
            };

            for (int i = 2; i <= 20; i++)
            {
                result.Add(new PriorityName(Cardinal[i], i * 2));

                result.Add(new PriorityName("exactly " + Cardinal[i], i * 2 + 1));

            }
            return result.Where(i => i.Name.StartsWith(prefix)).ToList();
        }
    }
}
