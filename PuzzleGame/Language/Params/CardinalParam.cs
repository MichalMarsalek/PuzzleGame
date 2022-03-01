using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleGame.Language
{
    public class CardinalParam : SelectionParam
    {
        public int Amount { get; private set; }
        public bool IsExact { get; private set; }
        public bool IsEach { get; private set; }
        public bool IsOther { get; private set; }
        public CardinalParam(int amount, bool exact, bool each, bool other, Token token = null)
        {
            Amount = amount;
            IsExact = exact;
            IsEach = each;
            IsOther = other;
            Token = token;
        }
        public static CardinalParam Each = new CardinalParam(0, false, true, false);

        public override bool LinquisticPlural => Amount > 1;

        public override bool SingleSelection => false;

        static List<string> CardinalWords = new List<string>() { "", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen", "twenty" };
        public static bool TryParse(List<Token> words, out QueryParam result)
        {
            if (words[0].Content == "exactly" && words.Count > 1 && CardinalWords.Contains(words[1].Content))
            {
                var exactly = words.Pop();
                var card = words.Pop();
                var n = CardinalWords.IndexOf(card.Content);
                var virtualToken = Token.Between(exactly, card, "exactly " + card.Content);
                result = new CardinalParam(n, true, false, false, virtualToken);
                return true;
            }
            if (words[0].Content == "no")
            {
                result = new CardinalParam(0, true, false, false, words.Pop());
                return true;
            }
            if (words[0].Content == "some")
            {
                result = new CardinalParam(1, false, false, false, words.Pop());
                return true;
            }
            if (words[0].Content == "each")
            {
                result = new CardinalParam(0, false, true, false, words.Pop());
                return true;
            }
            if (CardinalWords.Contains(words[0].Content))
            {
                var card = words.Pop();

                result = new CardinalParam(CardinalWords.IndexOf(card.Content), false, false, false, card);
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
                new PriorityName("no other", 1),
                new PriorityName("each other", 1),
                new PriorityName("some other", 1),
                new PriorityName("exactly one other", 1),
            };

            for (int i = 2; i <= 20; i++)
            {
                result.Add(new PriorityName(CardinalWords[i], i * 4 + 1));
                result.Add(new PriorityName("exactly " + CardinalWords[i], i * 4 + 2));
                result.Add(new PriorityName(CardinalWords[i] + " other", i * 4 + 3));
                result.Add(new PriorityName("exactly " + CardinalWords[i] + " other", i * 4 + 4));

            }
            return result.Where(i => i.Name.StartsWith(prefix)).ToList();

        }

        public override string ToString()
        {
            string result = Amount.ToString();
            if (IsEach) result = "each";
            if (IsExact) result = "exactly " + result;
            if (IsOther) result += " other";
            return result;
        }

        public override string ToCode() => CardinalWords.ToString(); //TODO
    }
}
