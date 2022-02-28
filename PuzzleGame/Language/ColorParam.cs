using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleGame.Language
{
    public class ColorParam : SelectionParam
    {
        public List<Colors> Colors { get; private set; }
        public ColorParam(List<Colors> colors, Token token = null)
        {
            Colors = colors;
            Token = token;
        }

        public override bool LinquisticPlural => Colors.Count > 1;

        public override bool SingleSelection => Colors.Count == 1;


        static List<string> Color = new List<string>() { "red", "blue", "green", "yellow", "white", "black", "lime" }; //TODO
        public static bool TryParse(List<Token> words, out QueryParam result)
        {
            //strict means we require no words to be left
            result = null;
            List<Token> colors = new List<Token>();
            foreach (Token word in words)
            {
                if (word.Content.EndsWith(","))
                {
                    colors.Add(word.Subtoken(0, word.Content.Length - 1));
                }
                else
                {
                    colors.Add(word);
                    break;
                }
            }
            if (colors.Count > 0 && colors.All(i => Color.Contains(i.Content)))
            {
                words.RemoveRange(0, colors.Count);
                var colorStr = colors.Select(i => i.Content).ToList();
                var colorEnum = colorStr.Select(i => (Colors)Enum.Parse(typeof(Colors), i.FirstLetterToUpper())).ToList();
                var virtualToken = Token.Between(colors[0], colors.Last(), String.Join(", ", colorStr));

                result = new ColorParam(colorEnum, virtualToken);
                return true;
            }
            return false;
        }


        public static IEnumerable<PriorityName> SingleValuesStartingWith(string prefix="") {
            for(int i = 0; i < Color.Count; i++)
            {
                if(Color[i].StartsWith(prefix))
                    yield return new PriorityName(Color[i], i);
            }
        }

        public static IEnumerable<PriorityName> ValuesStartingWith(string prefix)
        {
            if (prefix.EndsWith(","))
                prefix = prefix.Substring(0, prefix.Length - 1);
            var parts = prefix.Split(new string[]{ ", "}, StringSplitOptions.None);
            var used = parts.Take(parts.Length-1).ToList();
            foreach (var col in used)
            {
                if (!Color.Contains(col)) yield break;
            }
            foreach (var col0 in ColorParam.SingleValuesStartingWith(parts.Last()))
            {
                if (used.Contains(col0.Name)) continue;
                yield return new PriorityName(String.Join(", ", new List<string>(used) { col0.Name }), col0.Priority);

                foreach (var col1 in ColorParam.SingleValuesStartingWith())
                {
                    if (used.Contains(col1.Name) || string.Compare(col0.Name,col1.Name) >= 0) continue;
                    yield return new PriorityName(String.Join(", ", new List<string>(used) { col0.Name, col1.Name }), col0.Priority * 20 + col1.Priority);

                    foreach (var col2 in ColorParam.SingleValuesStartingWith())
                    {
                        if (used.Contains(col2.Name) || string.Compare(col1.Name,col2.Name) >= 0) continue;
                        yield return new PriorityName(String.Join(", ", new List<string>(used) { col0.Name, col1.Name, col2.Name }), col0.Priority * 400 + col1.Priority * 20 + col2.Priority);

                    }
                }
            }
        }
    }
}
