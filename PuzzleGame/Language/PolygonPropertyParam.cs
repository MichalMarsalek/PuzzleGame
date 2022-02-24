using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleGame.Language
{
    public enum PolygonProperties { Regular, Triangle, Square, Rectangle, Trapezoid, Rhombus }
    public class PolygonPropertyParam : QueryParam
    {
        public PolygonProperties Property { get; private set; }
        public PolygonPropertyParam(PolygonProperties property, Token token=null)
        {
            Property = property;
            Token = token;
        }
        public static bool TryParse(List<Token> words, out QueryParam result)
        {
            try
            {
                result = new PolygonPropertyParam((PolygonProperties)Enum.Parse(typeof(PolygonProperties), words[0].Content.FirstLetterToUpper()), words[0]);
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
            => ExtensionMethods.Get<PolygonProperties>().Select(i => new PriorityName(i.ToString().ToLower(), 0))
            .Where(i => i.Name.StartsWith(prefix)).ToList();
    }
}
