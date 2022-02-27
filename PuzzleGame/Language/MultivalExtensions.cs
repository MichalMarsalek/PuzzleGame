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

        public static Multival<T> ReduceIfBool<T>(this Multival<T> a)
        {
            return a;
        }
        public static bool ReduceIfBool(this Multival<bool> a)
        {
            int target = a.Cardinal.Each ? a.Values.Count() : a.Cardinal.Amount;
            bool exact = a.Cardinal.Exact;
            int sofar = 0;
            foreach (var val in a.Values.Values)
            {
                if (val) sofar++;
                if (sofar > target) break;
            }
            if (exact)
            {
                return sofar == target;
            }
            else
            {
                return sofar >= target;
            }
        }


        //public static bool MapIs<Number>(this Multival<Number> a, NumberPropertyParam property)
        //    => a.Map(i => i.Is(property)).Evaluate();
    }
}
