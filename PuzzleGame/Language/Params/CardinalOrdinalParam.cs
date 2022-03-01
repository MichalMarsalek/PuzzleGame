using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleGame.Language
{
    public class CardinalOrdinalParam : QueryParam
    {
        public CardinalParam Cardinal { get; private set; }
        public OrdinalParam Ordinal { get; private set; }
        public CardinalOrdinalParam(CardinalParam cardinal, OrdinalParam ordinal)
        {
            Cardinal = cardinal;
            Ordinal = ordinal;
            Token = Token.Between(Cardinal.Token, Ordinal.Token);
        }

        public static new IEnumerable<PriorityName> ValuesStartingWith(string prefix)
        {
            foreach (PriorityName card in CardinalParam.ValuesStartingWith(prefix)){
                foreach (PriorityName ord in OrdinalParam.ValuesStartingWith(""))
                {
                    yield return new PriorityName(card.Name + " " + ord.Name, card.Priority + ord.Priority);
                }
            }
            foreach (PriorityName card in CardinalParam.ValuesStartingWith(""))
            {
                if (prefix.StartsWith(card.Name + " "))
                {
                    var colorPrefix = prefix.Substring(card.Name.Length + 1);
                    foreach (PriorityName ord in OrdinalParam.ValuesStartingWith(colorPrefix))
                    {
                        yield return new PriorityName(card.Name + " " + ord.Name, card.Priority + ord.Priority);
                    }
                }
            }
        }

        public override string ToCode() => Cardinal.ToCode() + " " + Ordinal.ToCode();
    }
}
