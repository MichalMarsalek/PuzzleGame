using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleGame.Language
{
    public class OrdinalColorParam : QueryParam
    {
        public OrdinalParam Ordinal { get; private set; }
        public ColorParam Color { get; private set; }
        public OrdinalColorParam(OrdinalParam ordinal, ColorParam color)
        {
            Ordinal = ordinal;
            Color = color;
            Token = Token.Between(Ordinal.Token, Color.Token);
        }

        public static IEnumerable<PriorityName> ValuesStartingWith(string prefix)
        {
            foreach (PriorityName ord in OrdinalParam.ValuesStartingWith(prefix))
            {
                foreach (PriorityName col in ColorParam.ValuesStartingWith(""))
                {
                    yield return new PriorityName(ord.Name + " " + col.Name, ord.Priority + col.Priority);
                }
            }
            foreach (PriorityName ord in OrdinalParam.ValuesStartingWith(""))
            {
                if (prefix.StartsWith(ord.Name + " "))
                {
                    var colorPrefix = prefix.Substring(ord.Name.Length + 1);
                    foreach (PriorityName col in ColorParam.ValuesStartingWith(colorPrefix))
                    {
                        yield return new PriorityName(ord.Name + " " + col.Name, ord.Priority + col.Priority);
                    }
                }
            }
        }
    }
}
