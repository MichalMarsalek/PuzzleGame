using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleGame.Language
{
    public enum NumberProperties { Integer, Odd, Even, Prime }
    public class NumberPropertyParam : QueryParam
    {
        public NumberProperties Property { get; private set; }
        public NumberPropertyParam(NumberProperties property, Token token)
        {
            Property = property;
            Token = token;
        }
        public static bool TryParse(List<Token> words, out QueryParam result)
        {
            try
            {
                result = new NumberPropertyParam((NumberProperties)Enum.Parse(typeof(NumberProperties), words[0].Content), words[0]);
                words.Pop();
                return true;
            }
            catch
            {
                result = null;
                return false;
            }
        }
        public static new List<PriorityName> AllValues()
            => Extensions.Get<NumberProperties>().Select(i => new PriorityName(i.ToString(), 0)).ToList();
    }
}
