using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleGame.Language
{
    public static class MultivalExtensions
    {
        public static Multival<T> ToMultival<T>(this List<T> data, CardinalParam card)
        {
            return new Multival<T>(data.ToDictionary(i => i.ToString(), i => i), card);
        }
        public static Multival<T> ToMultival<T, T2>(this Dictionary<T2, T> data, CardinalParam card)
        {
            return new Multival<T>(data.ToDictionary(i => i.Key.ToString(), i => i.Value), card);
        }
        public static Multival<T> ToMultival<T, T2>(this Dictionary<T2, T> data)
        {
            return data.ToMultival(new CardinalParam(0, false, true, false));
        }


        //public static bool MapIs<Number>(this Multival<Number> a, NumberPropertyParam property)
        //    => a.Map(i => i.Is(property)).Evaluate();
    }
}
