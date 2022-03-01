using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleGame.Language
{
    public class QueryName
    {
        public List<string> Words { get; private set; }
        public List<string> WordsPlural { get; private set; }
        private static Dictionary<string, string> pluralisation = new Dictionary<string, string>()
        {
            { "is", "are" },
            { "line", "lines" },
            { "dot", "dots" },
            { "point", "points" },
            { "angle", "angles" },
            { "crosses", "cross" },
            { "rule", "rules" },
        };

        public QueryName(string name)
        {
            Words = name.Split(' ').ToList();
            WordsPlural = Words.Select(i => pluralisation.ContainsKey(i) ? pluralisation[i] : i).ToList();
        }

        public string Substitute(List<QueryParam> parameters)
        {
            bool plural = false;
            List<string> res = new List<string>();
            int paramIndex = 0;
            foreach(var word in Words)
            {
                if (word == "_")
                {
                    var param = parameters[paramIndex++];
                    if (param is SelectionParam)
                    {
                        plural = (param as SelectionParam).LinquisticPlural;
                    }
                    res.Add(param.ToCode());
                }
                else
                {
                    if(plural && pluralisation.ContainsKey(word))
                    {
                        res.Add(pluralisation[word]);
                    }
                    else
                    {
                        res.Add(word);
                    }
                }
            }
            return String.Join(" ", res);
        }

        public string Method
        {
            get => String.Join("", Words.Select(i => i.FirstLetterToUpper()));
        }

        public override string ToString() => String.Join(" ", Words);
    }
}
