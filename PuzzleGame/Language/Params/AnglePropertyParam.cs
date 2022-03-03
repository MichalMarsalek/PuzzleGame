using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleGame.Language
{
    public enum AngleProperties { Convex, Concave, Acute, Obtuse, Right, Straight }
    public class AnglePropertyParam : QueryParam
    {
        public AngleProperties Property { get; private set; }
        public AnglePropertyParam(AngleProperties property, Token token = null)
        {
            Property = property;
            Token = token;
        }
        public static bool TryParse(List<Token> words, out QueryParam result)
        {
            try
            {
                result = new AnglePropertyParam((AngleProperties)Enum.Parse(typeof(AngleProperties), words[0].Content.FirstLetterToUpper()), words[0]);
                words.Pop();
                return true;
            }
            catch
            {
                result = null;
                return false;
            }
        }
        public static List<PriorityName> ValuesStartingWith(string prefix = "")
            => Util.Get<AngleProperties>().Select(i => new PriorityName(i.ToString().ToLower(), 0))
            .Where(i => i.Name.StartsWith(prefix)).ToList();


        public override string ToCode() => Property.ToString().ToLower();
    }
}
