using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleGame.Language
{
    public enum Coordinates { X, Y }
    public class CoordinateParam : QueryParam
    {
        public Coordinates Coordinate { get; private set; }
        public CoordinateParam(Coordinates coordinate, Token token)
        {
            Coordinate = coordinate;
            Token = token;
        }
        public bool TryParse(List<Token> words, out CoordinateParam result)
        {
            try
            {
                result = new CoordinateParam((Coordinates)Enum.Parse(typeof(Coordinates), words[0].Content.FirstLetterToUpper()), words[0]);
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
            => ExtensionMethods.Get<Coordinates>().Select(i => new PriorityName(i.ToString(), 0)).ToList();
    }
}
