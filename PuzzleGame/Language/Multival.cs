using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleGame.Language
{
    public class Multival<T>
    {
        public CardinalParam Cardinal { get; private set; }
        public Dictionary<string, T> Values { get; private set; }

        public Multival(Dictionary<string, T> values, CardinalParam cardinal)
        {
            Values = values;
            Cardinal = cardinal;
        }

        public Multival(T val)
        {
            Values = new Dictionary<string, T>() { { "single", val } };
        }
        public Multival<T2> Map<T2>(Func<T, T2> map)
        => new Multival<T2>(Values.ToDictionary(i => i.Key, i => map.Invoke(i.Value)), Cardinal);
    }
}
