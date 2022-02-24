using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleGame.Language
{
    public class CardinalColorParam : QueryParam
    {
        public CardinalParam Cardinal { get; private set; }
        public ColorParam Color { get; private set; }
        public CardinalColorParam(CardinalParam cardinal, ColorParam color)
        {
            Cardinal = cardinal;
            Color = color;
            Token = Token.Between(Cardinal.Token, Color.Token);
        }

        public static new IEnumerable<PriorityName> ValuesStartingWith(string prefix)
        {
            foreach (PriorityName card in CardinalParam.ValuesStartingWith(prefix))
            {
                foreach (PriorityName col in ColorParam.ValuesStartingWith(""))
                {
                    yield return new PriorityName(card.Name + " " + col.Name, card.Priority + col.Priority);
                }
            }
            foreach (PriorityName card in CardinalParam.ValuesStartingWith("")){
                if (prefix.StartsWith(card.Name + " "))
                {
                    var colorPrefix = prefix.Substring(card.Name.Length + 1);
                    foreach (PriorityName col in ColorParam.ValuesStartingWith(colorPrefix))
                    {
                        yield return new PriorityName(card.Name + " " + col.Name, card.Priority + col.Priority);
                    }
                }
            }
        }
    }
}
